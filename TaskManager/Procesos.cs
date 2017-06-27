using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;


namespace TaskManager
{
    //Clase del formProcesos que contiene las estadisticas y la informacion de los procesos en ejecucion, y la lista de los procesos en ejecucion en un datagrid view
    public partial class formProcesos : Form
    {
        //declaracion de la lista de procesos  y de un binding source
        public Process[] listaProc;
        BindingSource source;
        ProcesosClass procesosClass;


        //Constructor del Form, donde inicializa la carga de los procesos a la tabla y el timer de refrescamiento
        public formProcesos()
        {
            InitializeComponent();
            refrescarToolStripMenuItem_Click(null, null);//accesa al event handler e inicia el grid view 
            Timer cronometro = new Timer();
            cronometro.Interval = 1200000;//dos minutos de refrescamiento a la tabla de procesos
            cronometro.Tick += refrescarToolStripMenuItem_Click; //refresca el grid view
            cronometro.Start();

        }

        //Metodo que obtiene por medio de la clase Process de la libreria Diagnostic, todos los procesos actuales ejecutandose
        public void cargarProcesos()
        {

            try
            {
                source = new BindingSource();//instanciacion del binding source y de la lista de procesos
                listaProc = Process.GetProcesses();

                lblTotalProc.Text = listaProc.Length.ToString();//carga la cantidad de procesos del array
                lblCPU.Text = getPorcentajeCPUTotal();//calcual el porcentaje de CPU utilizado
                lblMemoria.Text = Convert.ToString(Math.Round((memoriaTotal()/1000000),2)) +"%";//calcula la memoria total manejada en terminos de peso porcentual en MB


                var tablaDatos = new DataTable("Ejecutandose");//Nueva tabla de datos con los siguientes encabezados
                //Encabezados de cada columna de la tabla con las propiedades de los procesos
                tablaDatos.Columns.Add("ID");
                tablaDatos.Columns.Add("Nombre");
                tablaDatos.Columns.Add("Descripcion");
                tablaDatos.Columns.Add("CPU");
                tablaDatos.Columns.Add("Memoria");
                tablaDatos.Columns.Add("Usuario");
                tablaDatos.Columns.Add("Prioridad");

                for (int i = 0; i < listaProc.Length; i++)
                {
                    procesosClass = new ProcesosClass();//se cargan todos los procesos en este array de procesos

                    //determina si el proceso pertenece al usuario y si no se ha terminado
                    if (getNombreUsuarioProceso(listaProc[i].Id.ToString()).Equals(Environment.UserName) && listaProc[i].HasExited != false)
                    {
                        procesosClass.Id = listaProc[i].Id.ToString();//guarda en el objeto procesoClass el ID
                        procesosClass.Nombre = listaProc[i].ProcessName.ToString();//guarda en el objeto procesoClass el nombre
                        procesosClass.Desc = listaProc[i].MainModule.FileVersionInfo.FileDescription.ToString();//guarda en el objeto procesoClass la descripcion
                        procesosClass.Cpu = getPorcentajeCPU(listaProc[i].ProcessName.ToString());//guarda en el objeto procesoClass el peso porcentual del uso del CPU
                        procesosClass.Memoria = memoriaProceso((long)listaProc[i].WorkingSet64);//guarda en el objeto procesoClass el espacio de memoria utilizado
                        procesosClass.Usuario = getNombreUsuarioProceso(listaProc[i].Id.ToString());//guarda en el objeto procesoClass el usuario del proceso
                        procesosClass.Prioridad = traducirPrioridadProceso(listaProc[i].PriorityClass.ToString());//guarda en el objeto procesoClass la prioridad del proceso


                    }
                        //Obtiene los procesos ejecutandose de otro usuario con mas privilegios
                    else
                    {
                        try
                        {
                            listaProc[i].StartInfo.UseShellExecute = false;
                            procesosClass.Id = listaProc[i].Id.ToString();
                            procesosClass.Nombre = listaProc[i].ProcessName.ToString();
                            procesosClass.Desc = listaProc[i].MainModule.FileVersionInfo.FileDescription.ToString();
                            procesosClass.Cpu = getPorcentajeCPU(listaProc[i].ProcessName.ToString());
                            procesosClass.Memoria = memoriaProceso((long)listaProc[i].WorkingSet64);
                            procesosClass.Usuario = getNombreUsuarioProceso(listaProc[i].Id.ToString());
                            procesosClass.Prioridad = traducirPrioridadProceso(listaProc[i].PriorityClass.ToString());

                        }
                        catch (Win32Exception w)
                        {
                            //este catch atrapa los procesos que no son accesibles ya que son necesarios por el sistema
                            //estos procesos no son visibles al usuario administrador
                            w.Message.ToString();

                        }

                    }
                    try
                    {
                        //agrega una nueva fila con la informacion de un proceso a la tabla de datos de procesos
                        tablaDatos.Rows.Add(procesosClass.Id, procesosClass.Nombre, procesosClass.Desc, procesosClass.Cpu, procesosClass.Memoria, procesosClass.Usuario, procesosClass.Prioridad);

                    }
                    catch (Exception w)
                    {
                        MessageBox.Show(w.Message.ToString(), "Error al Cargar Tabla Interna", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                try
                {
                    tablaDatos.AcceptChanges();//guarda los  cambios en la tabla
                    source.DataSource = tablaDatos;// carga los datos de la tabla a una variable entendible por el gridview

                    int scroll = dgvProcesos.FirstDisplayedScrollingRowIndex;//se asegura que el primer dato de la tabla sea la primer fila
                    dgvProcesos.DataSource = source; //gridview carga todos los datos de la tabla

                    if (scroll != -1)
                    {
                        dgvProcesos.FirstDisplayedScrollingRowIndex = scroll;//Asigna la primer pocision de la tabla al grid view
                    }
                }
                catch (Exception w)
                {
                    //Notifica al usuario de algun error al cargar la vista de todos los procesos
                    MessageBox.Show(w.Message.ToString(), "Error Al Cargar Vista", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception w)
            {
               cargarProcesos();//Carga de nuevo los procesos en el gridview en caso de que hallan errores al cargar la tabla
            }

        }

        //Funcion que obtiene el nombre de usuario
        public string getNombreUsuarioProceso(string procesoID)
        {

            try
            {
                string query = "Select * From Win32_Process Where ProcessID = " + procesoID;//query para buscar el ID del procesos en el archivo process dll
                ManagementObjectSearcher buscar = new ManagementObjectSearcher(query);//instancia del buscador dentro del dll
                ManagementObjectCollection procesos = buscar.Get(); //se guardan todos los resultados en un arreglo de procesos

                foreach (ManagementObject obj in procesos)
                {
                    string[] listaUsuarios = new string[2];//se utiliza un arreglo de strings ya que obtiene el usuario y el dominio
                    int posUsuario = Convert.ToInt32(obj.InvokeMethod("GetOwner", listaUsuarios));
                    if (posUsuario == 0)
                    {
                        return listaUsuarios[0]; //devuelve solo el usuario
                    }
                }

            }
            catch (Exception ex)
            {
                //Notifica al usuario de algun error al obtener el nombre de usuario
                MessageBox.Show(ex.Message.ToString(), "Error Al Cargar El Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return "Sin Usuario";
        }

        //Funcion que obtiene el porcentaje del CPU utilizado
        public string getPorcentajeCPU(string nomProceso)
        {
            var contadorCPU = new PerformanceCounter("Process", "% Processor Time", nomProceso, true);// metodo de la libreria "performance counter" que obtiene el porcentaje del procesor utilizado por un proceso especifico
            contadorCPU.NextValue();
            //se evalua el resultado de acuerdo a diferentes tiempos de ejecucion del CPU
            System.Threading.Thread.Sleep(10);
            int aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(10);
            aux = (int)contadorCPU.NextValue();
            return aux + "%";//retorna el peso porcentual del uso del procesador en el proceso ingresado

        }
        //Funcion que calcula el porcentaje de CPU usado en todos los procesos
        public string getPorcentajeCPUTotal()
        {
            var contadorCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            contadorCPU.NextValue();
            System.Threading.Thread.Sleep(100);
            int aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(100);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(100);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(100);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(100);
            aux = (int)contadorCPU.NextValue();
            return aux + "%";//retorna el peso porcentual del uso del procesador deacuerdo a todos los procesos
        }

        //Calcula la memoria actual de un proceso
        public string memoriaProceso(long memoria)
        {
            string[] medida = { " B", " KB", " MB", " GB", " TB", " PB", " EB" };//arreglo de los diferentes medidas standard

            for (int x = 1; x <= medida.Length; x++)
            {
                long aux = memoria / (int)Math.Pow(1024, x); //determina si el valor se puede representar en otra escala Kilos, Megas, Gigas, etc
                if (aux == 0)
                {
                    double auxMemoria = (memoria / Math.Pow(1024, x - 1)); //Devuelve el valor en la medida entendible
                    return Math.Round(auxMemoria, 2).ToString() + medida[x - 1];
                }

            }

            return "No Disponible";
        }

        //Calcula la memoria total ocupada por todos los procesos
        public decimal memoriaTotal()
        {
            long memAux = 0;
            int cantidadProcesos = 0;
            try
            {

                listaProc = Process.GetProcesses();//obtiene la lista de procesos en ejecucion
                foreach (Process p in listaProc)
                {
                    memAux += p.WorkingSet64;//sumatoria de la memoria de ejecucion de cada proceso
                    if (p.WorkingSet64 > 0)
                        cantidadProcesos += 1;
                }
                return memAux / cantidadProcesos;//retorna el promedio de memoria utilizada en bytes
            }
            catch (Exception ex)
            {
                //Notifica al usuario de algun error al obtener la memoria utilizada de un proceso
                MessageBox.Show(ex.Message.ToString(), "Error Al Cargar La Memoria Total", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        //Carga de nuevo la tabla de procesos
        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarProcesos();
        }

        //Evento que obtiene el procesos seleccionado del grid view cuando se usa el click derecho en el grid view
        private void dgvProcesos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                dgvProcesos.CurrentCell = dgvProcesos.Rows[e.RowIndex].Cells[e.ColumnIndex];//despues de que el usuario selecciono con el click derecho del mouse una columna, la guarda en el gridview la fila seleccionada
                this.clickDerechoMenu.Show(Cursor.Position);


            }
        }

        //Evento que finaliza el proceso selecionado
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Por medio de esta sintaxis lambda, se obtiene el proceso con el ID seleccionado en el grid view
                Process.GetProcesses().FirstOrDefault(x => x.Id == int.Parse(dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[0].Value.ToString())).Kill();
               //Despues de finalizar el proceso pregunta al usuario si quiere cargar la vista de nuevo
                if (MessageBox.Show("Desea actualizar la vista de procesos?", "Proceso Cerrado Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    cargarProcesos();
            }
            catch (Exception ex)
            {
                //Notifica al usuario de algun error al cargar el proceso
                MessageBox.Show(ex.Message.ToString(), "Error Al Cerrar el Proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        //Finaliza el arbol de procesos
        private void btnFinalizarArbol_Click(object sender, EventArgs e)
        {
            //llama a la funcion para finalizar todos los procesos brindando el nombre del proceso por parametro
            this.cerrarArbolProcesos(dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[1].Value.ToString());
            //Despues de finalizar el arbol de procesos pregunta al usuario si quiere cargar la vista de nuevo
            if (MessageBox.Show("Desea actualizar la vista de procesos?", "Arbol de Procesos Cerrado Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                cargarProcesos();
        }

        //Cierra el arbol de procesos
        private void cerrarArbolProcesos(string nombreProceso)
        {
            Process[] arbol = Process.GetProcessesByName(nombreProceso);//asgina a el arreglo de procesos, todos los procesos con el mismo nombre

            try
            {
                foreach (Process pro in arbol)//cierra todos los procesos dentro de este arreglo
                {
                    try
                    {
                        pro.Kill();//cierra el proceso uno por uno
                    }
                    catch (ArgumentException ae)
                    {
                        //Notifica al usuario de algun error al cerrar el proceso
                        MessageBox.Show(ae.Message.ToString(), "Error Al Cerrar el Proceso Hijo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //Notifica al usuario de algun error al cerrar el arbol de procesos
                MessageBox.Show(ex.Message.ToString(), "Error Al Cerrar el Arbol de Procesos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        //Metodo para ajustar la afinidad del proceso
        private void cambiarPrioridad(int prioridad)
        {

            try
            {
                //determina que la fila seleccionada no se encuentre vacia
                if (!dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[2].Value.ToString().Equals(String.Empty))
                {
                    Process proc = Process.GetProcessById(int.Parse(dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[0].Value.ToString()));//obtiene el proceso por medio del ID de la fila seleccionada
                    if (!proc.HasExited)
                    {
                        //selecciona la prioridad del proceso
                        switch (prioridad)
                        {

                            case 1:
                                //prioridad baja
                                proc.PriorityClass = ProcessPriorityClass.Idle;
                                dgvProcesos.Refresh();
                                break;
                            case 2:
                                //prioridad por debajo de lo normal
                                proc.PriorityClass = ProcessPriorityClass.BelowNormal;
                                dgvProcesos.Refresh();
                                break;
                            case 3:
                                //prioridad normal
                                proc.PriorityClass = ProcessPriorityClass.Normal;
                                dgvProcesos.Refresh();
                                break;
                            case 4:
                                //prioridad por arriba de lo normal
                                proc.PriorityClass = ProcessPriorityClass.AboveNormal;
                                dgvProcesos.Refresh();
                                break;
                            case 5:
                                //prioridad alta
                                proc.PriorityClass = ProcessPriorityClass.High;
                                dgvProcesos.Refresh();
                                break;
                            case 6:
                                //prioridad en tiempo real
                                proc.PriorityClass = ProcessPriorityClass.RealTime;
                                dgvProcesos.Refresh();
                                break;


                        }

                    }
                    else
                    {
                        //Notifica al usuario si el proceso ya ha terminado
                        MessageBox.Show("No se puede cerrar un proceso que ya se encuentra cerrado", "Proceso ya termino", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //Notifica al usuario si no tiene los accesos correctos
                    MessageBox.Show("El acceso de este usuario no tiene los suficientes privilegios", "Acceso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            catch (Exception e)
            {
                //Notifica al usuario de algun error al cambiar la prioridad del proceso
                MessageBox.Show(e.Message.ToString(), "Error Al Cambiar la prioridad del proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Evento al cambiar la prioridad de un proceso a por debajo de lo normal
        private void btnidle_Click(object sender, EventArgs e)
        {
            this.cambiarPrioridad(1);
            //Despues de cambiar la priridad del proceso pregunta al usuario si quiere cargar de nuevo la vista
            if (MessageBox.Show("Desea actualizar la vista de procesos?", "Prioridad del Procesos Actualizada Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                cargarProcesos();
        }
        //Evento al cambiar la prioridad de un proceso a abaja
        private void btnBelow_Click(object sender, EventArgs e)
        {
            this.cambiarPrioridad(2);
            //Despues de cambiar la priridad del proceso pregunta al usuario si quiere cargar de nuevo la vista
            if (MessageBox.Show("Desea actualizar la vista de procesos?", "Prioridad del Procesos Actualizada Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                cargarProcesos();
        }

        //Evento al cambiar la prioridad de un proceso a normal
        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.cambiarPrioridad(3);
            //Despues de cambiar la priridad del proceso pregunta al usuario si quiere cargar de nuevo la vista
            if (MessageBox.Show("Desea actualizar la vista de procesos?", "Prioridad del Procesos Actualizada Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                cargarProcesos();
        }

        //Evento al cambiar la prioridad de un proceso a por encima de lo normal
        private void btnAbove_Click(object sender, EventArgs e)
        {
            this.cambiarPrioridad(4);
            //Despues de cambiar la priridad del proceso pregunta al usuario si quiere cargar de nuevo la vista
            if (MessageBox.Show("Desea actualizar la vista de procesos?", "Prioridad del Procesos Actualizada Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                cargarProcesos();
        }

        //Evento al cambiar la prioridad de un proceso a alta
        private void btnHigh_Click(object sender, EventArgs e)
        {
            this.cambiarPrioridad(5);
            //Despues de cambiar la priridad del proceso pregunta al usuario si quiere cargar de nuevo la vista
            if (MessageBox.Show("Desea actualizar la vista de procesos?", "Prioridad del Procesos Actualizada Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                cargarProcesos();
        }

        //Evento al cambiar la prioridad de un proceso a tiempo real
        private void btnRealTime_Click(object sender, EventArgs e)
        {
            this.cambiarPrioridad(6);
            //Despues de cambiar la priridad del proceso pregunta al usuario si quiere cargar de nuevo la vista
            if (MessageBox.Show("Desea actualizar la vista de procesos?", "Prioridad del Procesos Actualizada Exitosamente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                cargarProcesos();
        }

        //Evento del proceso del boton de afinidad. Este llama al form AfinidadForm para proveer las opciones de afinidad.
        private void btnAfinidad_Click(object sender, EventArgs e)
        {
            //instancia al formAfinidad y abre una nueva ventana
            AfinidadForm afinidad = new AfinidadForm(dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[1].Value.ToString(), int.Parse(dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[0].Value.ToString()));
            afinidad.Show();
        }
        
        //Funcion para traducir la prioridad de un proceso de Ingles a Español
        private string traducirPrioridadProceso(string prioridad)
        {
            switch (prioridad)
            {

                case "Idle":
                    return "Baja";
                    
                case "BelowNormal":
                    return "Por Debajo de lo Normal";
                   
                case "Normal":
                    return "Normal";
                   
                case "AboveNormal":
                    return "Por Encima de lo Normal";
                   
                case "High":
                    return "Alta";
                  
                case "RealTime":
                    return "Tiempo Real";
                   
            }
            return string.Empty;
        }

    }
}
