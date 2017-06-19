namespace TaskManager
{
    partial class formBuscar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtIDProceso = new System.Windows.Forms.TextBox();
            this.lblEjecutar = new System.Windows.Forms.Label();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.hlp = new System.Windows.Forms.HelpProvider();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.txtIDProceso);
            this.panel1.Controls.Add(this.lblEjecutar);
            this.panel1.Controls.Add(this.btnEjecutar);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 149);
            this.panel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(40, 108);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(101, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtIDProceso
            // 
            this.txtIDProceso.Location = new System.Drawing.Point(19, 44);
            this.txtIDProceso.Name = "txtIDProceso";
            this.txtIDProceso.Size = new System.Drawing.Size(203, 20);
            this.txtIDProceso.TabIndex = 2;
            // 
            // lblEjecutar
            // 
            this.lblEjecutar.AutoSize = true;
            this.lblEjecutar.Location = new System.Drawing.Point(16, 19);
            this.lblEjecutar.Name = "lblEjecutar";
            this.lblEjecutar.Size = new System.Drawing.Size(46, 13);
            this.lblEjecutar.TabIndex = 1;
            this.lblEjecutar.Text = "Ejecutar";
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(164, 108);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(115, 23);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "Ejecutar Programa";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.button1_Click);
            // 
            // formBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 189);
            this.Controls.Add(this.panel1);
            this.Name = "formBuscar";
            this.Text = "Buscar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIDProceso;
        private System.Windows.Forms.Label lblEjecutar;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.HelpProvider hlp;
    }
}