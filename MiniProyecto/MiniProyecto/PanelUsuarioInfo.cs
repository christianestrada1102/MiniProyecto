using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniProyecto
{
    public class PanelUsuarioInfo : UserControl
    {
        private Label lblTitulo;
        private Label lblNombre;
        private Label lblEdad;
        private Label lblMembresia;
        private Label lblInicio;
        private Label lblFin;
        private Label lblDuracion;
        private Label lblRestantes;
        private Label lblCodigoQR;
        private PictureBox pictureBoxEstado;

        public PanelUsuarioInfo()
        {
            InitializeComponent();
            MostrarEstadoInicial();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configurar el panel principal
            this.BackColor = Color.White;
            this.Size = new Size(700, 600);
            this.Padding = new Padding(40);

            // Título
            lblTitulo = new Label
            {
                Text = "INFORMACIÓN DEL USUARIO",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 162, 184),
                AutoSize = false,
                Size = new Size(620, 50),
                Location = new Point(40, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // PictureBox para ícono de estado
            pictureBoxEstado = new PictureBox
            {
                Size = new Size(100, 100),
                Location = new Point(300, 120),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Labels de información
            lblNombre = CrearLabel("👤 Nombre: ", 240);
            lblEdad = CrearLabel("🎂 Edad: ", 290);
            lblMembresia = CrearLabel("💳 Membresía: ", 340);
            lblInicio = CrearLabel("📅 Inicio: ", 390);
            lblFin = CrearLabel("📅 Fin: ", 440);
            lblDuracion = CrearLabel("📏 Duración: ", 490);
            lblRestantes = CrearLabel("⏳ Días restantes: ", 540);
            lblCodigoQR = CrearLabel("🔑 Código QR: ", 590);

            // Agregar controles
            this.Controls.Add(lblTitulo);
            this.Controls.Add(pictureBoxEstado);
            this.Controls.Add(lblNombre);
            this.Controls.Add(lblEdad);
            this.Controls.Add(lblMembresia);
            this.Controls.Add(lblInicio);
            this.Controls.Add(lblFin);
            this.Controls.Add(lblDuracion);
            this.Controls.Add(lblRestantes);
            this.Controls.Add(lblCodigoQR);

            this.ResumeLayout();
        }

        private Label CrearLabel(string prefijo, int y)
        {
            return new Label
            {
                Text = prefijo + "---",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(52, 58, 64),
                AutoSize = false,
                Size = new Size(620, 30),
                Location = new Point(40, y),
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        public void MostrarEstadoInicial()
        {
            lblTitulo.Text = "ESCANEA UN CÓDIGO QR";
            lblTitulo.ForeColor = Color.Gray;

            // Ocultar ícono
            pictureBoxEstado.Visible = false;

            lblNombre.Text = "👤 Nombre: ---";
            lblEdad.Text = "🎂 Edad: ---";
            lblMembresia.Text = "💳 Membresía: ---";
            lblInicio.Text = "📅 Inicio: ---";
            lblFin.Text = "📅 Fin: ---";
            lblDuracion.Text = "📏 Duración: ---";
            lblRestantes.Text = "⏳ Días restantes: ---";
            lblCodigoQR.Text = "🔑 Código QR: ---";
        }

        public void MostrarUsuario(string nombre, string apellido, string edad, string membresia,
                                   DateTime fechaInicio, DateTime fechaFin, string codigoQR)
        {
            lblTitulo.Text = "✅ USUARIO ENCONTRADO";
            lblTitulo.ForeColor = Color.FromArgb(40, 167, 69);

            pictureBoxEstado.Visible = true;
            // Aquí puedes agregar un ícono de éxito si tienes uno en recursos

            int duracionTotal = Math.Max(0, (int)(fechaFin - fechaInicio).TotalDays);
            int diasRestantes = Math.Max(0, (int)(fechaFin - DateTime.Now.Date).TotalDays);

            lblNombre.Text = $"👤 Nombre: {nombre} {apellido}";
            lblEdad.Text = $"🎂 Edad: {edad} años";
            lblMembresia.Text = $"💳 Membresía: {membresia}";
            lblInicio.Text = $"📅 Inicio: {fechaInicio:dd/MM/yyyy}";
            lblFin.Text = $"📅 Fin: {fechaFin:dd/MM/yyyy}";
            lblDuracion.Text = $"📏 Duración: {duracionTotal} días";
            lblRestantes.Text = $"⏳ Días restantes: {diasRestantes} días";
            lblCodigoQR.Text = $"🔑 Código QR: {codigoQR}";

            // Cambiar color según días restantes
            if (diasRestantes <= 0)
            {
                lblRestantes.ForeColor = Color.Red;
                lblRestantes.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            }
            else if (diasRestantes <= 7)
            {
                lblRestantes.ForeColor = Color.Orange;
                lblRestantes.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            }
            else
            {
                lblRestantes.ForeColor = Color.Green;
            }
        }

        public void MostrarNoEncontrado(string codigoQR)
        {
            lblTitulo.Text = "❌ USUARIO NO ENCONTRADO";
            lblTitulo.ForeColor = Color.FromArgb(220, 53, 69);

            pictureBoxEstado.Visible = false;

            lblNombre.Text = "👤 Nombre: No encontrado";
            lblEdad.Text = "🎂 Edad: ---";
            lblMembresia.Text = "💳 Membresía: ---";
            lblInicio.Text = "📅 Inicio: ---";
            lblFin.Text = "📅 Fin: ---";
            lblDuracion.Text = "📏 Duración: ---";
            lblRestantes.Text = "⏳ Días restantes: ---";
            lblCodigoQR.Text = $"🔑 Código QR escaneado: {codigoQR}";
        }
    }
}