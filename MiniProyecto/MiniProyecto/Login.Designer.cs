namespace MiniProyecto
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lnkForgot = new System.Windows.Forms.LinkLabel();
            this.lblSignupText = new System.Windows.Forms.Label();
            this.lnkSignup = new System.Windows.Forms.LinkLabel();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(120)))), ((int)(((byte)(228)))));
            this.pnlLeft.Controls.Add(this.lblWelcome);
            this.pnlLeft.Controls.Add(this.picLogo);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(350, 500);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(0, 200);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(350, 40);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "WELCOME TO";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackgroundImage = global::MiniProyecto.Properties.Resources.WhatsApp_Image_2025_10_21_at_9_35_00_AM;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(125, 300);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 90);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblTitle);
            this.pnlRight.Controls.Add(this.lblUser);
            this.pnlRight.Controls.Add(this.txtUser);
            this.pnlRight.Controls.Add(this.lblPass);
            this.pnlRight.Controls.Add(this.txtPass);
            this.pnlRight.Controls.Add(this.chkShowPass);
            this.pnlRight.Controls.Add(this.btnLogin);
            this.pnlRight.Controls.Add(this.lnkForgot);
            this.pnlRight.Controls.Add(this.lblSignupText);
            this.pnlRight.Controls.Add(this.lnkSignup);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(350, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(450, 500);
            this.pnlRight.TabIndex = 1;
            this.pnlRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRight_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(120)))), ((int)(((byte)(228)))));
            this.lblTitle.Location = new System.Drawing.Point(40, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(370, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SIGN IN TO YOUR ACCOUNT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(80, 150);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(70, 16);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Username";
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(80, 170);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(280, 22);
            this.txtUser.TabIndex = 2;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(80, 210);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 16);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(80, 230);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(280, 22);
            this.txtPass.TabIndex = 4;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Location = new System.Drawing.Point(80, 260);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(144, 20);
            this.chkShowPass.TabIndex = 5;
            this.chkShowPass.Text = "Mostrar contraseña";
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(120)))), ((int)(((byte)(228)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(80, 300);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(280, 35);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lnkForgot
            // 
            this.lnkForgot.AutoSize = true;
            this.lnkForgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(120)))), ((int)(((byte)(228)))));
            this.lnkForgot.Location = new System.Drawing.Point(260, 265);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(109, 16);
            this.lnkForgot.TabIndex = 7;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Forgot Password";
            // 
            // lblSignupText
            // 
            this.lblSignupText.AutoSize = true;
            this.lblSignupText.Location = new System.Drawing.Point(125, 360);
            this.lblSignupText.Name = "lblSignupText";
            this.lblSignupText.Size = new System.Drawing.Size(128, 16);
            this.lblSignupText.TabIndex = 8;
            this.lblSignupText.Text = "Don’t have account?";
            // 
            // lnkSignup
            // 
            this.lnkSignup.AutoSize = true;
            this.lnkSignup.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(120)))), ((int)(((byte)(228)))));
            this.lnkSignup.Location = new System.Drawing.Point(255, 360);
            this.lnkSignup.Name = "lnkSignup";
            this.lnkSignup.Size = new System.Drawing.Size(55, 16);
            this.lnkSignup.TabIndex = 9;
            this.lnkSignup.TabStop = true;
            this.lnkSignup.Text = "Sign Up";
            this.lnkSignup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignup_LinkClicked);
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkForgot;
        private System.Windows.Forms.Label lblSignupText;
        private System.Windows.Forms.LinkLabel lnkSignup;
    }
}
