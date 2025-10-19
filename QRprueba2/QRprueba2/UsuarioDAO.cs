using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace QRprueba2
{
    internal class UsuarioDAO
    {
        public static bool InsertarUsuario(string nombre, string apellido, string membresia, string edad, string fechaInicio, string fechaFin, string codigoQR)
        {
            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    if (conexion == null)
                    {
                        MessageBox.Show("No se pudo conectar a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // NOTA: Usar los nombres REALES de las columnas de la tabla "pruebas"
                    string consulta = "INSERT INTO pruebas (nom, apell, edad, member, fecha_inc, fecha_fin, codigo_qr) " +
                                      "VALUES (@nom, @apell, @edad, @member, @fecha_inc, @fecha_fin, @codigo_qr)";

                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@nom", nombre);
                    comando.Parameters.AddWithValue("@apell", apellido);
                    comando.Parameters.AddWithValue("@edad", edad);
                    comando.Parameters.AddWithValue("@member", membresia);
                    comando.Parameters.AddWithValue("@fecha_inc", fechaInicio);
                    comando.Parameters.AddWithValue("@fecha_fin", fechaFin);
                    comando.Parameters.AddWithValue("@codigo_qr", codigoQR);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        // Solo mostrar un mensaje simple
                        MessageBox.Show("✅ Usuario registrado exitosamente.", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("⚠️ No se pudo registrar el usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062) // Código de error para duplicados
                {
                    MessageBox.Show("❌ Este código QR ya está registrado.", "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al insertar usuario: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static (string, string, string, string, string, string) BuscarUsuarioPorCodigo(string codigoQR)
        {
            try
            {
                // Log para depuración
                System.Diagnostics.Debug.WriteLine($"🔍 Buscando código QR: {codigoQR}");

                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    if (conexion == null)
                    {
                        MessageBox.Show("❌ No se pudo conectar a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return (null, null, null, null, null, null);
                    }

                    System.Diagnostics.Debug.WriteLine("✅ Conexión establecida");

                    // NOTA: Usar los nombres REALES de las columnas de la tabla "pruebas"
                    string consulta = "SELECT nom, apell, edad, member, fecha_inc, fecha_fin " +
                                      "FROM pruebas WHERE codigo_qr = @codigo";

                    MySqlCommand comando = new MySqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@codigo", codigoQR);

                    System.Diagnostics.Debug.WriteLine($"📝 Ejecutando consulta: {consulta}");

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombre = reader["nom"].ToString();
                            string apellido = reader["apell"].ToString();
                            string edad = reader["edad"].ToString();
                            string membresia = reader["member"].ToString();
                            string fechaInicio = reader["fecha_inc"].ToString();
                            string fechaFin = reader["fecha_fin"].ToString();

                            System.Diagnostics.Debug.WriteLine($"✅ Usuario encontrado: {nombre} {apellido}");

                            return (nombre, apellido, edad, membresia, fechaInicio, fechaFin);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("❌ No se encontró ningún registro con ese código QR");

                            // Mostrar mensaje de depuración
                            MessageBox.Show($"⚠️ DEBUG:\nNo se encontró el código: {codigoQR}\n\nVerifica en phpMyAdmin que el código QR esté registrado.",
                                          "No encontrado - Debug",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);

                            return (null, null, null, null, null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error: {ex.Message}");
                MessageBox.Show($"Error al buscar usuario:\n\n{ex.Message}\n\n{ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (null, null, null, null, null, null);
            }
        }

        // Método adicional para verificar la conexión
        public static bool VerificarConexion()
        {
            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    if (conexion != null)
                    {
                        MessageBox.Show("✅ Conexión exitosa a la base de datos.", "Conexión OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("❌ No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}