using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace MiniProyecto
{
    public partial class ConexionBD
    {
        // ✅ Mantén tu IP actual y datos correctos del servidor
        private readonly string servidor = "10.1.124.217";
        private readonly string puerto = "3306";
        private readonly string bd = "pruebasgestiongym";
        private readonly string usuario = "GestionGym";
        private readonly string password = "chris_kikin";

        // ✅ Propiedad que genera la cadena de conexión
        private string CadenaConexion =>
            $"Server={servidor};Port={puerto};Database={bd};Uid={usuario};Pwd={password};SslMode=none;";

        // 🔹 Método reutilizable para obtener la conexión
        private MySqlConnection ObtenerConexion()
        {
            var conexion = new MySqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ⭐ CREAR (Actualizado con verificación real del INSERT)
        public bool InsertarUsuario(string nom, string apell, int edad, DateTime fecha_inc, DateTime fecha_fin, string member, string codigo_qr)
        {
            try
            {
                using (var conexion = ObtenerConexion())
                {
                    if (conexion == null)
                    {
                        MessageBox.Show("❌ No se estableció conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // 🔎 Verificar la conexión antes de ejecutar
                    if (conexion.State != ConnectionState.Open)
                    {
                        MessageBox.Show("⚠️ La conexión no está abierta.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    string consulta = "INSERT INTO pruebas (nom, apell, edad, fecha_inc, fecha_fin, member, codigo_qr) " +
                                      "VALUES (@nom, @apell, @edad, @fecha_inc, @fecha_fin, @member, @codigo_qr)";

                    using (var comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nom", nom);
                        comando.Parameters.AddWithValue("@apell", apell);
                        comando.Parameters.AddWithValue("@edad", edad);
                        comando.Parameters.AddWithValue("@fecha_inc", fecha_inc);
                        comando.Parameters.AddWithValue("@fecha_fin", fecha_fin);
                        comando.Parameters.AddWithValue("@member", member);
                        comando.Parameters.AddWithValue("@codigo_qr", codigo_qr);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            // 🔥 Confirmar que se insertó
                            MessageBox.Show("✅ Registro insertado correctamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("⚠️ No se insertó ninguna fila. Revisa el nombre de la tabla o columnas.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"❌ Error MySQL: {ex.Message}\nCódigo: {ex.Number}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al insertar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ⭐ LEER - OBTENER TODOS
        public DataTable ObtenerTodosUsuarios()
        {
            try
            {
                using (var conexion = ObtenerConexion())
                {
                    if (conexion == null) return null;

                    string consulta = "SELECT * FROM pruebas";
                    var adaptador = new MySqlDataAdapter(consulta, conexion);
                    var datos = new DataTable();
                    adaptador.Fill(datos);
                    return datos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ⭐ LEER - BUSCAR POR NOMBRE O APELLIDO
        public DataTable BuscarUsuario(string busqueda)
        {
            try
            {
                using (var conexion = ObtenerConexion())
                {
                    if (conexion == null) return null;

                    string consulta = "SELECT * FROM pruebas WHERE nom LIKE @busqueda OR apell LIKE @busqueda";
                    using (var comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");

                        var adaptador = new MySqlDataAdapter(comando);
                        var datos = new DataTable();
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
                using (var conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    string consulta = "UPDATE pruebas SET nom=@nom, apell=@apell, edad=@edad, " +
                                      "fecha_inc=@fecha_inc, fecha_fin=@fecha_fin, member=@member, codigo_qr=@codigo_qr " +
                                      "WHERE id=@id";

                    using (var comando = new MySqlCommand(consulta, conexion))
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
                    }

                    return true;
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
                using (var conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    string consulta = "DELETE FROM pruebas WHERE id=@id";
                    using (var comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        comando.ExecuteNonQuery();
                    }

                    return true;
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
                using (var conexion = ObtenerConexion())
                {
                    if (conexion == null) return null;

                    string consulta = "SELECT * FROM pruebas WHERE id=@id";
                    using (var comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", idUsuario);
                        var adaptador = new MySqlDataAdapter(comando);
                        var datos = new DataTable();
                        adaptador.Fill(datos);
                        return datos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // ⭐ BUSCAR POR CÓDIGO QR
        public (string, string, string, string, string, string) BuscarUsuarioPorCodigo(string codigoQR)
        {
            try
            {
                using (var conexion = ObtenerConexion())
                {
                    if (conexion == null)
                        return (null, null, null, null, null, null);

                    string consulta = "SELECT nom, apell, edad, member, fecha_inc, fecha_fin " +
                                      "FROM pruebas WHERE codigo_qr = @codigo LIMIT 1";

                    using (var comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@codigo", codigoQR);
                        comando.CommandTimeout = 5;

                        using (var reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string nom = reader["nom"]?.ToString() ?? "";
                                string apell = reader["apell"]?.ToString() ?? "";
                                string edad = reader["edad"]?.ToString() ?? "";
                                string member = reader["member"]?.ToString() ?? "";
                                string fecha_inc = reader["fecha_inc"]?.ToString() ?? "";
                                string fecha_fin = reader["fecha_fin"]?.ToString() ?? "";

                                return (nom, apell, edad, member, fecha_inc, fecha_fin);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por código QR: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (null, null, null, null, null, null);
        }
    }
}
