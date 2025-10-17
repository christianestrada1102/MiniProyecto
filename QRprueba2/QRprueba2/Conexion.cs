using System;
using MySql.Data.MySqlClient;

namespace QRprueba2
{
    internal class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            string servidor = "127.0.0.1";
            string bd = "pruebasgestiongym";
            string usuario = "root";
            string password = "";
            string puerto = "3306";

            string cadenaConexion = $"SERVER={servidor};DATABASE={bd};UID={usuario};PASSWORD={password};PORT={puerto};";

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al conectar: " + ex.Message);
                return null;
            }
        }
    }
}
