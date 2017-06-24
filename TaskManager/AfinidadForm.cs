using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    //Clase Afinidad la que permite seleccionar por medio de check-boxes la afinidad de un proceso abierto del sistema operativo
    public partial class AfinidadForm : Form
    {
        Process procesoActual = null;

        /*Constructor de la clase, la cual trae los parametros del nombre del proceso y el id del proceso seleccionado para cargar la afinidad actual de dicho proceso
         * Ademas carga el numero de nucleos o procesadores disponibles
         */
        public AfinidadForm(string nombreProceso, int procesoID)
        {
            procesoActual = Process.GetProcesses().FirstOrDefault(x => x.Id == procesoID);//asigna a la variable procesoAEjecutar el proceso con el id del proceso seleccionado 
            InitializeComponent();
            lblCantidadProcesadores.Text = "Cantidad de nucleos disponibles: " + Environment.ProcessorCount.ToString();//Asigna al label el numero de nucleos o procesadores disponibles
            lblAfinidad.Text = "Qué procesadores puede ejecutar " + nombreProceso + "...?";

            switch (cargarAfinidad(procesoID))
            {
                case "1"://procesador 0
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = true;
                    this.cBox1.Checked = false;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = false;
                    break;

                case "2"://procesador 1
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = false;
                    this.cBox1.Checked = true;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = false;
                    break;

                case "3"://procesador 0y1
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = true;
                    this.cBox1.Checked = true;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = false;
                    break;

                case "4"://procesador 3
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = false;
                    this.cBox1.Checked = false;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = true;
                    break;

                case "5"://procesador 0y2
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = true;
                    this.cBox1.Checked = false;
                    this.cBox2.Checked = true;
                    this.cBox3.Checked = false;
                    break;


                case "7"://procesador 0y1y2
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = true;
                    this.cBox1.Checked = true;
                    this.cBox2.Checked = true;
                    this.cBox3.Checked = false;
                    break;

                case "9"://procesador 0y3
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = true;
                    this.cBox1.Checked = false;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = true;
                    break;

                case "15"://todos los procesadores
                    this.cBoxTodos.Checked = true;
                    break;

            }
        }

        //Funcion de evento al oprimir el boton cancelar - unicamente cierra este form
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Funcion del boton aceptar
         *verifica cuales check boxes han sido seleccionados y llama al proceso de actualizar afinidad para guardar estos valores en el proceso respectivo*/
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            //Procesador 0
            if (cBox0.Checked && !cBox1.Checked && !cBox2.Checked && !cBox3.Checked)
                actualizarAfinidad(1);

            //Procesador 1
            if (cBox1.Checked && !cBox0.Checked && !cBox2.Checked && !cBox3.Checked)
                actualizarAfinidad(2);

            //Procesador 2
            if (cBox2.Checked && !cBox1.Checked && !cBox0.Checked && !cBox3.Checked)
                actualizarAfinidad(3);
            //Procesador 3
            if (cBox3.Checked && !cBox1.Checked && !cBox2.Checked && !cBox0.Checked)
                actualizarAfinidad(4);

            //Procesador 0 y 1
            if (cBox0.Checked && cBox1.Checked && cBox2.Checked && !cBox3.Checked)
                actualizarAfinidad(7);
            //Procesador 0 y 2
            if (cBox0.Checked && cBox2.Checked && !cBox1.Checked && !cBox3.Checked)
                actualizarAfinidad(5);

            //Procesador 0 y 3
            if (cBox0.Checked && cBox3.Checked && !cBox1.Checked && !cBox2.Checked)
                actualizarAfinidad(9);
            //Todos los procesadores
            if (cBoxTodos.Checked)
                actualizarAfinidad(15);
            
            this.Close();//cierra el form al terminar

        }

        /*Funcion para obtener la afinidad del proceso actual*/
        public string cargarAfinidad(int id)
        {
            try
            {
                //verifica que el proceso se  haya cargado correctamente en la variable local y que este no halla terminado
                if (procesoActual != null && !procesoActual.HasExited)
                    return procesoActual.ProcessorAffinity.ToString();//devuelve la afinidad del proceso en un numero decimal
                //Para averiguar el procesador se toma en cuenta la formula 2¨n -1, n = la cantidad de procesadors habilitados

                //Notifica al usuario que el proceso ya ha finalizado
                MessageBox.Show("El proceso seleccionado ya ha finalizado", "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                //Notifica al usuario de algun error al cambiar la afinidad de un proceso
                MessageBox.Show(ex.Message.ToString(),"Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }

        }

        /*Funcion para actualizar la afinidad del proceso actual*/
        private void actualizarAfinidad(int nucleo)
        {
            try
            {
                //verifica que el proceso se halla cargado exitosamente en la variable global y siga en ejecucion
                if (procesoActual != null && !procesoActual.HasExited)
                    procesoActual.ProcessorAffinity = (IntPtr)nucleo;//asigna la afinidad al proceso de acuerdo al procesador(es) seleccionados

            }
            catch (Exception ex)
            {
                //Notifica al usuario que el proceso ya ha finalizado
                MessageBox.Show(ex.Message.ToString(), "Proceso Terminado", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //Evento del check box "cbxTodos" el cual selecciona automaticamente todos los demas check boxes y viceversa
        private void cBoxTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxTodos.Checked)
            {
                this.cBox0.Checked = true;
                this.cBox1.Checked = true;
                this.cBox2.Checked = true;
                this.cBox3.Checked = true;
                this.cBoxTodos.Checked = true;
                btnAceptar.Enabled = true;
            }
            else
            {
                this.cBox0.Checked = false;
                this.cBox1.Checked = false;
                this.cBox2.Checked = false;
                this.cBox3.Checked = false;
                this.cBoxTodos.Checked = false;
                btnAceptar.Enabled = false;//deshabilita el boton aceptar cuando ningun procesador se selecciona
            }


        }

        //Evento del checkbox del primer procesador - habilita el boton de aceptar
        private void cBox0_CheckedChanged(object sender, EventArgs e)
        {
            //Habilita el boton aceptar
            btnAceptar.Enabled = true;
        }

        //Evento del checkbox del segundo procesador - habilita el boton de aceptar
        private void cBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Habilita el boton aceptar
            btnAceptar.Enabled = true;
        }

        //Evento del checkbox del tercer procesador - habilita el boton de aceptar
        private void cBox2_CheckedChanged(object sender, EventArgs e)
        {
            //Habilita el boton aceptar
            btnAceptar.Enabled = true;
        }

        //Evento del checkbox del cuarto procesador - habilita el boton de aceptar
        private void cBox3_CheckedChanged(object sender, EventArgs e)
        {
            //Habilita el boton aceptar
            btnAceptar.Enabled = true;
        }
    }
}
