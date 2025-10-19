using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace QRprueba2
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection dispositivos;
        private VideoCaptureDevice fuenteVideo;
        private Timer temporizador;

        public Form1()
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
                    temporizador.Interval = 100;
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

                // Actualizar la imagen en el hilo de la UI
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

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    Bitmap imagenActual = null;

                    // Crear una copia de la imagen para evitar problemas de concurrencia
                    lock (pictureBox1)
                    {
                        if (pictureBox1.Image != null)
                        {
                            imagenActual = new Bitmap(pictureBox1.Image);
                        }
                    }

                    if (imagenActual != null)
                    {
                        BarcodeReader lector = new BarcodeReader();
                        Result resultado = lector.Decode(imagenActual);
                        imagenActual.Dispose();

                        if (resultado != null)
                        {
                            string codigoQR = resultado.Text;

                            // Detener el temporizador y la cámara
                            temporizador.Stop();

                            if (fuenteVideo != null && fuenteVideo.IsRunning)
                            {
                                fuenteVideo.SignalToStop();
                                fuenteVideo.WaitForStop();
                            }

                            // Log del código QR detectado
                            System.Diagnostics.Debug.WriteLine($"Código QR detectado: {codigoQR}");

                            // Buscar el usuario en la base de datos
                            var usuario = UsuarioDAO.BuscarUsuarioPorCodigo(codigoQR);

                            // Verificar si se encontró el usuario
                            if (usuario.Item1 != null && !string.IsNullOrEmpty(usuario.Item1))
                            {
                                string info = $"✅ USUARIO ENCONTRADO\n\n" +
                                              $"━━━━━━━━━━━━━━━━━━━━━━\n" +
                                              $"📋 Nombre: {usuario.Item1} {usuario.Item2}\n" +
                                              $"🎂 Edad: {usuario.Item3} años\n" +
                                              $"💳 Membresía: {usuario.Item4}\n" +
                                              $"📅 Inicio: {usuario.Item5}\n" +
                                              $"📅 Fin: {usuario.Item6}\n" +
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

                            // Limpiar y reactivar el botón
                            fuenteVideo = null;
                            btnIniciar.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al escanear: " + ex.Message);
                temporizador.Stop();
                if (fuenteVideo != null && fuenteVideo.IsRunning)
                {
                    fuenteVideo.SignalToStop();
                }
                btnIniciar.Enabled = true;
            }
        }

        // Botón para abrir formulario de registro
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

                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
            }
            catch { }

            base.OnFormClosing(e);
        }
    }
}