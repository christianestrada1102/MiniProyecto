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
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            this.labelEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.labelInicio = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.labelFin = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            this.SuspendLayout();

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.Location = new System.Drawing.Point(30, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 19);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";

            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(130, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 25);
            this.txtNombre.TabIndex = 1;

            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApellido.Location = new System.Drawing.Point(30, 70);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(66, 19);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";

            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.Location = new System.Drawing.Point(130, 67);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 25);
            this.txtApellido.TabIndex = 3;

            // 
            // labelEdad
            // 
            this.labelEdad.AutoSize = true;
            this.labelEdad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelEdad.Location = new System.Drawing.Point(30, 110);
            this.labelEdad.Name = "labelEdad";
            this.labelEdad.Size = new System.Drawing.Size(42, 19);
            this.labelEdad.TabIndex = 4;
            this.labelEdad.Text = "Edad:";

            // 
            // txtEdad
            // 
            this.txtEdad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEdad.Location = new System.Drawing.Point(130, 107);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(200, 25);
            this.txtEdad.TabIndex = 5;

            // 
            // lblMembresia
            // 
            this.lblMembresia.AutoSize = true;
            this.lblMembresia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMembresia.Location = new System.Drawing.Point(30, 150);
            this.lblMembresia.Name = "lblMembresia";
            this.lblMembresia.Size = new System.Drawing.Size(82, 19);
            this.lblMembresia.TabIndex = 6;
            this.lblMembresia.Text = "Membresía:";

            // 
            // txtMembresia
            // 
            this.txtMembresia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMembresia.Location = new System.Drawing.Point(130, 147);
            this.txtMembresia.Name = "txtMembresia";
            this.txtMembresia.Size = new System.Drawing.Size(200, 25);
            this.txtMembresia.TabIndex = 7;

            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelInicio.Location = new System.Drawing.Point(30, 190);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(100, 19);
            this.labelInicio.TabIndex = 8;
            this.labelInicio.Text = "Fecha de inicio:";

            // 
            // dtInicio
            // 
            this.dtInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(130, 187);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(200, 23);
            this.dtInicio.TabIndex = 9;

            // 
            // labelFin
            // 
            this.labelFin.AutoSize = true;
            this.labelFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFin.Location = new System.Drawing.Point(30, 230);
            this.labelFin.Name = "labelFin";
            this.labelFin.Size = new System.Drawing.Size(87, 19);
            this.labelFin.TabIndex = 10;
            this.labelFin.Text = "Fecha de fin:";

            // 
            // dtFin
            // 
            this.dtFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(130, 227);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(200, 23);
            this.dtFin.TabIndex = 11;

            // 
            // btnGenerarQR
            // 
            this.btnGenerarQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenerarQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarQR.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarQR.ForeColor = System.Drawing.Color.White;
            this.btnGenerarQR.Location = new System.Drawing.Point(30, 270);
            this.btnGenerarQR.Name = "btnGenerarQR";
            this.btnGenerarQR.Size = new System.Drawing.Size(300, 40);
            this.btnGenerarQR.TabIndex = 12;
            this.btnGenerarQR.Text = "Registrar y Generar QR";
            this.btnGenerarQR.UseVisualStyleBackColor = false;
            this.btnGenerarQR.Click += new System.EventHandler(this.btnGenerarQR_Click);

            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxQR.Location = new System.Drawing.Point(370, 30);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(280, 280);
            this.pictureBoxQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxQR.TabIndex = 13;
            this.pictureBoxQR.TabStop = false;

            // 
            // FormRegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 340);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistroUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registro de Usuario";
            this.Load += new System.EventHandler(this.FormRegistroUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}