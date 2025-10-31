using System;
using System.Drawing;
using System.Windows.Forms;
using QRCoder;

namespace MiniProyecto
{
    public partial class FormRegistroUsuario : Form
    {
        private bool _ejecutandoEvento = false;
        private ConexionBD bd = new ConexionBD(); //para USAR ConexionBD

        public FormRegistroUsuario()
        {
            InitializeComponent();

            //Conectar eventos de forma segura
            btnGenerarQR.Click -= btnGenerarQR_Click;
            btnGenerarQR.Click += btnGenerarQR_Click;

            txtMembresia.TextChanged -= TxtMembresia_TextChanged;
            txtMembresia.TextChanged += TxtMembresia_TextChanged;

            dtInicio.ValueChanged -= DtInicio_ValueChanged;
            dtInicio.ValueChanged += DtInicio_ValueChanged;

            this.Load -= FormRegistroUsuario_Load;
            this.Load += FormRegistroUsuario_Load;
        }

        private void FormRegistroUsuario_Load(object sender, EventArgs e)
        {
            dtInicio.Value = DateTime.Now.Date;
            dtFin.Value = DateTime.Now.Date.AddMonths(1);
            dtFin.Enabled = false;
            CalcularFechaFin();
        }

        private void TxtMembresia_TextChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private void DtInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private bool ValidarMembresia(string membresia)
        {
            string membresiaLower = membresia.Trim().ToLower();

            return membresiaLower == "dia" ||
                   membresiaLower == "día" ||
                   membresiaLower == "semana" ||
                   membresiaLower == "mes" ||
                   membresiaLower == "año" ||
                   membresiaLower == "ano";
        }

        private void CalcularFechaFin()
        {
            try
            {
                string membresia = (txtMembresia?.Text ?? "").Trim().ToLower();
                DateTime fechaInicio = dtInicio.Value.Date;
                DateTime fechaFin = fechaInicio;

                if (membresia == "día" || membresia == "dia")
                {
                    fechaFin = fechaInicio.AddDays(1);
                }
                else if (membresia == "semana")
                {
                    fechaFin = fechaInicio.AddDays(7);
                }
                else if (membresia == "mes")
                {
                    fechaFin = fechaInicio.AddMonths(1);
                }
                else if (membresia == "año" || membresia == "ano")
                {
                    fechaFin = fechaInicio.AddYears(1);
                }
                else
                {
                    fechaFin = fechaInicio.AddMonths(1);
                }

                if (dtFin.InvokeRequired)
                {
                    dtFin.Invoke(new Action(() => dtFin.Value = fechaFin));
                }
                else
                {
                    dtFin.Value = fechaFin;
                }

                int duracionTotal = (int)(fechaFin.Date - fechaInicio.Date).TotalDays;
                if (duracionTotal < 0) duracionTotal = 0;

                int diasRestantes = (int)(fechaFin.Date - DateTime.Now.Date).TotalDays;
                int diasMostrar = Math.Max(diasRestantes, 0);

                if (lblDiasRestantes != null)
                {
                    lblDiasRestantes.Text = $"Duración de la membresia: {duracionTotal} días en total | Restan: {diasMostrar} días para que acabe la membresia";
                }
            }
            catch { }
        }

        private void btnGenerarQR_Click(object sender, EventArgs e)
        {
            if (_ejecutandoEvento) return;
            _ejecutandoEvento = true;

            try
            {
                //Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtEdad.Text) ||
                    string.IsNullOrWhiteSpace(txtMembresia.Text))
                {
                    MessageBox.Show("¡¡¡ Por favor completa todos los campos.", "Campos Vacíos por completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Validar edad
                if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0 || edad > 120)
                {
                    MessageBox.Show(" ERROR !!! Por favor ingresa una edad válida.", "Edad Inválida vuelve a intentar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Validar membresía
                if (!ValidarMembresia(txtMembresia.Text))
                {
                    MessageBox.Show("¡¡¡ Membresía inválida.\n\nSolo se permiten:\n• dia\n• semana\n• mes\n• año",
                                    "Membresía Inválida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    txtMembresia.Focus();
                    return;
                }

                //Asegurarse que la fecha de fin esté actualizada
                CalcularFechaFin();

                //Crear código QR único
                string codigoQR = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                //Generar imagen QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(codigoQR, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(20);

                //Mostrar el QR
                pictureBoxQR.Image = qrImage;

                //Preparar datos para la BD
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string membresia = txtMembresia.Text.Trim().ToLower();
                DateTime fechaInicio = dtInicio.Value.Date;
                DateTime fechaFin = dtFin.Value.Date;

                //USAR ConexionBD en lugar de UsuarioDAO
                bool insertado = bd.InsertarUsuario(nombre, apellido, edad, fechaInicio, fechaFin, membresia, codigoQR);

                if (insertado)
                {
                    //Guardar QR en Downloads/QR
                    string nombreArchivo = $"QR_{nombre}_{apellido}_{codigoQR}";
                    string rutaGuardada = GenerarQR.GuardarQR(qrImage, nombreArchivo);

                    if (rutaGuardada != null)
                    {
                        MessageBox.Show($" ¡LISTO! Usuario registrado correctamente.\n\n CORRECTO! QR guardado en:\n{rutaGuardada}",
                                        "Registro Exitoso!!",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }

                    //Limpiar campos (mantener QR visible)
                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtEdad.Clear();
                    txtMembresia.Clear();
                    dtInicio.Value = DateTime.Now.Date;
                    CalcularFechaFin();
                }
                else
                {
                    pictureBoxQR.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" ¡¡¡ Error al generar QR: " + ex.Message, "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _ejecutandoEvento = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dtInicio_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dtFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxQR_Click(object sender, EventArgs e)
        {

        }
    }
}