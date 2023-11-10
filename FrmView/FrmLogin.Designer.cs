namespace FrmView
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            pnlMain = new Panel();
            btnIngresar = new Button();
            txtClave = new TextBox();
            lblClave = new Label();
            txtUsuario = new TextBox();
            pnlRight = new Panel();
            lblUsuario = new Label();
            lblTitulo = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(btnIngresar);
            pnlMain.Controls.Add(txtClave);
            pnlMain.Controls.Add(lblClave);
            pnlMain.Controls.Add(txtUsuario);
            pnlMain.Controls.Add(pnlRight);
            pnlMain.Controls.Add(lblUsuario);
            pnlMain.Controls.Add(lblTitulo);
            resources.ApplyResources(pnlMain, "pnlMain");
            pnlMain.Name = "pnlMain";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(12, 138, 199);
            btnIngresar.Cursor = Cursors.Hand;
            resources.ApplyResources(btnIngresar, "btnIngresar");
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Name = "btnIngresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // txtClave
            // 
            txtClave.BackColor = SystemColors.Control;
            txtClave.Cursor = Cursors.IBeam;
            resources.ApplyResources(txtClave, "txtClave");
            txtClave.ForeColor = SystemColors.ControlDarkDark;
            txtClave.Name = "txtClave";
            // 
            // lblClave
            // 
            resources.ApplyResources(lblClave, "lblClave");
            lblClave.ForeColor = Color.DimGray;
            lblClave.Name = "lblClave";
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = SystemColors.Control;
            txtUsuario.Cursor = Cursors.IBeam;
            resources.ApplyResources(txtUsuario, "txtUsuario");
            txtUsuario.ForeColor = SystemColors.ControlDarkDark;
            txtUsuario.Name = "txtUsuario";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(12, 138, 199);
            pnlRight.BackgroundImage = Properties.Resources.img_hotel_login_;
            resources.ApplyResources(pnlRight, "pnlRight");
            pnlRight.Name = "pnlRight";
            // 
            // lblUsuario
            // 
            resources.ApplyResources(lblUsuario, "lblUsuario");
            lblUsuario.ForeColor = Color.DimGray;
            lblUsuario.Name = "lblUsuario";
            // 
            // lblTitulo
            // 
            resources.ApplyResources(lblTitulo, "lblTitulo");
            lblTitulo.ForeColor = Color.FromArgb(12, 138, 199);
            lblTitulo.Name = "lblTitulo";
            // 
            // FrmLogin
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            MaximizeBox = false;
            Name = "FrmLogin";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Label lblTitulo;
        private Label lblUsuario;
        private Panel pnlRight;
        private TextBox txtClave;
        private Label lblClave;
        private TextBox txtUsuario;
        private Button btnIngresar;
    }
}