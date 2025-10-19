using System;
using System.Drawing;
using System.Windows.Forms;
using QRCoder;

namespace QRprueba2
{
    public partial class FormRegistroUsuario : Form
    {
        private bool _ejecutandoEvento = false; // evita ejecuciones múltiples del mismo evento

        public FormRegistroUsuario()
        {
            InitializeComponent();

            // Conectar eventos de forma segura (evita duplicados si ya están en el designer)
            // Usamos -= antes de += para asegurarnos de no tener múltiples suscripciones
            btnGenerarQR.Click -= btnGenerarQR_Click;
            btnGenerarQR.Click += btnGenerarQR_Click;

            txtMembresia.TextChanged -= TxtMembresia_TextChanged;
            txtMembresia.TextChanged += TxtMembresia_TextChanged;

            // Si en vez de TextBox usas ComboBox para membresía, el SelectedIndexChanged también se conecta
            try
            {
                var combo = this.Controls["txtMembresia"] as ComboBox;
                if (combo != null)
                {
                    combo.SelectedIndexChanged -= ComboMembresia_SelectedIndexChanged;
                    combo.SelectedIndexChanged += ComboMembresia_SelectedIndexChanged;
                }
            }
            catch { /* si no existe, no importa */ }

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

        // Si txtMembresia es TextBox
        private void TxtMembresia_TextChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        // Si txtMembresia es ComboBox (por si cambias a combo)
        private void ComboMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // actualizar texto del control para reutilizar la misma lógica
            if (sender is ComboBox cb)
                txtMembresia.Text = cb.Text;

            CalcularFechaFin();
        }

        private void DtInicio_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        private void CalcularFechaFin()
        {
            try
            {
                string membresia = (txtMembresia?.Text ?? "").Trim().ToLower();
                DateTime fechaInicio = dtInicio.Value.Date;
                DateTime fechaFin = fechaInicio;

                // Detecta las palabras clave aunque el usuario escriba parcial
                if (membresia.Contains("día") || membresia.Contains("dia"))
                {
                    fechaFin = fechaInicio.AddDays(1);
                }
                else if (membresia.Contains("semana"))
                {
                    fechaFin = fechaInicio.AddDays(7);
                }
                else if (membresia.Contains("mes"))
                {
                    fechaFin = fechaInicio.AddMonths(1);
                }
                else if (membresia.Contains("año") || membresia.Contains("ano"))
                {
                    fechaFin = fechaInicio.AddYears(1);
                }
                else
                {
                    // Por defecto 1 mes si no reconoce
                    fechaFin = fechaInicio.AddMonths(1);
                }

                // Actualizar dtFin de forma segura en UI thread
                if (dtFin.InvokeRequired)
                {
                    dtFin.Invoke(new Action(() => dtFin.Value = fechaFin));
                }
                else
                {
                    dtFin.Value = fechaFin;
                }

                // Duración total entre inicio y fin (días)
                int duracionTotal = (int)(fechaFin.Date - fechaInicio.Date).TotalDays;
                if (duracionTotal < 0) duracionTotal = 0;

                // Días restantes desde hoy hasta fin
                int diasRestantes = (int)(fechaFin.Date - DateTime.Now.Date).TotalDays;
                int diasMostrar = Math.Max(diasRestantes, 0);

                if (lblDiasRestantes != null)
                {
                    lblDiasRestantes.Text = $"Duración: {duracionTotal} días | Restan: {diasMostrar} días";
                }
            }
            catch
            {
                // evita excepciones si el usuario escribe muy rápido
            }
        }

        private void btnGenerarQR_Click(object sender, EventArgs e)
        {
            // Evita que el método se ejecute varias veces por doble-click o suscripciones duplicadas
            if (_ejecutandoEvento) return;
            _ejecutandoEvento = true;

            try
            {
                // Validaciones
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtEdad.Text) ||
                    string.IsNullOrWhiteSpace(txtMembresia.Text))
                {
                    MessageBox.Show("⚠️ Por favor completa todos los campos.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtEdad.Text, out int edad) || edad <= 0 || edad > 120)
                {
                    MessageBox.Show("⚠️ Por favor ingresa una edad válida.", "Edad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asegurarse que la fecha de fin esté actualizada
                CalcularFechaFin();

                // Crear código QR único
                string codigoQR = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

                // Generar imagen QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(codigoQR, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(20);

                // Mostrar el QR
                pictureBoxQR.Image = qrImage;

                // Preparar datos para la BD
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string membresia = txtMembresia.Text.Trim();
                string edadStr = txtEdad.Text.Trim();
                string fechaInicio = dtInicio.Value.Date.ToString("yyyy-MM-dd");
                string fechaFin = dtFin.Value.Date.ToString("yyyy-MM-dd");

                bool insertado = UsuarioDAO.InsertarUsuario(nombre, apellido, membresia, edadStr, fechaInicio, fechaFin, codigoQR);

                if (insertado)
                {
                    // Guardar QR en escritorio (no interrumpe si falla)
                    try
                    {
                        string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string nombreArchivo = $"QR_{nombre}_{apellido}_{codigoQR}.png";
                        string rutaCompleta = System.IO.Path.Combine(rutaEscritorio, nombreArchivo);
                        pictureBoxQR.Image.Save(rutaCompleta);
                    }
                    catch { }

                    // Solo mostrar mensaje de éxito (como pediste)
                    MessageBox.Show("✅ Usuario registrado correctamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar campos (mantener QR visible)
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
                    MessageBox.Show("❌ No se pudo registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al generar QR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _ejecutandoEvento = false;
            }
        }
    }
}
