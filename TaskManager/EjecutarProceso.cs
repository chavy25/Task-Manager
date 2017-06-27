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
    //Clase que inicia un form para ejecutar un procesos por el ID o el nombre
    public partial class EjecutarProceso : Form
    {
        //Declaracion del proceso
        Process procesoAEjeutar = null;
                
        //constructor de la clase que inicializa un helper para el usuario
        public EjecutarProceso()
        {
            InitializeComponent();
            //helper agregado al form en caso de que el usuario no tenga idea de que hacer
            hlp.SetHelpString(txtIDProceso, "Ingrese el Process Id or el Process Name");
        }

        //Evento que al oprimir el boton cerrar, cierra este form
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Evento que al oprimir el boton de ejecutar programa - Primero busca si se ingreso algun valor, si el proceso ya se esta ejecutando, si no ejecuta una instancia y notifica al usuario
        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (txtIDProceso.Text.Length > 0)
            {
                procesoAEjeutar = Process.GetProcesses().FirstOrDefault(x => x.ProcessName.Contains(txtIDProceso.Text));//asigna a la variable procesoAEjecutar el proceso con el nombre ingresado 

                if (procesoAEjeutar != null)//si la variable "procesoAEjecutar" no es nulo, significa que ya esta corriendo
                {
                    //pregunta si quiere correr de nuevo el mismo proceso ya en ejecucion
                    if (MessageBox.Show("El proceso seleccionado ya se esta corriendo. Desea ejecutarlo de nuevo?", "Proceso Ya en Ejecucion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            //Si el proceso ya esta corriendo y el usuario lo quiere correr otra vez, crea una instancia de un nuevo proceso con el nombre de inicio y se corre de nuevo
                            procesoAEjeutar = new Process {
                                StartInfo =
                            {
                                FileName = txtIDProceso.Text,
                                Arguments = "-username=" + Environment.UserName
                            }
                        };
                            procesoAEjeutar.Start();//Ejecuta el nuevo proceso definido por el nombre del proceso ya en ejecucion, osea una nueva instancia del mismo programa
                            this.Close();//Cierra el form actual

                        }
                        catch (Exception ex)
                        {
                            //Notifica al usuario en caso de error
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
                        procesoAEjeutar.Start();//se ejecuta el proceso
                        this.Close();//Cierre del form

                    }
                    catch (Exception ex)//En caso de que no se encuentre el proceso, ya sea por el nombre equivocado, se le pregunta al usuario si quiere intentar de nuevo
                    {
                        if (MessageBox.Show(ex.Message.ToString(), "Error de Ejecucion", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                        {
                            txtIDProceso.Text = "";//Se limpia el campo del textBox
                            procesoAEjeutar = null;//se anula la instancia del proceso para una nueva busqueda
                        }
                        else
                        {
                            this.Close();//Cierra el form actual
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
