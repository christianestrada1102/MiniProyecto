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
            // ⭐ CARGAR TODOS LOS USUARIOS AL ABRIR
            CargarUsuarios();

            // ⭐ EVENTO DEL DATAGRIDVIEW PARA SELECCIONAR FILA
            dataGridView1.CellClick += DataGridView1_CellClick;
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

                // ⭐ OBTENER EL ID (CAMBIA SEGÚN TU TABLA)
                idSeleccionado = Convert.ToInt32(fila.Cells["id"].Value);

                // Rellenar los campos con los datos de la fila
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["apellido"].Value.ToString();
                txtEdad.Text = fila.Cells["edad"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(fila.Cells["fechaini"].Value);
                dateTimePicker2.Value = Convert.ToDateTime(fila.Cells["fechafin"].Value);
                cmbTipoMembresia.SelectedItem = fila.Cells["tipomembresia"].Value.ToString();
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
            cmbTipoMembresia.SelectedIndex = -1;
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
      
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor completa todos los campos", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             // ⭐ ELIMINAR USUARIO
      
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
                    // ⭐ CREAR - NUEVO USUARIO
     
            // ⭐ ABRIR EL FORMULARIO DE REGISTRO
            Registro formRegistro = new Registro();
            formRegistro.ShowDialog();

            // Después de cerrar el formulario, recargar los usuarios
            CargarUsuarios();
            LimpiarCampos();
            idSeleccionado = -1;
        }

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
    }

   
}