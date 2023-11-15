namespace FrmView
{
    partial class FrmMenuUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuUsuario));
            pnlContainer = new Panel();
            pnlMenu = new Panel();
            lblText = new Label();
            lblHero = new Label();
            lblBienvenido = new Label();
            pnlAside = new Panel();
            btnBusqueda = new Button();
            btnRegistro = new Button();
            pnlContainer.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlAside.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(pnlMenu);
            pnlContainer.Controls.Add(pnlAside);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1262, 785);
            pnlContainer.TabIndex = 2;
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = SystemColors.Control;
            pnlMenu.Controls.Add(lblText);
            pnlMenu.Controls.Add(lblHero);
            pnlMenu.Controls.Add(lblBienvenido);
            pnlMenu.Dock = DockStyle.Fill;
            pnlMenu.Location = new Point(300, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(962, 785);
            pnlMenu.TabIndex = 3;
            // 
            // lblText
            // 
            lblText.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblText.ForeColor = Color.FromArgb(19, 27, 35);
            lblText.ImeMode = ImeMode.NoControl;
            lblText.Location = new Point(3, 351);
            lblText.Name = "lblText";
            lblText.Padding = new Padding(32, 0, 32, 0);
            lblText.Size = new Size(961, 338);
            lblText.TabIndex = 7;
            lblText.Text = resources.GetString("lblText.Text");
            // 
            // lblHero
            // 
            lblHero.Font = new Font("Segoe UI", 32F, FontStyle.Bold, GraphicsUnit.Point);
            lblHero.ForeColor = Color.FromArgb(19, 27, 35);
            lblHero.ImeMode = ImeMode.NoControl;
            lblHero.Location = new Point(3, 1);
            lblHero.Name = "lblHero";
            lblHero.Size = new Size(964, 260);
            lblHero.TabIndex = 5;
            lblHero.Text = "SISTEMA DE RESERVAS";
            lblHero.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBienvenido
            // 
            lblBienvenido.AutoSize = true;
            lblBienvenido.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblBienvenido.ForeColor = Color.FromArgb(19, 27, 35);
            lblBienvenido.ImeMode = ImeMode.NoControl;
            lblBienvenido.Location = new Point(34, 281);
            lblBienvenido.Name = "lblBienvenido";
            lblBienvenido.Size = new Size(176, 41);
            lblBienvenido.TabIndex = 6;
            lblBienvenido.Text = "Bienvenido";
            // 
            // pnlAside
            // 
            pnlAside.BackColor = Color.FromArgb(12, 138, 199);
            pnlAside.Controls.Add(btnBusqueda);
            pnlAside.Controls.Add(btnRegistro);
            pnlAside.Dock = DockStyle.Left;
            pnlAside.Location = new Point(0, 0);
            pnlAside.Name = "pnlAside";
            pnlAside.Size = new Size(300, 785);
            pnlAside.TabIndex = 2;
            // 
            // btnBusqueda
            // 
            btnBusqueda.Cursor = Cursors.Hand;
            btnBusqueda.FlatAppearance.BorderSize = 0;
            btnBusqueda.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 117, 197);
            btnBusqueda.FlatStyle = FlatStyle.Flat;
            btnBusqueda.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnBusqueda.ForeColor = Color.White;
            btnBusqueda.ImageAlign = ContentAlignment.MiddleLeft;
            btnBusqueda.ImeMode = ImeMode.NoControl;
            btnBusqueda.Location = new Point(0, 340);
            btnBusqueda.Name = "btnBusqueda";
            btnBusqueda.Padding = new Padding(18, 0, 0, 0);
            btnBusqueda.Size = new Size(298, 68);
            btnBusqueda.TabIndex = 4;
            btnBusqueda.Text = "Busqueda";
            btnBusqueda.TextAlign = ContentAlignment.MiddleLeft;
            btnBusqueda.UseVisualStyleBackColor = true;
            btnBusqueda.Click += btnBusqueda_Click;
            // 
            // btnRegistro
            // 
            btnRegistro.Cursor = Cursors.Hand;
            btnRegistro.FlatAppearance.BorderSize = 0;
            btnRegistro.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 117, 197);
            btnRegistro.FlatStyle = FlatStyle.Flat;
            btnRegistro.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistro.ForeColor = Color.White;
            btnRegistro.ImageAlign = ContentAlignment.MiddleLeft;
            btnRegistro.ImeMode = ImeMode.NoControl;
            btnRegistro.Location = new Point(0, 278);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Padding = new Padding(18, 0, 0, 0);
            btnRegistro.Size = new Size(298, 68);
            btnRegistro.TabIndex = 3;
            btnRegistro.Text = "Registro de reservas";
            btnRegistro.TextAlign = ContentAlignment.MiddleLeft;
            btnRegistro.UseVisualStyleBackColor = true;
            btnRegistro.Click += btnRegistro_Click;
            // 
            // FrmMenuUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 785);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMenuUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu de Usuario";
            FormClosing += FrmMenuUsuario_FormClosing;
            pnlContainer.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlAside.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        internal Panel pnlContainer;
        private Panel pnlMenu;
        private Label lblText;
        private Label lblHero;
        private Label lblBienvenido;
        private Panel pnlAside;
        private Button btnBusqueda;
        private Button btnRegistro;
    }
}