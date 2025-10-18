using System;
using MySql.Data.MySqlClient;

namespace QRprueba2
{
    internal class UsuarioDAO
    {
        public class Usuario
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Edad { get; set; }
            public string Membresia { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string CodigoQR { get; set; }
        }

        // ✅ Método para insertar un nuevo usuario y generar su QR automáticamente
        public static bool InsertarUsuario(string nombre, string apellido, int edad, string membresia, DateTime fechaInicio, DateTime fechaFin)
        {
            bool exito = false;

            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    if (conexion == null)
                        throw new Exception("No se pudo conectar a la base de datos.");

                    // Generar un código QR único
                    string codigoQR = "QR" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();

                    // Generar y guardar la imagen QR
                    string nombreArchivo = nombre + "_" + apellido;
                    string rutaQR = GenerarQR.CrearCodigoQR(codigoQR, nombreArchivo);

                    // Insertar el usuario en la base de datos
                    string query = "INSERT INTO pruebas (nom, apell, edad, member, fecha_inc, fecha_fin, codigo_qr) " +
                                   "VALUES (@nom, @apell, @edad, @member, @fecha_inc, @fecha_fin, @codigo_qr)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nom", nombre);
                    cmd.Parameters.AddWithValue("@apell", apellido);
                    cmd.Parameters.AddWithValue("@edad", edad);
                    cmd.Parameters.AddWithValue("@member", membresia);
                    cmd.Parameters.AddWithValue("@fecha_inc", fechaInicio);
                    cmd.Parameters.AddWithValue("@fecha_fin", fechaFin);
                    cmd.Parameters.AddWithValue("@codigo_qr", codigoQR);

                    int filas = cmd.ExecuteNonQuery();
                    exito = filas > 0;

                    if (exito)
                    {
                        Console.WriteLine($"✅ Usuario '{nombre} {apellido}' insertado correctamente.");
                        Console.WriteLine($"🧾 Código QR: {codigoQR}");
                        Console.WriteLine($"📁 Imagen guardada en: {rutaQR}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar usuario: " + ex.Message);
            }

            return exito;
        }

        // 🔍 Método existente para buscar por código QR
        public static Usuario BuscarUsuarioPorCodigo(string codigoQR)
        {
            Usuario usuario = null;

            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    if (conexion == null)
                        throw new Exception("No se pudo conectar a la base de datos.");

                    string query = "SELECT * FROM pruebas WHERE codigo_qr = @codigo";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@codigo", codigoQR);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        usuario = new Usuario()
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nom"),
                            Apellido = reader.GetString("apell"),
                            Edad = reader.GetInt32("edad"),
                            Membresia = reader.GetString("member"),
                            FechaInicio = reader.GetDateTime("fecha_inc"),
                            FechaFin = reader.GetDateTime("fecha_fin"),
                            CodigoQR = reader.GetString("codigo_qr")
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar usuario: " + ex.Message);
            }

            return usuario;
        }
    }
}
