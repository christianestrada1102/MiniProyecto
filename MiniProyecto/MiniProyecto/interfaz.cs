using System;
using System.Windows.Forms;

namespace MiniProyecto
{
    public partial class panelLogo : Form
    {
        private Form activeForm = null;

        public panelLogo()
        {
            InitializeComponent();
        }

        private void panelLogo_Load(object sender, EventArgs e)
        {
            // 🔹 Inicia en tamaño normal
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            pictureBox4.Visible = true;
        }

        private void btnQr_Click(object sender, EventArgs e)
        {
            // 🔹 Vuelve al tamaño normal si estaba maximizado
            this.WindowState = FormWindowState.Normal;

            OpenChildForm(new ScanQR());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pictureBox4.Visible = false;
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // 🔹 Solo aquí se pone en pantalla completa
            this.WindowState = FormWindowState.Maximized;

            OpenChildForm(new AdminUsuarios());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 🔹 También vuelve al tamaño normal
            this.WindowState = FormWindowState.Normal;

            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            this.Hide();

            using (Login login = new Login())
            {
                login.ShowDialog();
            }

            this.Show();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            // 🔹 Vuelve al tamaño normal
            this.WindowState = FormWindowState.Normal;

            OpenChildForm(new FormRegistroUsuario());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
