using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace QRprueba2
{
    public partial class ScanQR : Form
    {
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice fuenteVideo;
        private Timer temporizador;
        private bool procesando = false;

        public ScanQR()
        {
            InitializeComponent();
            CargarDispositivos();
        }

        private void CargarDispositivos()
        {
            try
            {
                dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo dispositivo in dispositivos)
                {
                    comboBox1.Items.Add(dispositivo.Name);
                }

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                else
                    MessageBox.Show("No se encontró ninguna cámara conectada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las cámaras: " + ex.Message);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuenteVideo == null || !fuenteVideo.IsRunning)
                {
                    if (comboBox1.SelectedIndex < 0)
                    {
                        MessageBox.Show("Por favor selecciona una cámara.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    fuenteVideo = new VideoCaptureDevice(dispositivos[comboBox1.SelectedIndex].MonikerString);
                    fuenteVideo.NewFrame += new NewFrameEventHandler(Captura);
                    fuenteVideo.Start();

                    temporizador = new Timer();
                    temporizador.Interval = 150;
                    temporizador.Tick += new EventHandler(Temporizador_Tick);
                    temporizador.Start();

                    lblResultado.Text = "Escaneando código QR...";
                    btnIniciar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar cámara: " + ex.Message);
            }
        }

        private void Captura(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();

                if (pictureBox1.InvokeRequired)
                {
                    pictureBox1.Invoke(new Action(() =>
                    {
                        if (pictureBox1.Image != null)
                            pictureBox1.Image.Dispose();
                        pictureBox1.Image = imagen;
                    }));
                }
                else
                {
                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    pictureBox1.Image = imagen;
                }
            }
            catch { }
        }

        private async void Temporizador_Tick(object sender, EventArgs e)
        {
            if (procesando) return; // evita doble lectura simultánea
            procesando = true;

            try
            {
                if (pictureBox1.Image != null)
                {
                    Bitmap imagenActual;

                    lock (pictureBox1)
                    {
                        imagenActual = new Bitmap(pictureBox1.Image);
                    }

                    Result resultado = await Task.Run(() =>
                    {
                        BarcodeReader lector = new BarcodeReader();
                        return lector.Decode(imagenActual);
                    });

                    imagenActual.Dispose();

                    if (resultado != null)
                    {
                        string codigoQR = resultado.Text;
                        Temporizador_Stop();

                        await ProcesarCodigoQR(codigoQR);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escanear: " + ex.Message);
                Temporizador_Stop();
            }
            finally
            {
                procesando = false;
            }
        }

        private async Task ProcesarCodigoQR(string codigoQR)
        {
            try
            {
                // Buscar usuario en la base de datos en un hilo aparte
                var usuario = await Task.Run(() => UsuarioDAO.BuscarUsuarioPorCodigo(codigoQR));

                this.Invoke((MethodInvoker)delegate
                {
                    if (usuario.Item1 != null && !string.IsNullOrEmpty(usuario.Item1))
                    {
                        // Intentar leer fechas desde la BD (formato flexible)
                        DateTime fechaInicio, fechaFin;

                        bool okInicio = DateTime.TryParse(usuario.Item5, out fechaInicio) ||
                                        DateTime.TryParseExact(usuario.Item5, new[] { "yyyy-MM-dd", "dd/MM/yyyy" },
                                        System.Globalization.CultureInfo.InvariantCulture,
                                        System.Globalization.DateTimeStyles.None, out fechaInicio);

                        bool okFin = DateTime.TryParse(usuario.Item6, out fechaFin) ||
                                     DateTime.TryParseExact(usuario.Item6, new[] { "yyyy-MM-dd", "dd/MM/yyyy" },
                                     System.Globalization.CultureInfo.InvariantCulture,
                                     System.Globalization.DateTimeStyles.None, out fechaFin);

                        if (!okInicio) fechaInicio = DateTime.Now.Date;
                        if (!okFin) fechaFin = fechaInicio.AddMonths(1);

                        // Calcular duración total (inicio a fin)
                        int duracionTotal = (int)(fechaFin.Date - fechaInicio.Date).TotalDays;
                        if (duracionTotal < 0) duracionTotal = 0;

                        // Calcular días restantes (desde hoy hasta fin)
                        int diasRestantes = (int)(fechaFin.Date - DateTime.Now.Date).TotalDays;
                        int diasRestantesMostrar = Math.Max(diasRestantes, 0);

                        // Mostrar información sin hora y con diferencia de días
                        string info = $"✅ USUARIO ENCONTRADO\n\n" +
                                      $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                                      $"👤 Nombre: {usuario.Item1} {usuario.Item2}\n" +
                                      $"🎂 Edad: {usuario.Item3} años\n" +
                                      $"💳 Membresía: {usuario.Item4}\n" +
                                      $"📅 Inicio: {fechaInicio:dd/MM/yyyy}\n" +
                                      $"📅 Fin: {fechaFin:dd/MM/yyyy}\n" +
                                      $"📏 Duración total: {duracionTotal} días\n" +
                                      $"⏳ Días restantes: {diasRestantesMostrar} días\n" +
                                      $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                                      $"🔑 Código QR: {codigoQR}";

                        MessageBox.Show(info, "✅ Información del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblResultado.Text = $"✅ Usuario: {usuario.Item1} {usuario.Item2}";
                    }
                    else
                    {
                        string mensaje = $"❌ NO ENCONTRADO\n\n" +
                                         $"No se encontró ningún usuario\n" +
                                         $"con el código QR:\n\n" +
                                         $"{codigoQR}\n\n" +
                                         $"Por favor verifica que el usuario\n" +
                                         $"esté registrado en la base de datos.";

                        MessageBox.Show(mensaje, "❌ Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblResultado.Text = "❌ Usuario no encontrado";
                    }

                    btnIniciar.Enabled = true;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar QR: " + ex.Message);
            }
        }

        private void Temporizador_Stop()
        {
            try
            {
                if (temporizador != null)
                {
                    temporizador.Stop();
                    temporizador.Dispose();
                }

                if (fuenteVideo != null && fuenteVideo.IsRunning)
                {
                    fuenteVideo.SignalToStop();
                    fuenteVideo.WaitForStop();
                }
            }
            catch { }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormRegistroUsuario frm = new FormRegistroUsuario())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Temporizador_Stop();

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }

            base.OnFormClosing(e);
        }
    }
}
