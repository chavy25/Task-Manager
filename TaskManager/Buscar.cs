using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;

namespace TaskManager
{
    public partial class formBuscar : Form
    {

        Process procesoAEjeutar = null;
        Process[] procesosCorriendo;
        //Clase que inicia un form para ejecutar un procesos por el ID o el nombre
        public formBuscar()
        {
            InitializeComponent();
            //helper agregado al form en caso de que el usuario no tenga idea de que hacer
            hlp.SetHelpString(txtIDProceso, "Ingrese el Process Id or el Process Name");
        }

        //Evento al oprimir el boton cerrar que cierra este form
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Evento al oprimir el boton de ejecutar programa - Primero busca si se ingreso algun valor, si el proceso ya se esta ejecutando
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (txtIDProceso.Text.Length > 0)
            {
                procesoAEjeutar = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.Contains(txtIDProceso.Text));//asigna a la variable procesoAEjecutar el proceso con el nombre ingresado 

                if (procesoAEjeutar != null)//si el procesoAEjecutar no es nulo, significa que ya esta corriendo
                {
                    //pregunta si quiere correr de nuevo el mismo proceso ya een ejecucion
                    if (MessageBox.Show("El proceso seleccionado ya se esta corriendo. Desea ejecutarlo de nuevo?", "Proceso Ya en Ejecucion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            procesoAEjeutar.Start();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error de Ejecucion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else//Si el proceso no se esta ejecutando, se instancia con el nombre ingresado y se corre
                {
                    try
                    {
                        procesoAEjeutar = new Process
                        {
                            StartInfo =
                            {
                                FileName = txtIDProceso.Text,
                                Arguments = "-username=" + Environment.UserName
                            }
                        };
                        procesoAEjeutar.Start();
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show(ex.Message.ToString(), "Error de Ejecucion", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            txtIDProceso.Text = "";
                            procesoAEjeutar = null;
                        }
                        else
                        {
                            this.Close();
                        }

                    }
                }

            }
            else//Lanza un mensaje cuando no ingreso ningun valor
            {
                MessageBox.Show("Por Favor Ingrese el Nombre del Proceso a ejecutar", "Ningun Proceso fue ingresado ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
