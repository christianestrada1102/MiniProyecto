using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRPrueba2.FormRegistroUsuario.cs;

namespace MiniProyecto
{
    public partial class panelLogo : Form
    {
        private Form activeForm;
        public panelLogo()
        {
            InitializeComponent();
        }

        private void panelLogo_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
         if(activeForm!=null)
                activeForm.Close();
          //  Reset();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Cerrar cualquier formulario activo previo
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            // Abrir AdminUsuarios y guardarlo en activeForm para poder cerrarlo desde aquí
            var admin = new AdminUsuarios();
            activeForm = admin;
            admin.Show();
        }

        private void btnQr_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Cerrar cualquier formulario hijo activo
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            // Ocultar esta interfaz y abrir el formulario Login como modal.
            // Cuando Login se cierre, volvemos a mostrar panelLogo.
            using (var login = new Login())
            {
                this.Hide();
                var result = login.ShowDialog();
                // Si necesitas un comportamiento distinto según DialogResult, ajusta aquí.
                this.Show();
            }
        }
        /* private void Reset()
{
Disablebutton1();
lblTitle.Text = "INICIO";

}*/
    }
}
