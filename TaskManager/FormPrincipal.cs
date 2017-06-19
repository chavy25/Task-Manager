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
    public partial class FormPrincipal : Form
    {
        private int childFormNumber = 1;
       
         
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            formProcesos childForm = new formProcesos();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void btnSalirServicios_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAbrirFormServicios_Click(object sender, EventArgs e)
        {
            formServicios childForm = new formServicios();
            childForm.MdiParent = this;
            childForm.Text = "Ventana Servicios " + childFormNumber++;
            childForm.Show();
        }

        private void btnNuevoFormsServicios_Click(object sender, EventArgs e)
        {
            formServicios childForm = new formServicios();
            childForm.MdiParent = this;
            childForm.Text = "Ventana Servicios " + childFormNumber++;
            childForm.Show();
        }

        private void btnNuevoFormsProcesos_Click(object sender, EventArgs e)
        {
            formProcesos childForm = new formProcesos();
            childForm.MdiParent = this;
            childForm.Text = "Ventana Procesos " + childFormNumber++;
            childForm.Show();
        }

        private void btnBuscarProceso_Click(object sender, EventArgs e)
        {
            formBuscar childForm = new formBuscar();
            childForm.MdiParent = this;
            childForm.Text = "Correr Procesos " + childFormNumber++;
            childForm.Show();
        }

        private void btnNuevoBuscarProc_Click(object sender, EventArgs e)
        {
            formBuscar childForm = new formBuscar();
            childForm.MdiParent = this;
            childForm.Text = "Correr Programa " + childFormNumber++;
            childForm.Show();
        }

    }
}
