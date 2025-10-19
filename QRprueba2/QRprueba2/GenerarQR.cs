using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QRprueba2
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

                string carpeta = Path.Combine(Application.StartupPath, "QR_Usuarios");
                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                string ruta = Path.Combine(carpeta, $"{nombreArchivo}.png");
                qrImage.Save(ruta, System.Drawing.Imaging.ImageFormat.Png);

                return ruta;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el código QR: {ex.Message}");
                return null;
            }
        }
    }
}
