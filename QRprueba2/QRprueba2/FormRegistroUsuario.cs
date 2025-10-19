using System;
using System.Drawing;
using System.Windows.Forms;
using QRCoder;

namespace QRprueba2
{
    public partial class FormRegistroUsuario : Form
    {
        public FormRegistroUsuario()
        {
            InitializeComponent();
        }

        private void btnGenerarQR_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtEdad.Text) ||
                    string.IsNullOrWhiteSpace(txtMembresia.Text))
                {
                    MessageBox.Show("⚠️ Por favor completa todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que la edad sea un número
                if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0 || edad > 120)
                {
                    MessageBox.Show("⚠️ Por favor ingresa una edad válida.", "Edad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Generar un código QR único usando GUID
                string codigoQR = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                // Generar el código QR visual
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(codigoQR, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                // Mostrar el QR en el PictureBox
                pictureBoxQR.Image = qrCodeImage;

                // Guardar en la base de datos
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string membresia = txtMembresia.Text.Trim();
                string edadStr = txtEdad.Text.Trim();
                string fechaInicio = dtInicio.Value.ToString("yyyy-MM-dd");
                string fechaFin = dtFin.Value.ToString("yyyy-MM-dd");

                bool insertado = UsuarioDAO.InsertarUsuario(nombre, apellido, membresia, edadStr, fechaInicio, fechaFin, codigoQR);

                if (insertado)
                {
                    // Guardar automáticamente el QR en el escritorio
                    string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string nombreArchivo = $"QR_{nombre}_{apellido}_{codigoQR}.png";
                    string rutaCompleta = System.IO.Path.Combine(rutaEscritorio, nombreArchivo);

                    pictureBoxQR.Image.Save(rutaCompleta);

                    // MANTENER EL QR VISIBLE - Solo limpiar los campos de texto
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtEdad.Clear();
                    txtMembresia.Clear();
                    dtInicio.Value = DateTime.Now;
                    CalcularFechaFin(); // Recalcular la fecha de fin
                }
                else
                {
                    pictureBoxQR.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al generar QR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMembresia_TextChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private void dtInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private void CalcularFechaFin()
        {
            string membresia = txtMembresia.Text.Trim().ToLower();
            DateTime fechaInicio = dtInicio.Value;
            DateTime fechaFin = fechaInicio;

            switch (membresia)
            {
                case "dia":
                case "día":
                    fechaFin = fechaInicio.AddDays(1);
                    break;
                case "semana":
                    fechaFin = fechaInicio.AddDays(7);
                    break;
                case "mes":
                    fechaFin = fechaInicio.AddMonths(1);
                    break;
                case "año":
                case "ano":
                    fechaFin = fechaInicio.AddYears(1);
                    break;
                default:
                    fechaFin = fechaInicio.AddMonths(1); // Por defecto 1 mes
                    break;
            }

            dtFin.Value = fechaFin;

            // Calcular días restantes
            TimeSpan diferencia = fechaFin - fechaInicio;
            int diasRestantes = (int)diferencia.TotalDays;

            // Actualizar el label con los días restantes (si existe)
            if (lblDiasRestantes != null)
            {
                lblDiasRestantes.Text = $"Duración: {diasRestantes} días";
            }
        }

        private void FormRegistroUsuario_Load(object sender, EventArgs e)
        {
            // Configurar valores iniciales
            dtInicio.Value = DateTime.Now;
            dtFin.Value = DateTime.Now.AddMonths(1);
            dtFin.Enabled = false; // Deshabilitar edición manual

            // Calcular fecha de fin inicial
            CalcularFechaFin();
        }
    }
}