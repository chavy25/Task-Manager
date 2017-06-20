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
        String proceso = string.Empty;
        public AfinidadForm(string nombreProceso)
        {
            InitializeComponent();
            proceso = nombreProceso;
            lblAfinidad.Text = "Qué procesadores puede ejecutar "+nombreProceso+"?";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
           

        }

        private void actualizarAfinidad(int caso) {
            Process[] procesoActual;
            ProcessThreadCollection hilos;

            if (proceso != string.Empty)
            {
                procesoActual = Process.GetProcessesByName(proceso);

                hilos = procesoActual[0].Threads;
                hilos[0].IdealProcessor = 0;
                hilos[0].ProcessorAffinity = (IntPtr)1;
            }
            else
            {
                //fallo
            }
        }
    }
}
