namespace MiniProyecto
{
    partial class Registro
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
            this.nombretb = new System.Windows.Forms.TextBox();
            this.apellidotb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Fecha = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rdsem = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdano = new System.Windows.Forms.RadioButton();
            this.rdmes = new System.Windows.Forms.RadioButton();
            this.lblVigencia = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.fechaNac = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nombretb
            // 
            this.nombretb.Location = new System.Drawing.Point(179, 47);
            this.nombretb.Name = "nombretb";
            this.nombretb.Size = new System.Drawing.Size(100, 22);
            this.nombretb.TabIndex = 0;
            this.nombretb.TextChanged += new System.EventHandler(this.nombretb_TextChanged);
            // 
            // apellidotb
            // 
            this.apellidotb.Location = new System.Drawing.Point(179, 93);
            this.apellidotb.Name = "apellidotb";
            this.apellidotb.Size = new System.Drawing.Size(100, 22);
            this.apellidotb.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(595, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Membresia";
            // 
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Location = new System.Drawing.Point(25, 149);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(93, 16);
            this.Fecha.TabIndex = 7;
            this.Fecha.Text = "Fecha registro";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(168, 149);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 22);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // rdsem
            // 
            this.rdsem.AutoSize = true;
            this.rdsem.Location = new System.Drawing.Point(6, 30);
            this.rdsem.Name = "rdsem";
            this.rdsem.Size = new System.Drawing.Size(79, 20);
            this.rdsem.TabIndex = 10;
            this.rdsem.TabStop = true;
            this.rdsem.Text = "Semana";
            this.rdsem.UseVisualStyleBackColor = true;
            this.rdsem.CheckedChanged += new System.EventHandler(this.rdsem_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdano);
            this.groupBox1.Controls.Add(this.rdmes);
            this.groupBox1.Controls.Add(this.rdsem);
            this.groupBox1.Location = new System.Drawing.Point(546, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 119);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones de membresia";
            // 
            // rdano
            // 
            this.rdano.AutoSize = true;
            this.rdano.Location = new System.Drawing.Point(7, 84);
            this.rdano.Name = "rdano";
            this.rdano.Size = new System.Drawing.Size(51, 20);
            this.rdano.TabIndex = 12;
            this.rdano.TabStop = true;
            this.rdano.Text = "año";
            this.rdano.UseVisualStyleBackColor = true;
            // 
            // rdmes
            // 
            this.rdmes.AutoSize = true;
            this.rdmes.Location = new System.Drawing.Point(7, 57);
            this.rdmes.Name = "rdmes";
            this.rdmes.Size = new System.Drawing.Size(54, 20);
            this.rdmes.TabIndex = 11;
            this.rdmes.TabStop = true;
            this.rdmes.Text = "Mes";
            this.rdmes.UseVisualStyleBackColor = true;
            // 
            // lblVigencia
            // 
            this.lblVigencia.AutoSize = true;
            this.lblVigencia.Location = new System.Drawing.Point(450, 235);
            this.lblVigencia.Name = "lblVigencia";
            this.lblVigencia.Size = new System.Drawing.Size(0, 16);
            this.lblVigencia.TabIndex = 12;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(76, 291);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Registrar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Fecha nacimiento";
            // 
            // fechaNac
            // 
            this.fechaNac.Location = new System.Drawing.Point(168, 203);
            this.fechaNac.Name = "fechaNac";
            this.fechaNac.Size = new System.Drawing.Size(244, 22);
            this.fechaNac.TabIndex = 15;
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fechaNac);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblVigencia);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Fecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apellidotb);
            this.Controls.Add(this.nombretb);
            this.Name = "Registro";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Registro_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nombretb;
        private System.Windows.Forms.TextBox apellidotb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Fecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rdsem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdano;
        private System.Windows.Forms.RadioButton rdmes;
        private System.Windows.Forms.Label lblVigencia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechaNac;
    }
}