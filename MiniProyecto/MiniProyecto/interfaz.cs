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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cierra el formulario hijo activo (si hay uno abierto)
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            // Vuelve a mostrar la imagen principal
            pictureBox4.Visible = true;
        }

        private void btnQr_Click(object sender, EventArgs e)
        {
            // ✅ Solo este botón funcionará
            OpenChildForm(new ScanQR());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        // Método para abrir formularios dentro del panelContenido
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
            OpenChildForm(new AdminUsuarios());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Cierra cualquier formulario hijo activo
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            // Oculta este formulario temporalmente
            this.Hide();

            // Abre el login de forma modal (bloquea hasta que se cierre)
            using (Login login = new Login())
            {
                login.ShowDialog();
            }

            // Cuando se cierre el Login, vuelve a mostrar este formulario
            this.Show();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
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
