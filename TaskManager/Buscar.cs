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

namespace TaskManager
{
    public partial class formBuscar : Form
    {
        public formBuscar()
        {
            InitializeComponent();
            hlp.SetHelpString(txtIDProceso, "Ingrese el Process Id or el Process Name");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                
            }catch(Exception){}
        }




    }
}
