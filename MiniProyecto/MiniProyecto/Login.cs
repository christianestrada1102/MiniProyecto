using System;
using System.Windows.Forms;

namespace MiniProyecto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShowPass.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUser.Text.Trim();
            string contraseña = txtPass.Text.Trim();

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor completa todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar usuario y contraseña (ambos son 'admin')
            if (usuario == "admin" && contraseña == "admin")
            {
                MessageBox.Show("Inicio de sesión exitoso.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // No abrir AnimacionInicio; indicar éxito para que Program.Main inicie panelLogo
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
