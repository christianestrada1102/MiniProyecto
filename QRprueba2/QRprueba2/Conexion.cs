using System;
using MySql.Data.MySqlClient;

namespace QRprueba2
{
    internal class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            string servidor = "10.1.125.189"; // 🔹 IP del servidor remoto
            string bd = "pruebasgestiongym";  // 🔹 Base de datos
            string usuario = "GestionGym";    // 🔹 Usuario del servidor MySQL
            string password = "chris_kikin";  // 🔹 Contraseña
            string puerto = "3306";           // 🔹 Puerto habilitado

            string cadenaConexion = $"SERVER={servidor};DATABASE={bd};UID={usuario};PASSWORD={password};PORT={puerto};";

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            try
            {
                conexion.Open();
                Console.WriteLine("✅ Conexión establecida correctamente.");
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
