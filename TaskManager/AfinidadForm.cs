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
    public partial class AfinidadForm : Form
    {
        String nombreProceso = string.Empty;
        Process[] listaProcesosActual;
        ProcessThreadCollection hilos;
        public AfinidadForm(string nombreProceso)
        {
            InitializeComponent();
            this.nombreProceso = nombreProceso;
            lblCantidadProcesadores.Text = cargarAfinidad(nombreProceso);//"Cantidad de nucleos disponibles: "+Environment.ProcessorCount.ToString();
            lblAfinidad.Text = "Qué procesadores puede ejecutar "+nombreProceso+"?";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cBoxTodos.Checked)
                this.Close();

           if (cBox0.Checked) 
                actualizarAfinidad(0);
                this.Close();

            if (cBox1.Checked) 
                actualizarAfinidad(1);
                this.Close();
            
            if (cBox2.Checked) 
                actualizarAfinidad(2);
                this.Close();
            
            if (cBox3.Checked) 
                actualizarAfinidad(3);
                this.Close();
            
        }


        public string cargarAfinidad(String nombre){

            if (nombreProceso != string.Empty)
            {
                listaProcesosActual = Process.GetProcessesByName(nombreProceso);

                if (listaProcesosActual.Length > 0)
                {
                    try
                    {
                        return listaProcesosActual[0].ProcessorAffinity.ToString();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return null;
        }


        private void actualizarAfinidad(int caso) {
           
            

            if (nombreProceso != string.Empty)
            {                
                listaProcesosActual = Process.GetProcessesByName(nombreProceso);

                if (listaProcesosActual.Length > 0)
                {
                    hilos = listaProcesosActual[0].Threads;
                    hilos[0].ProcessorAffinity = (IntPtr)caso;

                }else { 
                    
                }
            }else
            {
               
            }
        }

        private void cBoxTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxTodos.Checked)
            {
                this.cBox0.Checked = true;
                this.cBox1.Checked = true;
                this.cBox2.Checked = true;
                this.cBox3.Checked = true;
                this.cBoxTodos.Checked = true;
            }
            else {
                this.cBox0.Checked = false;
                this.cBox1.Checked = false;
                this.cBox2.Checked = false;
                this.cBox3.Checked = false;
                this.cBoxTodos.Checked = false;
            }
            
        }
    }
}
