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
    public partial class formProcesos : Form
    {
        public Process[] listaProc;
        BindingSource source;
        ProcesosClass procesosClass;




        public formProcesos()
        {
            InitializeComponent();
            refrescarToolStripMenuItem_Click(null, null);//accesa al event handler e inicia el grid view
            Timer cronometro = new Timer();
            cronometro.Interval = 1200000;//dos minutos de refrescamiento
            cronometro.Tick += refrescarToolStripMenuItem_Click; //refresca el grid view
            cronometro.Start();

        }

        public void cargarProcesos()
        {

            try
            {
                source = new BindingSource();
                listaProc = Process.GetProcesses();

                lblTotalProc.Text = listaProc.Length.ToString();
                lblCPU.Text = getPorcentajeCPUTotal();
                lblMemoria.Text = memoriaProceso(memoriaTotal());


                var tablaDatos = new DataTable("Ejecutandose");

                tablaDatos.Columns.Add("ID");
                tablaDatos.Columns.Add("Nombre");
                tablaDatos.Columns.Add("Descripcion");
                tablaDatos.Columns.Add("CPU");
                tablaDatos.Columns.Add("Memoria");
                tablaDatos.Columns.Add("Usuario");
                tablaDatos.Columns.Add("Prioridad");

                for (int i = 0; i < listaProc.Length; i++)
                {
                    procesosClass = new ProcesosClass();

                    if (getNombreUsuarioProceso(listaProc[i].Id.ToString()).Equals(Environment.UserName) && listaProc[i].HasExited != false)
                    {
                        procesosClass.Id = listaProc[i].Id.ToString();
                        procesosClass.Nombre = listaProc[i].ProcessName.ToString();
                        procesosClass.Desc = listaProc[i].MainModule.FileVersionInfo.FileDescription.ToString();
                        procesosClass.Cpu = getPorcentajeCPU(listaProc[i].ProcessName.ToString());
                        procesosClass.Memoria = memoriaProceso((long)listaProc[i].MainModule.ModuleMemorySize);
                        procesosClass.Usuario = getNombreUsuarioProceso(listaProc[i].Id.ToString());
                        procesosClass.Prioridad = listaProc[i].PriorityClass.ToString();


                    }
                    else
                    {
                        try
                        {
                            listaProc[i].StartInfo.UseShellExecute = false;
                            procesosClass.Id = listaProc[i].Id.ToString();
                            procesosClass.Nombre = listaProc[i].ProcessName.ToString();
                            procesosClass.Desc = listaProc[i].MainModule.FileVersionInfo.FileDescription.ToString();
                            procesosClass.Cpu = getPorcentajeCPU(listaProc[i].ProcessName.ToString());
                            procesosClass.Memoria = memoriaProceso((long)listaProc[i].MainModule.ModuleMemorySize);
                            procesosClass.Usuario = getNombreUsuarioProceso(listaProc[i].Id.ToString());
                            procesosClass.Prioridad = listaProc[i].PriorityClass.ToString();

                        }
                        catch (Win32Exception w)
                        {
                            w.Message.ToString();

                        }


                    }
                    tablaDatos.Rows.Add(procesosClass.Id, procesosClass.Nombre, procesosClass.Desc, procesosClass.Cpu, procesosClass.Memoria, procesosClass.Usuario, procesosClass.Prioridad);

                }

                tablaDatos.AcceptChanges();
                source.DataSource = tablaDatos;

                int scroll = dgvProcesos.FirstDisplayedScrollingRowIndex;
                dgvProcesos.DataSource = source;

                if (scroll != -1)
                {
                    dgvProcesos.FirstDisplayedScrollingRowIndex = scroll;
                }


            }
            catch (Exception e)
            {
                //throw e;
                // e.ToString();
            }

        }

        //Obtiene el nombre de usuario
        public string getNombreUsuarioProceso(string procesoID)
        {

            try
            {
                string query = "Select * From Win32_Process Where ProcessID = " + procesoID;//query para buscar en el process dll
                ManagementObjectSearcher buscar = new ManagementObjectSearcher(query);//instancia del buscador dentro del dll
                ManagementObjectCollection procesos = buscar.Get(); //se guardan todos los resultados en procesos

                foreach (ManagementObject obj in procesos)
                {
                    string[] listaUsuarios = new string[2]; //{ string.Empty, string.Empty };
                    int posUsuario = Convert.ToInt32(obj.InvokeMethod("GetOwner", listaUsuarios));
                    if (posUsuario == 0)
                    {
                        return listaUsuarios[0]; //devuelve el dominio\usuario
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return "Sin Usuario";
        }

        public string getPorcentajeCPU(string nomProceso)
        {
            var contadorCPU = new PerformanceCounter("Process", "% Processor Time", nomProceso, true);
            contadorCPU.NextValue();
            System.Threading.Thread.Sleep(100);
            int aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(100);
            aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(100);
            aux = (int)contadorCPU.NextValue();
            return aux + "%";


        }
        //Calcula elporcentaje de CPU usado en todos los procesos
        public string getPorcentajeCPUTotal()
        {
            var contadorCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            contadorCPU.NextValue();
            System.Threading.Thread.Sleep(1000);
            int aux = (int)contadorCPU.NextValue();
            System.Threading.Thread.Sleep(1000);
            aux = (int)contadorCPU.NextValue();
            return aux + "%";
        }

        //Calcula la memoria actual de un proceso
        public string memoriaProceso(long memoria)
        {
            string[] medida = { " B", " KB", " MB", " GB", " TB", " PB", " EB" };

            for (int x = 1; x <= medida.Length; x++)
            {
                long aux = memoria / (int)Math.Pow(1024, x); //determina si el valor se puede representar en otra escala Kilos, Megas, etc
                if (aux == 0)
                {
                    double auxMemoria = (memoria / Math.Pow(1024, x - 1)); //Devuelve el valor en la medida entendible
                    return Math.Round(auxMemoria, 2).ToString() + medida[x];
                }

            }

            return "No Disponible";
        }

        //Calcula la memoria total ocupada por todos los procesos
        public long memoriaTotal()
        {
            long memAux = 0;
            try
            {

                listaProc = Process.GetProcesses();
                foreach (Process p in listaProc)
                {
                    memAux += p.PrivateMemorySize64;
                }
                return memAux / listaProc.Length;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
            return 0;
        }

        //Carga de nuevo latabla de procesos
        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarProcesos();
        }

        //Obtiene el procesos seleccionado del grid view cuando se usa el click derecho en el grid view
        private void dgvProcesos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                dgvProcesos.CurrentCell = dgvProcesos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.clickDerechoMenu.Show(Cursor.Position);


            }
        }

        //Finaliza el proceso selecionado
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            listaProc = Process.GetProcesses();
            foreach (Process p in listaProc)
            {
                if (p.ProcessName.Equals(dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[1].Value.ToString()))
                {
                    p.Kill();
                }
            }

        }


        //Finaliza el arbol de procesos
        private void btnFinalizarArbol_Click(object sender, EventArgs e)
        {
            this.KillArbolProcesos((int)dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[0].Value);
        }

        //Cierra el arbol de procesos
        private void KillArbolProcesos(int ID)
        {
            try
            {
                string query = "Select * From Win32_Process Where ParentProcessID = " + ID;
                ManagementObjectSearcher buscar = new ManagementObjectSearcher(query);
                ManagementObjectCollection procesos = buscar.Get();

                foreach (ManagementObject obj in procesos)
                {
                    KillArbolProcesos(Convert.ToInt32(obj["ProcessID"]));
                }
                try
                {
                    Process p = Process.GetProcessById(ID);
                    p.Kill();
                }
                catch (ArgumentException)
                {
                    // fallo
                }

            }
            catch (Exception ex)
            {
                ex.ToString();

            }

        }



        //Metodo para ajustar la afinidad del proceso
        private void cambiarAfinidad(int afinidad)
        {

            try
            {
                if (!dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[2].Value.ToString().Equals(String.Empty))
                {
                    Process proc = Process.GetProcessById((int)dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[0].Value);
                    if (!proc.HasExited)
                    {

                        switch (afinidad)
                        {

                            case 1:

                                proc.PriorityClass = ProcessPriorityClass.Idle;
                                dgvProcesos.Refresh();
                                break;
                            case 2:

                                proc.PriorityClass = ProcessPriorityClass.BelowNormal;
                                dgvProcesos.Refresh();
                                break;
                            case 3:

                                proc.PriorityClass = ProcessPriorityClass.Normal;
                                dgvProcesos.Refresh();
                                break;
                            case 4:

                                proc.PriorityClass = ProcessPriorityClass.AboveNormal;
                                dgvProcesos.Refresh();
                                break;
                            case 5:

                                proc.PriorityClass = ProcessPriorityClass.High;
                                dgvProcesos.Refresh();
                                break;
                            case 6:
                                proc.PriorityClass = ProcessPriorityClass.RealTime;
                                dgvProcesos.Refresh();
                                break;
                            

                        }

                    }
                    else
                    {
                        MessageBox.Show(null, "Proceso ya termino", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(null, "Acceso Negado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            catch (Exception e) { }
        }
        
        private void btnidle_Click(object sender, EventArgs e)
        {
            this.cambiarAfinidad(1);
        }
        private void btnBelow_Click(object sender, EventArgs e)
        {
            this.cambiarAfinidad(2);
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.cambiarAfinidad(3);
        }

        private void btnAbove_Click(object sender, EventArgs e)
        {
            this.cambiarAfinidad(4);
        }

        private void btnHigh_Click(object sender, EventArgs e)
        {
            this.cambiarAfinidad(5);
        }

        private void btnRealTime_Click(object sender, EventArgs e)
        {
            this.cambiarAfinidad(6);
        }

        private void btnAfinidad_Click(object sender, EventArgs e)
        {
             AfinidadForm afinidad = new AfinidadForm(dgvProcesos.Rows[dgvProcesos.CurrentCellAddress.Y].Cells[1].Value.ToString());
             afinidad.Show();
        }



    }
}
