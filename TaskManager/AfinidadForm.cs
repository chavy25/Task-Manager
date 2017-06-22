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
        Process procesoActual = null;
        public AfinidadForm(string nombreProceso, int procesoID)
        {
            procesoActual = Process.GetProcessById(procesoID);
            InitializeComponent();
            lblCantidadProcesadores.Text = "Cantidad de nucleos disponibles: " + Environment.ProcessorCount.ToString();
            lblAfinidad.Text = "Qué procesadores puede ejecutar " + nombreProceso + "...?";

            switch (cargarAfinidad(procesoID))
            {
                case "1":
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = true;
                    this.cBox1.Checked = false;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = false;
                    break;

                case "2":
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = false;
                    this.cBox1.Checked = true;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = false;
                    break;

                case "3":
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = false;
                    this.cBox1.Checked = false;
                    this.cBox2.Checked = true;
                    this.cBox3.Checked = false;
                    break;

                case "4":
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = false;
                    this.cBox1.Checked = false;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = true;
                    break;

                case "7":
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = true;
                    this.cBox1.Checked = true;
                    this.cBox2.Checked = true;
                    this.cBox3.Checked = false;
                    break;

                case "9":
                    this.cBoxTodos.Checked = false;
                    this.cBox0.Checked = true;
                    this.cBox1.Checked = false;
                    this.cBox2.Checked = false;
                    this.cBox3.Checked = true;
                    break;

                case "15":
                    this.cBoxTodos.Checked = true;
                    break;

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cBoxTodos.Checked)
                actualizarAfinidad(15);
                this.Close();

            if (cBox0.Checked)
                actualizarAfinidad(1);
            this.Close();

            if (cBox1.Checked)
                actualizarAfinidad(2);
            this.Close();

            if (cBox2.Checked)
                actualizarAfinidad(3);
            this.Close();

            if (cBox3.Checked)
                actualizarAfinidad(4);
            this.Close();

            if (cBox0.Checked && cBox1.Checked && cBox2.Checked)
                actualizarAfinidad(7);
            this.Close();

            if (cBox0.Checked && cBox3.Checked)
                actualizarAfinidad(9);
            this.Close();
        }


        public string cargarAfinidad(int id)
        {

            try
            {
                if (procesoActual != null && !procesoActual.HasExited)
                {
                    return procesoActual.ProcessorAffinity.ToString();
                }
                else
                {
                    MessageBox.Show("Proceso Terminado", "El proceso selccionado ya ha finalizado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        private void actualizarAfinidad(int nucleo)
        {

            try
            {
                if (procesoActual != null && !procesoActual.HasExited)
                    procesoActual.ProcessorAffinity = (IntPtr)nucleo;
                    this.cBoxTodos.Checked = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Proceso Terminado", e.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                btnAceptar.Enabled = true;
            }
            else 
            {
                this.cBox0.Checked = false;
                this.cBox1.Checked = false;
                this.cBox2.Checked = false;
                this.cBox3.Checked = false;
                this.cBoxTodos.Checked = false;
                btnAceptar.Enabled = false;
            }
            

        }

        private void cBox0_CheckedChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
        }

        private void cBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
        }

        private void cBox2_CheckedChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
        }

        private void cBox3_CheckedChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
        }
    }
}
