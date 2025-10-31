using MiniProyecto;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TuProyecto
{
    public partial class FormRegistrar : Form
    {
        public FormRegistrar()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmar = txtConfirmarPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Por favor, completa todos los campos para continuar.");
                return;
            }

            if (password != confirmar)
            {
                MessageBox.Show("ERROR!! Las contraseñas no coinciden.");
                return;
            }

            string conexion = "server=127.0.0.1;database=pruebasgestiongym;uid=GestionGym;pwd=chris_kikin;";

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO usuarios (nombre_usuario, contrasena, fecha_registro) VALUES (@user, @pass, NOW())";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("El usuario se ha registrado con éxito!!!.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡¡¡ Error al registrar: " + ex);
                }
            }
        }

        private void linkVolverLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void panelDerecho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
    