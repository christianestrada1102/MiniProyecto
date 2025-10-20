using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniProyecto
{
    public partial class AdminUsuarios : Form
    {
        private ConexionBD bd = new ConexionBD();
        private int idSeleccionado = -1;

        public AdminUsuarios()
        {
            InitializeComponent();
        }

        private void AdminUsuarios_Load(object sender, EventArgs e)
        {
            // ⭐ AGREGAR OPCIONES AL COMBOBOX
            cmbTipoMembresia.Items.Add("Mes");
            cmbTipoMembresia.Items.Add("Semana");
            cmbTipoMembresia.Items.Add("Año");

            // ⭐ CARGAR TODOS LOS USUARIOS AL ABRIR
            CargarUsuarios();

            // ⭐ EVENTO DEL DATAGRIDVIEW PARA SELECCIONAR FILA
            dataGridView1.CellClick += DataGridView1_CellClick;

            // ⭐ EVENTO DEL COMBOBOX PARA CALCULAR FECHA FIN
            cmbTipoMembresia.SelectedIndexChanged += CmbTipoMembresia_SelectedIndexChanged;

            // ⭐ EVENTO DEL DATEPICKER DE INICIO PARA RECALCULAR
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
        }

        // ⭐ LEER - CARGAR TODOS LOS USUARIOS
        private void CargarUsuarios()
        {
            DataTable usuarios = bd.ObtenerTodosUsuarios();
            if (usuarios != null)
            {
                dataGridView1.DataSource = usuarios;
            }
        }

        // ⭐ SELECCIONAR FILA DEL DATAGRIDVIEW
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                // ⭐ OBTENER EL ID
                idSeleccionado = Convert.ToInt32(fila.Cells["id"].Value);

                // Rellenar los campos con los datos de la fila
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["apellido"].Value.ToString();
                txtEdad.Text = fila.Cells["edad"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(fila.Cells["fechaini"].Value);
                cmbTipoMembresia.SelectedItem = fila.Cells["tipomembresia"].Value.ToString();

                // ⭐ RECALCULAR LA FECHA FIN AUTOMÁTICAMENTE
                CalcularFechaFin();
            }
        }

        // ⭐ CALCULAR FECHA FIN AUTOMÁTICAMENTE CUANDO CAMBIA EL COMBOBOX
        private void CmbTipoMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        // ⭐ RECALCULAR CUANDO CAMBIA LA FECHA DE INICIO
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CalcularFechaFin();
        }

        // ⭐ FUNCIÓN PARA CALCULAR LA FECHA FIN
        private void CalcularFechaFin()
        {
            if (cmbTipoMembresia.SelectedItem == null)
                return;

            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin;
            string tipoSeleccionado = cmbTipoMembresia.SelectedItem.ToString();

            if (tipoSeleccionado == "Mes")
            {
                fechaFin = fechaInicio.AddMonths(1);
            }
            else if (tipoSeleccionado == "Semana")
            {
                fechaFin = fechaInicio.AddDays(7);
            }
            else if (tipoSeleccionado == "Año")
            {
                fechaFin = fechaInicio.AddYears(1);
            }
            else
            {
                return;
            }

            // ⭐ MOSTRAR LA FECHA FIN CALCULADA (DESHABILITADA PARA QUE NO SE PUEDA EDITAR)
            dateTimePicker2.Value = fechaFin;
            dateTimePicker2.Enabled = false; // No permite editar, se calcula automáticamente
        }

        // ⭐ CREAR - NUEVO USUARIO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // ⭐ ABRIR EL FORMULARIO DE REGISTRO
            Registro formRegistro = new Registro();
            formRegistro.ShowDialog();

            // Después de cerrar el formulario, recargar los usuarios
            CargarUsuarios();
            LimpiarCampos();
            idSeleccionado = -1;
        }

        // ⭐ GUARDAR - CREAR O ACTUALIZAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor completa todos los campos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTipoMembresia.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un tipo de membresía", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaTermino = dateTimePicker2.Value;
            string tipoMembresia = cmbTipoMembresia.SelectedItem.ToString();

            if (idSeleccionado == -1)
            {
                // CREAR nuevo usuario
                if (bd.InsertarUsuario(nombre, apellido, edad, fechaInicio, fechaTermino, tipoMembresia))
                {
                    MessageBox.Show("Usuario creado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
            }
            else
            {
                // ACTUALIZAR usuario existente
                if (bd.ActualizarUsuario(idSeleccionado, nombre, apellido, edad, fechaInicio, fechaTermino, tipoMembresia))
                {
                    MessageBox.Show("Usuario actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                    idSeleccionado = -1;
                }
            }
        }

        // ⭐ ELIMINAR USUARIO
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un usuario para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (bd.EliminarUsuario(idSeleccionado))
                {
                    MessageBox.Show("Usuario eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                    idSeleccionado = -1;
                }
            }
        }

        // ⭐ LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Enabled = false;
            cmbTipoMembresia.SelectedIndex = -1;
        }

        // ⭐ BÚSQUEDA
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;

            if (string.IsNullOrWhiteSpace(busqueda))
            {
                CargarUsuarios();
            }
            else
            {
                DataTable resultados = bd.BuscarUsuario(busqueda);
                if (resultados != null)
                {
                    dataGridView1.DataSource = resultados;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}