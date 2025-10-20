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

        // ⭐ FUNCIÓN PARA CALCULAR LA EDAD
        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime hoy = DateTime.Today;

            // ⭐ Validar que la fecha no sea en el futuro
            if (fechaNacimiento > hoy)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser en el futuro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }

            int edad = hoy.Year - fechaNacimiento.Year;

            // Verificar si ya cumplió años este año
            if (fechaNacimiento.Date > hoy.AddYears(-edad))
            {
                edad--;
            }

            return edad;
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

            // ⭐ CALCULAR Y MOSTRAR LA EDAD
            int edad = CalcularEdad(fechaNac.Value);
            lblVigencia.Text = $"Tu membresía comenzó el {fechaInicio:dd/MM/yyyy}" +
                $" \ny termina el {fechaFin:dd/MM/yyyy} \nEdad: {edad} años";
        
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
            DateTime fechaNacimiento = fechaNac.Value;

            // ⭐ VALIDACIÓN DE EDAD - NO PERMITE MENORES    DE 18
            int edad = CalcularEdad(fechaNacimiento);
            if (edad < 18)
            {
                MessageBox.Show($"Lo sentimos, debes tener 18 años o más para registrarte. Tienes {edad} años.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            // Guardar en la base de datos
            ConexionBD bd = new ConexionBD();
            bd.InsertarUsuario(nombre, apellido, edad, fechaInicio, fechaTermino, tipoMembresia);

            // ⭐ LIMPIAR LOS CAMPOS DESPUÉS DE GUARDAR
            nombretb.Text = "";
            apellidotb.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            rdmes.Checked = false;
            rdsem.Checked = false;
            rdano.Checked = false;
            lblVigencia.Text = "";
        }
    }

}

