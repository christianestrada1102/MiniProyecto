namespace MiniProyecto
{
    partial class FormRegistroUsuario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label labelEdad;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblMembresia;
        private System.Windows.Forms.TextBox txtMembresia;
        private System.Windows.Forms.Label labelInicio;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label labelFin;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Button btnGenerarQR;
        private System.Windows.Forms.PictureBox pictureBoxQR;
        private System.Windows.Forms.Label lblDiasRestantes;

        /// <summary> 
        /// Clean up resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroUsuario));
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.labelEdad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblMembresia = new System.Windows.Forms.Label();
            this.txtMembresia = new System.Windows.Forms.TextBox();
            this.labelInicio = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.labelFin = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarQR = new System.Windows.Forms.Button();
            this.pictureBoxQR = new System.Windows.Forms.PictureBox();
            this.lblDiasRestantes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNombre.Location = new System.Drawing.Point(31, 70);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(77, 23);
            this.lblNombre.TabIndex = 25;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(151, 68);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 30);
            this.txtNombre.TabIndex = 24;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblApellido.Location = new System.Drawing.Point(31, 110);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(76, 23);
            this.lblApellido.TabIndex = 23;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.Location = new System.Drawing.Point(151, 108);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(220, 30);
            this.txtApellido.TabIndex = 22;
            // 
            // labelEdad
            // 
            this.labelEdad.AutoSize = true;
            this.labelEdad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelEdad.Location = new System.Drawing.Point(31, 150);
            this.labelEdad.Name = "labelEdad";
            this.labelEdad.Size = new System.Drawing.Size(52, 23);
            this.labelEdad.TabIndex = 21;
            this.labelEdad.Text = "Edad:";
            // 
            // txtEdad
            // 
            this.txtEdad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEdad.Location = new System.Drawing.Point(151, 148);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(220, 30);
            this.txtEdad.TabIndex = 20;
            // 
            // lblMembresia
            // 
            this.lblMembresia.AutoSize = true;
            this.lblMembresia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMembresia.Location = new System.Drawing.Point(31, 190);
            this.lblMembresia.Name = "lblMembresia";
            this.lblMembresia.Size = new System.Drawing.Size(98, 23);
            this.lblMembresia.TabIndex = 19;
            this.lblMembresia.Text = "Membresía:";
            // 
            // txtMembresia
            // 
            this.txtMembresia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMembresia.Location = new System.Drawing.Point(151, 188);
            this.txtMembresia.Name = "txtMembresia";
            this.txtMembresia.Size = new System.Drawing.Size(220, 30);
            this.txtMembresia.TabIndex = 18;
            this.txtMembresia.TextChanged += new System.EventHandler(this.TxtMembresia_TextChanged);
            // 
            // labelInicio
            // 
            this.labelInicio.AutoSize = true;
            this.labelInicio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelInicio.Location = new System.Drawing.Point(31, 230);
            this.labelInicio.Name = "labelInicio";
            this.labelInicio.Size = new System.Drawing.Size(127, 23);
            this.labelInicio.TabIndex = 17;
            this.labelInicio.Text = "Fecha de inicio:";
            // 
            // dtInicio
            // 
            this.dtInicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(151, 228);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(220, 27);
            this.dtInicio.TabIndex = 16;
            this.dtInicio.ValueChanged += new System.EventHandler(this.DtInicio_ValueChanged);
            // 
            // labelFin
            // 
            this.labelFin.AutoSize = true;
            this.labelFin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelFin.Location = new System.Drawing.Point(31, 270);
            this.labelFin.Name = "labelFin";
            this.labelFin.Size = new System.Drawing.Size(106, 23);
            this.labelFin.TabIndex = 15;
            this.labelFin.Text = "Fecha de fin:";
            // 
            // dtFin
            // 
            this.dtFin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(151, 268);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(220, 27);
            this.dtFin.TabIndex = 14;
            this.dtFin.ValueChanged += new System.EventHandler(this.dtFin_ValueChanged);
            // 
            // btnGenerarQR
            // 
            this.btnGenerarQR.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGenerarQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarQR.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarQR.ForeColor = System.Drawing.Color.White;
            this.btnGenerarQR.Location = new System.Drawing.Point(31, 332);
            this.btnGenerarQR.Name = "btnGenerarQR";
            this.btnGenerarQR.Size = new System.Drawing.Size(340, 40);
            this.btnGenerarQR.TabIndex = 12;
            this.btnGenerarQR.Text = "Registrar y Generar QR";
            this.btnGenerarQR.UseVisualStyleBackColor = false;
            this.btnGenerarQR.Click += new System.EventHandler(this.btnGenerarQR_Click);
            // 
            // pictureBoxQR
            // 
            this.pictureBoxQR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxQR.Image = global::MiniProyecto.Properties.Resources.loadingggggg;
            this.pictureBoxQR.Location = new System.Drawing.Point(421, 68);
            this.pictureBoxQR.Name = "pictureBoxQR";
            this.pictureBoxQR.Size = new System.Drawing.Size(320, 304);
            this.pictureBoxQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxQR.TabIndex = 0;
            this.pictureBoxQR.TabStop = false;
            this.pictureBoxQR.Click += new System.EventHandler(this.pictureBoxQR_Click);
            // 
            // lblDiasRestantes
            // 
            this.lblDiasRestantes.AutoSize = true;
            this.lblDiasRestantes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiasRestantes.Location = new System.Drawing.Point(151, 304);
            this.lblDiasRestantes.Name = "lblDiasRestantes";
            this.lblDiasRestantes.Size = new System.Drawing.Size(115, 20);
            this.lblDiasRestantes.TabIndex = 13;
            this.lblDiasRestantes.Text = "Duración: 0 días";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(31, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormRegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(879, 441);
            this.Controls.Add(this.pictureBoxQR);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGenerarQR);
            this.Controls.Add(this.lblDiasRestantes);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
