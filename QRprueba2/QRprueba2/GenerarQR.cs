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
                // Crear generador de código QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrImage = qrCode.GetGraphic(20);

                // Carpeta donde se guardará el QR
                string carpeta = Path.Combine(Application.StartupPath, "QR_Usuarios");
                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

                // Ruta final del archivo (por ejemplo: "Christian_Maniel.png")
                string ruta = Path.Combine(carpeta, $"{nombreArchivo}.png");

                // Guardar la imagen
                qrImage.Save(ruta, System.Drawing.Imaging.ImageFormat.Png);

                return ruta; // Devuelve la ruta donde se guardó el QR
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el código QR: {ex.Message}");
                return null;
            }
        }
    }
}
