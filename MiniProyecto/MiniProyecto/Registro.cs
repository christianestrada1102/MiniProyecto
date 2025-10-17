using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProyecto
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            // ⭐ ASIGNA LOS EVENTOS DE LOS RADIO BUTTONS
            // En el diseñador, haz doble clic en cada radioButton y selecciona el evento CheckedChanged
            // O aquí asigna los eventos:
            rdmes.CheckedChanged += CalcularVigencia;
            rdano.CheckedChanged += CalcularVigencia;
            rdsem.CheckedChanged += CalcularVigencia;

            // También cuando cambio la fecha del DateTimePicker
            dateTimePicker1.ValueChanged += CalcularVigencia;

        }

        private void CalcularVigencia(object sender, EventArgs e)
        {
            // Obtener la fecha de inicio
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin;

            // ⭐ VERIFICA LOS NOMBRES DE TUS RADIOBUTTONS
            // Cambia rdoMes, rdoSemana, rdoAño por tus nombres reales

            if (rdmes.Checked)
            {
                // Sumar 1 mes
                fechaFin = fechaInicio.AddMonths(1);
            }
            else if (rdsem.Checked)
            {
                // Sumar 7 días (1 semana)
                fechaFin = fechaInicio.AddDays(7);
            }
            else if (rdano.Checked)
            {
                // Sumar 1 año
                fechaFin = fechaInicio.AddYears(1);
            }
            else
            {
                // Si ninguno está seleccionado
                lblVigencia.Text = "Selecciona una opción de membresía";
                return;
            }

            // ⭐ CAMBIA lblVigencia POR EL NOMBRE DE TU LABEL
            // Mostrar el mensaje con las fechas
            lblVigencia.Text = $"La membresia comenzara el {fechaInicio:dd/MM/yyyy} \n y terminara el {fechaFin:dd/MM/yyyy}";
        }

        private void nombretb_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdsem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // ⭐ MODIFICA CON TUS NOMBRES DE CONTROLES
            string nombre = nombretb.Text;
            string apellido = apellidotb.Text;
            DateTime fechaInicio = dateTimePicker1.Value;

            // Calcular fecha de término
            DateTime fechaTermino;
            string tipoMembresia = "";

            if (rdmes.Checked)
            {
                fechaTermino = fechaInicio.AddMonths(1);
                tipoMembresia = "Mes";
            }
            else if (rdsem.Checked)
            {
                fechaTermino = fechaInicio.AddDays(7);
                tipoMembresia = "Semana";
            }
            else if (rdano.Checked)
            {
                fechaTermino = fechaInicio.AddYears(1);
                tipoMembresia = "Año";
            }
            else
            {
                MessageBox.Show("Selecciona un tipo de membresía", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí guardarías en la base de datos
            ConexionBD bd = new ConexionBD();
            bd.InsertarUsuario(nombre, apellido, fechaInicio, fechaTermino, tipoMembresia);
        }
    }


    //ConexionBD
    public class ConexionBD
    {
        private string cadenaConexion = @"Server=localhost;Port=3308;Database=pruebasgestiongym;Uid=root;Pwd=;";

        public bool InsertarUsuario(string nombre, string apellido, DateTime fechaInicio, DateTime fechaTermino, string tipoMembresia)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // ⭐ ASEGÚRATE QUE TU TABLA TENGA ESTAS COLUMNAS
                    string consulta = "INSERT INTO pruebas (nombre, apellido, fechaini, fechafin, tipomembresia) " +
                                    "VALUES (@nombre, @apellido, @fechaInicio, @fechaTermino, @tipoMembresia)";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre", nombre);
                        comando.Parameters.AddWithValue("@apellido", apellido);
                        comando.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                        comando.Parameters.AddWithValue("@fechaTermino", fechaTermino);
                        comando.Parameters.AddWithValue("@tipoMembresia", tipoMembresia);

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Membresía registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

