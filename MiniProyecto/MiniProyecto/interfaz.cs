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
       /* private void Reset()
        {
            Disablebutton1();
            lblTitle.Text = "INICIO";

        }*/
    }
}
