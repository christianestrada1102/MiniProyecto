using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MiniProyecto
{
    public partial class ConexionBD
    {
        // ✅ Conexión igual que la tuya
        private string cadenaConexion = @"Server=10.1.124.168;Port=3306;Database=pruebasgestiongym;Uid=GestionGym;Pwd=chris_kikin;";

        // ⭐ CREAR
        public bool InsertarUsuario(string nom, string apell, int edad, DateTime fecha_inc, DateTime fecha_fin, string member, string codigo_qr)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "INSERT INTO pruebas (nom, apell, edad, fecha_inc, fecha_fin, member, codigo_qr) " +
                                      "VALUES (@nom, @apell, @edad, @fecha_inc, @fecha_fin, @member, @codigo_qr)";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nom", nom);
                        comando.Parameters.AddWithValue("@apell", apell);
                        comando.Parameters.AddWithValue("@edad", edad);
                        comando.Parameters.AddWithValue("@fecha_inc", fecha_inc);
                        comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                        comando.Parameters.AddWithValue("@member", member);
                        comando.Parameters.AddWithValue("@codigo_qr", codigo_qr);

                        comando.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ⭐ LEER - OBTENER TODOS
        public DataTable ObtenerTodosUsuarios()
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM pruebas";

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable datos = new DataTable();
                    adaptador.Fill(datos);

                    return datos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ⭐ LEER - BUSCAR POR NOMBRE O APELLIDO
        public DataTable BuscarUsuario(string busqueda)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    // ✅ CORREGIDO: usar nom y apell (nombres reales de columnas)
                    string consulta = "SELECT * FROM pruebas WHERE nom LIKE @busqueda OR apell LIKE @busqueda";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                        MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                        DataTable datos = new DataTable();
                        adaptador.Fill(datos);

                        return datos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en búsqueda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ⭐ ACTUALIZAR
        public bool ActualizarUsuario(int id, string nom, string apell, int edad, DateTime fecha_inc, DateTime fecha_fin, string member, string codigo_qr)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // ✅ CORREGIDO: usar nom, apell, fecha_inc, fecha_fin, member, codigo_qr y agregar espacio antes de WHERE
                    string consulta = "UPDATE pruebas SET nom=@nom, apell=@apell, edad=@edad, " +
                                      "fecha_inc=@fecha_inc, fecha_fin=@fecha_fin, member=@member, codigo_qr=@codigo_qr " +
                                      "WHERE id=@id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@nom", nom);
                        comando.Parameters.AddWithValue("@apell", apell);
                        comando.Parameters.AddWithValue("@edad", edad);
                        comando.Parameters.AddWithValue("@fecha_inc", fecha_inc);
                        comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                        comando.Parameters.AddWithValue("@member", member);
                        comando.Parameters.AddWithValue("@codigo_qr", codigo_qr);

                        comando.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ⭐ ELIMINAR
        public bool EliminarUsuario(int id)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "DELETE FROM pruebas WHERE id=@id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ⭐ OBTENER USUARIO POR ID
        public DataTable ObtenerUsuarioPorID(int idUsuario)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM pruebas WHERE id=@id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", idUsuario);

                        MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                        DataTable datos = new DataTable();
                        adaptador.Fill(datos);

                        return datos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}