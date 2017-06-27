namespace TaskManager
{
    partial class formServicios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formServicios));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalSer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCPUSer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMemoriaSer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.refrescarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formServiciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serviciosClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formServiciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosClassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl1,
            this.lblTotalSer,
            this.lbl2,
            this.lblCPUSer,
            this.lbl3,
            this.lblMemoriaSer,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(593, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(123, 17);
            this.lbl1.Text = "Servicios en Ejecucion";
            this.lbl1.Click += new System.EventHandler(this.lbl1_Click);
            // 
            // lblTotalSer
            // 
            this.lblTotalSer.Name = "lblTotalSer";
            this.lblTotalSer.Size = new System.Drawing.Size(13, 17);
            this.lblTotalSer.Text = "0";
            this.lblTotalSer.Click += new System.EventHandler(this.lblTotalProc_Click);
            // 
            // lbl2
            // 
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(85, 17);
            this.lbl2.Text = "CPU Utilizado: ";
            this.lbl2.Click += new System.EventHandler(this.lbl2_Click);
            // 
            // lblCPUSer
            // 
            this.lblCPUSer.Name = "lblCPUSer";
            this.lblCPUSer.Size = new System.Drawing.Size(23, 17);
            this.lblCPUSer.Text = "0%";
            this.lblCPUSer.Click += new System.EventHandler(this.lblCPU_Click);
            // 
            // lbl3
            // 
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(106, 17);
            this.lbl3.Text = "Memoria Utilizada:";
            this.lbl3.Click += new System.EventHandler(this.lbl3_Click);
            // 
            // lblMemoriaSer
            // 
            this.lblMemoriaSer.Name = "lblMemoriaSer";
            this.lblMemoriaSer.Size = new System.Drawing.Size(23, 17);
            this.lblMemoriaSer.Text = "0%";
            this.lblMemoriaSer.Click += new System.EventHandler(this.lblMemoria_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refrescarToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButtonSer";
            // 
            // refrescarToolStripMenuItem
            // 
            this.refrescarToolStripMenuItem.Name = "refrescarToolStripMenuItem";
            this.refrescarToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.refrescarToolStripMenuItem.Text = "Refrescar";
            this.refrescarToolStripMenuItem.Click += new System.EventHandler(this.refrescarToolStripMenuItem_Click);
            // 
            // formServiciosBindingSource
            // 
            this.formServiciosBindingSource.DataSource = typeof(TaskManager.formServicios);
            // 
            // serviciosClassBindingSource
            // 
            this.serviciosClassBindingSource.DataSource = typeof(TaskManager.ServiciosClass);
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToOrderColumns = true;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServicios.Location = new System.Drawing.Point(0, 0);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.Size = new System.Drawing.Size(593, 418);
            this.dgvServicios.TabIndex = 2;
            // 
            // formServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 440);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.statusStrip1);
            this.Name = "formServicios";
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.formServicios_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formServiciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosClassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalSer;
        private System.Windows.Forms.ToolStripStatusLabel lbl2;
        private System.Windows.Forms.ToolStripStatusLabel lblCPUSer;
        private System.Windows.Forms.ToolStripStatusLabel lbl3;
        private System.Windows.Forms.ToolStripStatusLabel lblMemoriaSer;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem refrescarToolStripMenuItem;
        private System.Windows.Forms.BindingSource serviciosClassBindingSource;
        private System.Windows.Forms.BindingSource formServiciosBindingSource;
        private System.Windows.Forms.DataGridView dgvServicios;
    }
}