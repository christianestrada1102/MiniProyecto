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
        }

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
                            FechaFin = reader.GetDateTime("fecha_fin")
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
