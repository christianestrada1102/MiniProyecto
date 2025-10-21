namespace QRprueba2
{
    partial class FormRegistroUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblMembresia;
        private System.Windows.Forms.TextBox txtMembresia;
        private System.Windows.Forms.Button btnGenerarQR;
        private System.Windows.Forms.PictureBox pictureBoxQR;
        private System.Windows.Forms.Label labelEdad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label labelFin;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label lblDiasRestantes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblMembresia = new System.Windows.Forms.Label();
            this.txtMembresia = new System.Windows.Forms.TextBox();
            this.btnGenerarQR = new System.Windows.Forms.Button();
            this.labelEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.labelInicio = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.labelFin = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.Location = new System.Drawing.Point(58, 31);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(77, 23);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(187, 28);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(228, 30);
            this.txtNombre.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApellido.Location = new System.Drawing.Point(59, 71);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(76, 23);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.Location = new System.Drawing.Point(187, 71);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(228, 30);
            this.txtApellido.TabIndex = 3;
            // 
            // lblMembresia
            // 
            this.lblMembresia.AutoSize = true;
            this.lblMembresia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMembresia.Location = new System.Drawing.Point(59, 163);
            this.lblMembresia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMembresia.Name = "lblMembresia";
            this.lblMembresia.Size = new System.Drawing.Size(98, 23);
            this.lblMembresia.TabIndex = 6;
            this.lblMembresia.Text = "Membresía:";
            // 
            // txtMembresia
            // 
            this.txtMembresia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMembresia.Location = new System.Drawing.Point(187, 156);
            this.txtMembresia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMembresia.Name = "txtMembresia";
            this.txtMembresia.Size = new System.Drawing.Size(228, 30);
            this.txtMembresia.TabIndex = 7;
            // 
            // btnGenerarQR
            // 
            this.btnGenerarQR.BackColor = System.Drawing.Color.Firebrick;
            this.btnGenerarQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarQR.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarQR.ForeColor = System.Drawing.Color.White;
            this.btnGenerarQR.Location = new System.Drawing.Point(74, 288);
            this.btnGenerarQR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerarQR.Name = "btnGenerarQR";
            this.btnGenerarQR.Size = new System.Drawing.Size(343, 43);
            this.btnGenerarQR.TabIndex = 12;
            this.btnGenerarQR.Text = "Registrar y Generar QR";
            this.btnGenerarQR.UseVisualStyleBackColor = false;
            this.btnGenerarQR.Click += new System.EventHandler(this.btnGenerarQR_Click);
            // 
            // labelEdad
            // 
            this.labelEdad.AutoSize = true;
            this.labelEdad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelEdad.Location = new System.Drawing.Point(59, 117);
            this.labelEdad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEdad.Name = "labelEdad";
            this.labelEdad.Size = new System.Drawing.Size(52, 23);
            this.labelEdad.TabIndex = 4;
            this.labelEdad.Text = "Edad:";
            // 
            // txtEdad
            // 
            this.txtEdad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEdad.Location = new System.Drawing.Point(187, 114);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(228, 30);
            this.txtEdad.TabIndex = 5;
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelInicio.Location = new System.Drawing.Point(59, 203);
            this.labelInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(127, 23);
            this.labelInicio.TabIndex = 8;
            this.labelInicio.Text = "Fecha de inicio:";
            // 
            // dtInicio
            // 
            this.dtInicio.AllowDrop = true;
            this.dtInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(187, 199);
            this.dtInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(228, 27);
            this.dtInicio.TabIndex = 9;
            this.dtInicio.ValueChanged += new System.EventHandler(this.dtInicio_ValueChanged_1);
            // 
            // labelFin
            // 
            this.labelFin.AutoSize = true;
            this.labelFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFin.Location = new System.Drawing.Point(59, 245);
            this.labelFin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFin.Name = "labelFin";
            this.labelFin.Size = new System.Drawing.Size(106, 23);
            this.labelFin.TabIndex = 10;
            this.labelFin.Text = "Fecha de fin:";
            // 
            // dtFin
            // 
            this.dtFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(187, 242);
            this.dtFin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(228, 27);
            this.dtFin.TabIndex = 11;
            this.dtFin.ValueChanged += new System.EventHandler(this.dtFin_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::QRprueba2.Properties.Resources.image_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.AccessibleRole = System.Windows.Forms.AccessibleRole.Animation;
            this.pictureBoxQR.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxQR.Image = global::QRprueba2.Properties.Resources.loading;
            this.pictureBoxQR.Location = new System.Drawing.Point(425, 32);
            this.pictureBoxQR.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(319, 299);
            this.pictureBoxQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxQR.TabIndex = 13;
            this.pictureBoxQR.TabStop = false;
            this.pictureBoxQR.Click += new System.EventHandler(this.pictureBoxQR_Click);
            // 
            // FormRegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(795, 380);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBoxQR);
            this.Controls.Add(this.btnGenerarQR);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.labelFin);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.labelInicio);
            this.Controls.Add(this.txtMembresia);
            this.Controls.Add(this.lblMembresia);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.labelEdad);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistroUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de Usuario";
            this.Load += new System.EventHandler(this.FormRegistroUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}