using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MiniProyecto
{
    internal class GenerarQR
    {
        public static string CrearCodigoQR(string texto, string nombreArchivo)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(20);

                // Obtener la carpeta de Descargas del usuario
                string carpetaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                // Crear subcarpeta "QR" dentro de Downloads
                string carpetaQR = Path.Combine(carpetaDescargas, "QR");

                if (!Directory.Exists(carpetaQR))
                    Directory.CreateDirectory(carpetaQR);

                string ruta = Path.Combine(carpetaQR, $"{nombreArchivo}.png");
                qrImage.Save(ruta, System.Drawing.Imaging.ImageFormat.Png);

                return ruta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al generar el código QR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Método sobrecargado para recibir directamente un Bitmap
        public static string GuardarQR(Bitmap qrImage, string nombreArchivo)
        {
            try
            {
                // Obtener la carpeta de Descargas del usuario
                string carpetaDescargas = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

                // Crear subcarpeta "QR" dentro de Downloads
                string carpetaQR = Path.Combine(carpetaDescargas, "QR");

                if (!Directory.Exists(carpetaQR))
                    Directory.CreateDirectory(carpetaQR);

                string ruta = Path.Combine(carpetaQR, $"{nombreArchivo}.png");
                qrImage.Save(ruta, System.Drawing.Imaging.ImageFormat.Png);

                return ruta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al guardar el código QR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}