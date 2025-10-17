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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                        // Opcional: ejemplos en los textboxes
            textBox1.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            textBox2.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        // Botón: miembros activos hoy (usa DateTime.Today)
        private void button1_Click(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            const string sql = "SELECT id, nombre, apellido, edad, membresia, fechaini, fechafin " +
                               "FROM lista_us " +
                               "WHERE fechaini <= @hoy AND fechafin >= @hoy;";

            var dt = ExecuteQuery(sql,
                new MySqlParameter("@hoy", MySqlDbType.Date) { Value = hoy });
            dataGridView1.DataSource = dt;
        }

        // Botón: buscar por rango usando textBox1 (inicio) y textBox2 (fin)
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime inicio, fin;

            if (!TryParseFecha(textBox1.Text.Trim(), out inicio))
            {
                MessageBox.Show("Fecha 'Desde' no válida. Usa formato yyyy-MM-dd o dd/MM/yyyy.", "Fecha inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryParseFecha(textBox2.Text.Trim(), out fin))
            {
                MessageBox.Show("Fecha 'Hasta' no válida. Usa formato yyyy-MM-dd o dd/MM/yyyy.", "Fecha inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Opcional: ejemplos en los textboxes
            textBox1.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            textBox2.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        // Botón: miembros activos hoy (usa DateTime.Today)
        private void button1_Click(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            const string sql = "SELECT id, nombre, apellido, edad, membresia, fechaini, fechafin " +
                               "FROM lista_us " +
                               "WHERE fechaini <= @hoy AND fechafin >= @hoy;";
            // Opcional: ejemplos en los textboxes
            textBox1.Text = DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
            textBox2.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        // Botón: miembros activos hoy (usa DateTime.Today)
        private void button1_Click(object sender, EventArgs e)
        {
            var hoy = DateTime.Today;
            const string sql = "SELECT id, nombre, apellido, edad, membresia, fechaini, fechafin " +
                               "FROM lista_us " +
                               "WHERE fechaini <= @hoy AND fechafin >= @hoy;";

            var dt = ExecuteQuery(sql,
                new MySqlParameter("@hoy", MySqlDbType.Date) { Value = hoy });
            dataGridView1.DataSource = dt;
        }

        // Botón: buscar por rango usando textBox1 (inicio) y textBox2 (fin)
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime inicio, fin;

            if (!TryParseFecha(textBox1.Text.Trim(), out inicio))
            {
                MessageBox.Show("Fecha 'Desde' no válida. Usa formato yyyy-MM-dd o dd/MM/yyyy.", "Fecha inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryParseFecha(textBox2.Text.Trim(), out fin))
            {
                MessageBox.Show("Fecha 'Hasta' no válida. Usa formato yyyy-MM-dd o dd/MM/yyyy.", "Fecha inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (inicio > fin)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Rango inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const string sql = "SELECT id, nombre, apellido, edad, membresia, fechaini, fechafin " +
                               "FROM lista_us " +
                               "WHERE fechaini >= @inicio AND fechafin <= @fin;";

            var dt = ExecuteQuery(sql,
                new MySqlParameter("@inicio", MySqlDbType.Date) { Value = inicio },
                new MySqlParameter("@fin", MySqlDbType.Date) { Value = fin });

            dataGridView1.DataSource = dt;
        }

        // Intenta parsear la fecha con varios formatos comunes
        private bool TryParseFecha(string texto, out DateTime resultado)
        {
            resultado = DateTime.MinValue;
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            // Formatos aceptados
            var formatos = new[] { "yyyy-MM-dd", "dd/MM/yyyy", "d/M/yyyy", "MM/dd/yyyy" };
    
        }
    }
}
