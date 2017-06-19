namespace TaskManager
{
    partial class formProcesos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formProcesos));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalProc = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCPU = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMemoria = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.refrescarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvProcesos = new System.Windows.Forms.DataGridView();
            this.clickDerechoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnFinalizar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFinalizarArbol = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrioridad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnidle = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNormal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHigh = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRealTime = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAfinidad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBelow = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbove = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).BeginInit();
            this.clickDerechoMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl1,
            this.lblTotalProc,
            this.lbl2,
            this.lblCPU,
            this.lbl3,
            this.lblMemoria,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(809, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(124, 17);
            this.lbl1.Text = "Procesos en Ejecucion";
            // 
            // lblTotalProc
            // 
            this.lblTotalProc.Name = "lblTotalProc";
            this.lblTotalProc.Size = new System.Drawing.Size(13, 17);
            this.lblTotalProc.Text = "0";
            // 
            // lbl2
            // 
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(85, 17);
            this.lbl2.Text = "CPU Utilizado: ";
            // 
            // lblCPU
            // 
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(23, 17);
            this.lblCPU.Text = "0%";
            // 
            // lbl3
            // 
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(106, 17);
            this.lbl3.Text = "Memoria Utilizada:";
            // 
            // lblMemoria
            // 
            this.lblMemoria.Name = "lblMemoria";
            this.lblMemoria.Size = new System.Drawing.Size(23, 17);
            this.lblMemoria.Text = "0%";
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
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // refrescarToolStripMenuItem
            // 
            this.refrescarToolStripMenuItem.Name = "refrescarToolStripMenuItem";
            this.refrescarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refrescarToolStripMenuItem.Text = "Refrescar";
            this.refrescarToolStripMenuItem.Click += new System.EventHandler(this.refrescarToolStripMenuItem_Click);
            // 
            // dgvProcesos
            // 
            this.dgvProcesos.AllowUserToOrderColumns = true;
            this.dgvProcesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesos.ContextMenuStrip = this.clickDerechoMenu;
            this.dgvProcesos.Location = new System.Drawing.Point(12, 12);
            this.dgvProcesos.Name = "dgvProcesos";
            this.dgvProcesos.ReadOnly = true;
            this.dgvProcesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcesos.Size = new System.Drawing.Size(781, 388);
            this.dgvProcesos.TabIndex = 2;
            this.dgvProcesos.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProcesos_CellMouseDown);
            // 
            // clickDerechoMenu
            // 
            this.clickDerechoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFinalizar,
            this.btnFinalizarArbol,
            this.btnPrioridad,
            this.btnAfinidad});
            this.clickDerechoMenu.Name = "contextMenuStrip1";
            this.clickDerechoMenu.ShowImageMargin = false;
            this.clickDerechoMenu.Size = new System.Drawing.Size(187, 92);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(186, 22);
            this.btnFinalizar.Text = "Finalizar Proceso";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnFinalizarArbol
            // 
            this.btnFinalizarArbol.Name = "btnFinalizarArbol";
            this.btnFinalizarArbol.Size = new System.Drawing.Size(186, 22);
            this.btnFinalizarArbol.Text = "Finaliza Arbol de Procesos";
            this.btnFinalizarArbol.Click += new System.EventHandler(this.btnFinalizarArbol_Click);
            // 
            // btnPrioridad
            // 
            this.btnPrioridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnidle,
            this.btnBelow,
            this.btnNormal,
            this.btnAbove,
            this.btnHigh,
            this.btnRealTime});
            this.btnPrioridad.Name = "btnPrioridad";
            this.btnPrioridad.Size = new System.Drawing.Size(186, 22);
            this.btnPrioridad.Text = "Cambiar Prioridad";
            // 
            // btnidle
            // 
            this.btnidle.Name = "btnidle";
            this.btnidle.Size = new System.Drawing.Size(152, 22);
            this.btnidle.Text = "Idle";
            this.btnidle.Click += new System.EventHandler(this.btnidle_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(152, 22);
            this.btnNormal.Text = "Normal";
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnHigh
            // 
            this.btnHigh.Name = "btnHigh";
            this.btnHigh.Size = new System.Drawing.Size(152, 22);
            this.btnHigh.Text = "High";
            this.btnHigh.Click += new System.EventHandler(this.btnHigh_Click);
            // 
            // btnRealTime
            // 
            this.btnRealTime.Name = "btnRealTime";
            this.btnRealTime.Size = new System.Drawing.Size(152, 22);
            this.btnRealTime.Text = "Real Time";
            this.btnRealTime.Click += new System.EventHandler(this.btnRealTime_Click);
            // 
            // btnAfinidad
            // 
            this.btnAfinidad.Name = "btnAfinidad";
            this.btnAfinidad.Size = new System.Drawing.Size(186, 22);
            this.btnAfinidad.Text = "Establecer Afinidad";
            // 
            // btnBelow
            // 
            this.btnBelow.Name = "btnBelow";
            this.btnBelow.Size = new System.Drawing.Size(152, 22);
            this.btnBelow.Text = "Below Normal";
            this.btnBelow.Click += new System.EventHandler(this.btnBelow_Click);
            // 
            // btnAbove
            // 
            this.btnAbove.Name = "btnAbove";
            this.btnAbove.Size = new System.Drawing.Size(152, 22);
            this.btnAbove.Text = "Above Normal";
            this.btnAbove.Click += new System.EventHandler(this.btnAbove_Click);
            // 
            // formProcesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 425);
            this.Controls.Add(this.dgvProcesos);
            this.Controls.Add(this.statusStrip1);
            this.Name = "formProcesos";
            this.Text = "Procesos";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesos)).EndInit();
            this.clickDerechoMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalProc;
        private System.Windows.Forms.ToolStripStatusLabel lbl2;
        private System.Windows.Forms.ToolStripStatusLabel lblCPU;
        private System.Windows.Forms.ToolStripStatusLabel lbl3;
        private System.Windows.Forms.ToolStripStatusLabel lblMemoria;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.DataGridView dgvProcesos;
        private System.Windows.Forms.ToolStripMenuItem refrescarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip clickDerechoMenu;
        private System.Windows.Forms.ToolStripMenuItem btnFinalizar;
        private System.Windows.Forms.ToolStripMenuItem btnFinalizarArbol;
        private System.Windows.Forms.ToolStripMenuItem btnPrioridad;
        private System.Windows.Forms.ToolStripMenuItem btnAfinidad;
        private System.Windows.Forms.ToolStripMenuItem btnidle;
        private System.Windows.Forms.ToolStripMenuItem btnNormal;
        private System.Windows.Forms.ToolStripMenuItem btnHigh;
        private System.Windows.Forms.ToolStripMenuItem btnRealTime;
        private System.Windows.Forms.ToolStripMenuItem btnBelow;
        private System.Windows.Forms.ToolStripMenuItem btnAbove;
    }
}