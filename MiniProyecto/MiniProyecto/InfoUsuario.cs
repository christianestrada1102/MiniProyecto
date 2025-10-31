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
    public partial class InfoUsuario : Form
    {
        private ConexionBD bd = new ConexionBD();
        public InfoUsuario()
        {
            InitializeComponent();
        }

        private void InfoUsuario_Load(object sender, EventArgs e)
        {
            //EVENTOS
            btnBuscar.Click += btnBuscar_Click;
            txtIDUsuario.KeyPress += txtIDUsuario_KeyPress; //Enter para buscar
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtIDUsuario.Text.Trim();

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Ingresa un ID de usuario!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(id, out int idUsuario))
            {
                MostrarDatos(idUsuario);
            }
            else
            {
                MessageBox.Show("ERROR! ID inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIDUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnBuscar_Click(null, null);
                e.Handled = true;
            }
        }

        //MOSTRAR DATOS DEL USUARIO
        private void MostrarDatos(int idUsuario)
        {
            DataTable usuario = bd.ObtenerUsuarioPorID(idUsuario);

            if (usuario != null && usuario.Rows.Count > 0)
            {
                DataRow fila = usuario.Rows[0];

                //Mostrar datos principales
                lblNombre.Text = "Nombre: " + fila["nombre"].ToString() + " " + fila["apellido"].ToString();
                lblEdad.Text = "Edad: " + fila["edad"].ToString() + " años";
                lblMembresia.Text = "Membresía: " + fila["tipomembresia"].ToString();

                //Calcular días restantes
                DateTime fechaFin = Convert.ToDateTime(fila["fechafin"]);
                int diasRestantes = (int)(fechaFin - DateTime.Today).TotalDays;

                if (diasRestantes > 0)
                {
                    lblDiasRestantes.Text = $"Membresía vigente por: {diasRestantes} días";
                    lblDiasRestantes.ForeColor = System.Drawing.Color.Green;
                }
                else if (diasRestantes == 0)
                {
                    lblDiasRestantes.Text = "Membresía vence HOY";
                    lblDiasRestantes.ForeColor = System.Drawing.Color.Orange;
                }
                else
                {
                    lblDiasRestantes.Text = $"La Membresía vencio hace {Math.Abs(diasRestantes)} días";
                    lblDiasRestantes.ForeColor = System.Drawing.Color.Red;
                }

                //Mostrar fechas
                lblFechaInicio.Text = "Inicio: " + Convert.ToDateTime(fila["fechaini"]).ToString("dd/MM/yyyy");
                lblFechaFin.Text = "Fin: " + fechaFin.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("ERROR!! Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarPantalla();
            }
        }

        //LIMPIAR PANTALLA
        private void LimpiarPantalla()
        {
            lblNombre.Text = "Nombre: ---";
            lblEdad.Text = "Edad: ---";
            lblMembresia.Text = "Membresía: ---";
            lblDiasRestantes.Text = "Días restantes: ---";
            lblFechaInicio.Text = "Inicio: ---";
            lblFechaFin.Text = "Fin: ---";
            txtIDUsuario.Text = "";
            txtIDUsuario.Focus();
        }
    










        private void txtIDUsuario_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
