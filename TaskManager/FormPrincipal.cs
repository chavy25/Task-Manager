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


namespace TaskManager
{
    //Clase del form principal el cual es un MDIparent
    public partial class FormPrincipal : Form
    {
        private int childFormNumber = 1;//Inicializa la cantidad de ventanas abiertas
       
         
        public FormPrincipal()
        {
            InitializeComponent();
        }

        //Evento para ejecutar la ventana de procesos
        private void ShowNewForm(object sender, EventArgs e)
        {
            formProcesos childForm = new formProcesos();//crea una nueva instancia de un form hijo de la clase formProcesos
            childForm.MdiParent = this;
            childForm.Text = "Ventana Procesos - Ventana #" + childFormNumber++;
            childForm.Show();//Despliega el nuevo formProcesos
        }

        //Evento para salir de la aplicacion
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cierra el ejecutable del proyecto
            Application.Exit();
        }

        //evento para ver el menu superior de la opcion procesos
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        //evento para ver los forms hijos en cascada
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        //evento para ver los form hijos uno junto al otro
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        //evento para ver los form hijos uno junto al otro horizontalmente
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        //evento para ver los form hijos uno junto al otro
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        //Evento para cerrar todos los forms hijos
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();//cieere uno por uno de los forms hijos
            }
        }

        //Cierre de la aplicacion
        private void btnSalirServicios_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Evento que crea una nueva instancia del form servicios como hija de este form y la abre
        private void btnAbrirFormServicios_Click(object sender, EventArgs e)
        {
            formServicios childForm = new formServicios();
            childForm.MdiParent = this;
            childForm.Text = "Ventana Servicios - Ventana #" + childFormNumber++;
            childForm.Show();
        }

        //Evento que crea una nueva instancia del form servicios como hija de este form y la abre, diferente punto de acceso
        private void btnNuevoFormsServicios_Click(object sender, EventArgs e)
        {
            formServicios childForm = new formServicios();
            childForm.MdiParent = this;
            childForm.Text = "Ventana Servicios - Ventana #" + childFormNumber++;
            childForm.Show();
        }

        //Evento que crea una nueva instancia del form procesos como hija de este form y la abre, desde un diferente punto de acceso
        private void btnNuevoFormsProcesos_Click(object sender, EventArgs e)
        {
            formProcesos childForm = new formProcesos();
            childForm.MdiParent = this;
            childForm.Text = "Ventana Procesos - Ventana #" + childFormNumber++;
            childForm.Show();
        }

        //Evento que crea una nueva instancia del form buscar procesos como hija de este form y la abre, desde un diferente punto de acceso
        private void btnBuscarProceso_Click(object sender, EventArgs e)
        {
            formBuscar childForm = new formBuscar();
            childForm.MdiParent = this;
            childForm.Text = "Correr Procesos - Ventana #" + childFormNumber++;
            childForm.Show();
        }

        //Evento que crea una nueva instancia del form buscar procesos como hija de este form y la abre, desde un diferente punto de acceso

        private void btnNuevoBuscarProc_Click(object sender, EventArgs e)
        {
            formBuscar childForm = new formBuscar();
            childForm.MdiParent = this;
            childForm.Text = "Correr Programa - Ventana #" + childFormNumber++;
            childForm.Show();
        }

    }
}
