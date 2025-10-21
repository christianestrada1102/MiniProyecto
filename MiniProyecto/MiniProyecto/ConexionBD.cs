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
        public bool InsertarUsuario(string nombre, string apellido, int edad, DateTime fechaInicio, DateTime fechaTermino, string tipoMembresia)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "INSERT INTO pruebas (nombre, apellido, edad, fechaini, fechafin, tipomembresia) " +
                                      "VALUES (@nombre, @apellido, @edad, @fechaInicio, @fechaTermino, @tipoMembresia)";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellido", apellido);
                        comando.Parameters.AddWithValue("@edad", edad);
                        comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        comando.Parameters.AddWithValue("@fechaTermino", fechaTermino);
                        comando.Parameters.AddWithValue("@tipoMembresia", tipoMembresia);

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
        public DataTable BuscarUsuario(string nombre)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();
                    string consulta = "SELECT * FROM pruebas WHERE nombre LIKE @nombre OR apellido LIKE @nombre";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

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
        public bool ActualizarUsuario(int id, string nombre, string apellido, int edad, DateTime fechaInicio, DateTime fechaTermino, string tipoMembresia)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "UPDATE pruebas SET nombre=@nombre, apellido=@apellido, edad=@edad, " +
                                      "fechaini=@fechaInicio, fechafin=@fechaTermino, tipomembresia=@tipoMembresia " +
                                      "WHERE id=@id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellido", apellido);
                        comando.Parameters.AddWithValue("@edad", edad);
                        comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        comando.Parameters.AddWithValue("@fechaTermino", fechaTermino);
                        comando.Parameters.AddWithValue("@tipoMembresia", tipoMembresia);

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
