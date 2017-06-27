using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;// es innecesario?
using System.Diagnostics;
using System.Management;
using System.ServiceProcess;// agregando este using solicita eliminar el siguiente porque es innecesario.

namespace TaskManager
{
    public partial class formServicios : Form
    {
        //de esta manera inicia en procesos
        //public Process[] listaProc;
        public ServiceController[] listaServ;
        BindingSource source;
        ServiciosClass serviciosClass;
        //variables necesarias
        

        public formServicios()
        {   
            //se adopta el mismo periodo de refrescamiento que en procesos
            refrescarToolStripMenuItem_Click(null, null);//accesa al event handler e inicia el grid view
            Timer cronometro = new Timer();
            cronometro.Interval = 1200000;//dos minutos de refrescamiento
            cronometro.Tick += refrescarToolStripMenuItem_Click; //refresca el grid view
            cronometro.Start();
            //

            InitializeComponent();
        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalProc_Click(object sender, EventArgs e)
        {

        }

        private void lbl2_Click(object sender, EventArgs e)
        {

        }

        private void lblCPU_Click(object sender, EventArgs e)
        {

        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }

        private void lblMemoria_Click(object sender, EventArgs e)
        {

        }

        private void formServicios_Load(object sender, EventArgs e)
        {
            //se llama el proceso de carga
            CargarServicios();
        }

        public void CargarServicios()
        {
            try
            {
                var tablaDatosServ = new DataTable();
                source = new BindingSource();
                //listaServ;// cargo los servicios en el inicio de la creacion del form
                listaServ = (ServiceController[])ServiceController.GetServices();
                
                tablaDatosServ.Columns.Add("ID");
                tablaDatosServ.Columns.Add("Nombre");
                tablaDatosServ.Columns.Add("Descripcion");
                tablaDatosServ.Columns.Add("Usuario");

                int i = 0;

                foreach (var ser in listaServ)
                {
                    serviciosClass = new ServiciosClass();

                    if (/*listaServ[i].MachineName.ToString()*/"MAX-MENA".Equals(Environment.MachineName) )
                    {
                        serviciosClass.Id = i.ToString() ;
                        serviciosClass.Nombre = ser.ServiceName.ToString();
                        serviciosClass.Desc = ser.ServiceType.ToString();

                        if (listaServ[i].MachineName.ToString().Equals("."))
                        {
                            //serviciosClass.Usuario = listaServ[i].MachineName.ToString();
                            serviciosClass.Usuario = Environment.MachineName.ToString();
                        }
                        else
                        {
                            serviciosClass.Usuario = ser.MachineName.ToString();
                        }
                    }
                    else
                    {


                        serviciosClass.Id = i.ToString();
                        serviciosClass.Nombre = "Error";
                        serviciosClass.Desc = "Error";
                        serviciosClass.Usuario = "Error";

                    }

                    tablaDatosServ.Rows.Add(serviciosClass.Id, serviciosClass.Nombre, serviciosClass.Desc, serviciosClass.Usuario);
                    i++;

                }
                source.DataSource = tablaDatosServ;//ejemplo sin utilizar data source2

                dgvServicios.DataSource = source;//ejemplo sin el data source1
                int scroll = dgvServicios.FirstDisplayedScrollingRowIndex;

                dgvServicios.DataSource = source;

                if (scroll != -1)
                {
                    dgvServicios.FirstDisplayedScrollingRowIndex = scroll;
                }


            }
            catch (Win32Exception e)
            {
                e.ToString();
                MessageBox.Show(e.ToString());
            }
        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarServicios();
        }
    }
}
