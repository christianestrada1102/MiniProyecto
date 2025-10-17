using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ZXing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QRprueba2
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection DispositivosDeVideo;
        private VideoCaptureDevice Camara;
        private Timer temporizador;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            this.Load += Form1_Load;
            btnIniciar.Click += BtnIniciar_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Buscar cámaras disponibles
            DispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (DispositivosDeVideo.Count == 0)
            {
                MessageBox.Show("No se encontró ninguna cámara.");
                return;
            }

            foreach (FilterInfo dispositivo in DispositivosDeVideo)
            {
                comboBox1.Items.Add(dispositivo.Name);
            }

            comboBox1.SelectedIndex = 0;

            // Crear temporizador para leer QR
            temporizador = new Timer();
            temporizador.Interval = 200; // cada 0.2 segundos
            temporizador.Tick += Temporizador_Tick;
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona una cámara primero.");
                return;
            }

            Camara = new VideoCaptureDevice(DispositivosDeVideo[comboBox1.SelectedIndex].MonikerString);
            Camara.NewFrame += Camara_NewFrame;
            Camara.Start();
            temporizador.Start();
            lblResultado.Text = "Escaneando QR...";
        }

        private void Camara_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = imagen;
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            BarcodeReader lector = new BarcodeReader();

            var resultado = lector.Decode(bitmap);

            if (resultado != null)
            {
                temporizador.Stop();
                if (Camara != null && Camara.IsRunning)
                    Camara.SignalToStop();

                string codigoQR = resultado.Text;
                lblResultado.Text = "QR detectado: " + codigoQR;

                var usuario = UsuarioDAO.BuscarUsuarioPorCodigo(codigoQR);

                if (usuario != null)
                {
                    MessageBox.Show(
                        $"✅ Usuario encontrado:\n\n" +
                        $"Nombre: {usuario.Nombre} {usuario.Apellido}\n" +
                        $"Edad: {usuario.Edad}\n" +
                        $"Membresía: {usuario.Membresia}\n" +
                        $"Inicio: {usuario.FechaInicio.ToShortDateString()}\n" +
                        $"Fin: {usuario.FechaFin.ToShortDateString()}",
                        "Información del Usuario"
                    );
                }
                else
                {
                    MessageBox.Show("❌ No se encontró ningún usuario con ese código QR.", "Sin resultados");
                }
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Camara != null && Camara.IsRunning)
                Camara.SignalToStop();
        }
    }
}
