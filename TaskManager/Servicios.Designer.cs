namespace TaskManager
{
    partial class Servicios
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
            this.contextMenuServicios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemIniciar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPausar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDetener = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblCorriendo = new System.Windows.Forms.Label();
            this.contextMenuServicios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuServicios
            // 
            this.contextMenuServicios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIniciar,
            this.toolStripMenuItemPausar,
            this.toolStripMenuItemDetener});
            this.contextMenuServicios.Name = "contextMenuServicios";
            this.contextMenuServicios.Size = new System.Drawing.Size(160, 70);
            // 
            // toolStripMenuItemIniciar
            // 
            this.toolStripMenuItemIniciar.Name = "toolStripMenuItemIniciar";
            this.toolStripMenuItemIniciar.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemIniciar.Text = "Iniciar Servicio";
            // 
            // toolStripMenuItemPausar
            // 
            this.toolStripMenuItemPausar.Name = "toolStripMenuItemPausar";
            this.toolStripMenuItemPausar.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemPausar.Text = "Pausar Servicio";
            // 
            // toolStripMenuItemDetener
            // 
            this.toolStripMenuItemDetener.Name = "toolStripMenuItemDetener";
            this.toolStripMenuItemDetener.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItemDetener.Text = "Detener Servicio";
            // 
            // dgvServicios
            // 
            this.dgvServicios.AllowUserToAddRows = false;
            this.dgvServicios.AllowUserToDeleteRows = false;
            this.dgvServicios.Location = new System.Drawing.Point(12, 12);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.ReadOnly = true;
            this.dgvServicios.Size = new System.Drawing.Size(563, 311);
            this.dgvServicios.TabIndex = 1;
            this.dgvServicios.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvServicios_CellMouseDown);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 333);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(158, 13);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Cantidad de servicios corriendo:";
            // 
            // lblCorriendo
            // 
            this.lblCorriendo.AutoSize = true;
            this.lblCorriendo.Location = new System.Drawing.Point(166, 333);
            this.lblCorriendo.Name = "lblCorriendo";
            this.lblCorriendo.Size = new System.Drawing.Size(35, 13);
            this.lblCorriendo.TabIndex = 3;
            this.lblCorriendo.Text = "label1";
            // 
            // Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 355);
            this.Controls.Add(this.lblCorriendo);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.dgvServicios);
            this.Name = "Servicios";
            this.Text = "Servicios Ejecutandose";
            this.contextMenuServicios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuServicios;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPausar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDetener;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIniciar;
        private System.Windows.Forms.DataGridView dgvServicios;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblCorriendo;
    }
}