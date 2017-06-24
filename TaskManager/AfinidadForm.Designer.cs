namespace TaskManager
{
    partial class AfinidadForm
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
            this.lblAfinidad = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCantidadProcesadores = new System.Windows.Forms.Label();
            this.cBox3 = new System.Windows.Forms.CheckBox();
            this.cBox2 = new System.Windows.Forms.CheckBox();
            this.cBox1 = new System.Windows.Forms.CheckBox();
            this.cBox0 = new System.Windows.Forms.CheckBox();
            this.cBoxTodos = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAfinidad
            // 
            this.lblAfinidad.AutoSize = true;
            this.lblAfinidad.Location = new System.Drawing.Point(24, 9);
            this.lblAfinidad.Name = "lblAfinidad";
            this.lblAfinidad.Size = new System.Drawing.Size(35, 13);
            this.lblAfinidad.TabIndex = 0;
            this.lblAfinidad.Text = "label1";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(27, 246);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(108, 246);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lblCantidadProcesadores);
            this.panel1.Controls.Add(this.cBox3);
            this.panel1.Controls.Add(this.cBox2);
            this.panel1.Controls.Add(this.cBox1);
            this.panel1.Controls.Add(this.cBox0);
            this.panel1.Controls.Add(this.cBoxTodos);
            this.panel1.Location = new System.Drawing.Point(27, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 171);
            this.panel1.TabIndex = 3;
            // 
            // lblCantidadProcesadores
            // 
            this.lblCantidadProcesadores.AutoSize = true;
            this.lblCantidadProcesadores.Location = new System.Drawing.Point(14, 11);
            this.lblCantidadProcesadores.Name = "lblCantidadProcesadores";
            this.lblCantidadProcesadores.Size = new System.Drawing.Size(35, 13);
            this.lblCantidadProcesadores.TabIndex = 5;
            this.lblCantidadProcesadores.Text = "label1";
            // 
            // cBox3
            // 
            this.cBox3.AutoSize = true;
            this.cBox3.Checked = true;
            this.cBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox3.Location = new System.Drawing.Point(17, 125);
            this.cBox3.Name = "cBox3";
            this.cBox3.Size = new System.Drawing.Size(57, 17);
            this.cBox3.TabIndex = 4;
            this.cBox3.Text = "CPU 3";
            this.cBox3.UseVisualStyleBackColor = true;
            this.cBox3.CheckedChanged += new System.EventHandler(this.cBox3_CheckedChanged);
            // 
            // cBox2
            // 
            this.cBox2.AutoSize = true;
            this.cBox2.Checked = true;
            this.cBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox2.Location = new System.Drawing.Point(17, 102);
            this.cBox2.Name = "cBox2";
            this.cBox2.Size = new System.Drawing.Size(57, 17);
            this.cBox2.TabIndex = 3;
            this.cBox2.Text = "CPU 2";
            this.cBox2.UseVisualStyleBackColor = true;
            this.cBox2.CheckedChanged += new System.EventHandler(this.cBox2_CheckedChanged);
            // 
            // cBox1
            // 
            this.cBox1.AutoSize = true;
            this.cBox1.Checked = true;
            this.cBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox1.Location = new System.Drawing.Point(17, 79);
            this.cBox1.Name = "cBox1";
            this.cBox1.Size = new System.Drawing.Size(57, 17);
            this.cBox1.TabIndex = 2;
            this.cBox1.Text = "CPU 1";
            this.cBox1.UseVisualStyleBackColor = true;
            this.cBox1.CheckedChanged += new System.EventHandler(this.cBox1_CheckedChanged);
            // 
            // cBox0
            // 
            this.cBox0.AutoSize = true;
            this.cBox0.Checked = true;
            this.cBox0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox0.Location = new System.Drawing.Point(17, 56);
            this.cBox0.Name = "cBox0";
            this.cBox0.Size = new System.Drawing.Size(57, 17);
            this.cBox0.TabIndex = 1;
            this.cBox0.Text = "CPU 0";
            this.cBox0.UseVisualStyleBackColor = true;
            this.cBox0.CheckedChanged += new System.EventHandler(this.cBox0_CheckedChanged);
            // 
            // cBoxTodos
            // 
            this.cBoxTodos.AutoSize = true;
            this.cBoxTodos.Checked = true;
            this.cBoxTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxTodos.Location = new System.Drawing.Point(17, 33);
            this.cBoxTodos.Name = "cBoxTodos";
            this.cBoxTodos.Size = new System.Drawing.Size(114, 17);
            this.cBoxTodos.TabIndex = 0;
            this.cBoxTodos.Text = "Todos los Nucleos";
            this.cBoxTodos.UseVisualStyleBackColor = true;
            this.cBoxTodos.CheckedChanged += new System.EventHandler(this.cBoxTodos_CheckedChanged);
            // 
            // AfinidadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 296);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblAfinidad);
            this.Name = "AfinidadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Afinidad del procesador";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAfinidad;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cBox3;
        private System.Windows.Forms.CheckBox cBox2;
        private System.Windows.Forms.CheckBox cBox1;
        private System.Windows.Forms.CheckBox cBox0;
        private System.Windows.Forms.CheckBox cBoxTodos;
        private System.Windows.Forms.Label lblCantidadProcesadores;
    }
}