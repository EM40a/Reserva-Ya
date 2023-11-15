namespace FrmView
{
    partial class FrmRegistroUsuario
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
            pnlMain = new Panel();
            lblNombre = new Label();
            lblApellido = new Label();
            btnGuardar = new Button();
            panel1 = new Panel();
            lblHusuarios = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            pnlAside = new Panel();
            lblIdReserva = new Label();
            panel4 = new Panel();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            dtpFechaDeNacimiento = new DateTimePicker();
            lblValor = new Label();
            label1 = new Label();
            pnlAside.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(12, 138, 199);
            pnlMain.BackgroundImage = Properties.Resources.registro;
            pnlMain.BackgroundImageLayout = ImageLayout.Center;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(659, 785);
            pnlMain.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.ForeColor = Color.DimGray;
            lblNombre.ImeMode = ImeMode.NoControl;
            lblNombre.Location = new Point(65, 220);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(99, 28);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "NOMBRE";
            lblNombre.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblApellido.ForeColor = Color.DimGray;
            lblApellido.ImeMode = ImeMode.NoControl;
            lblApellido.Location = new Point(308, 220);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(105, 28);
            lblApellido.TabIndex = 5;
            lblApellido.Text = "APELLIDO";
            lblApellido.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(12, 138, 199);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.ImeMode = ImeMode.NoControl;
            btnGuardar.Location = new Point(308, 620);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(221, 56);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(12, 138, 199);
            panel1.Location = new Point(315, 290);
            panel1.Name = "panel1";
            panel1.Size = new Size(223, 4);
            panel1.TabIndex = 8;
            // 
            // lblHusuarios
            // 
            lblHusuarios.AutoSize = true;
            lblHusuarios.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblHusuarios.ForeColor = Color.FromArgb(12, 138, 199);
            lblHusuarios.Location = new Point(75, 111);
            lblHusuarios.Name = "lblHusuarios";
            lblHusuarios.Size = new Size(464, 54);
            lblHusuarios.TabIndex = 12;
            lblHusuarios.Text = "REGISTRO DE HUESPED";
            lblHusuarios.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.Control;
            txtNombre.BorderStyle = BorderStyle.None;
            txtNombre.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(75, 260);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 25);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = SystemColors.Control;
            txtApellido.BorderStyle = BorderStyle.None;
            txtApellido.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtApellido.Location = new Point(324, 259);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(210, 25);
            txtApellido.TabIndex = 2;
            // 
            // pnlAside
            // 
            pnlAside.Controls.Add(lblIdReserva);
            pnlAside.Controls.Add(panel4);
            pnlAside.Controls.Add(txtTelefono);
            pnlAside.Controls.Add(lblTelefono);
            pnlAside.Controls.Add(panel3);
            pnlAside.Controls.Add(panel2);
            pnlAside.Controls.Add(dtpFechaDeNacimiento);
            pnlAside.Controls.Add(txtApellido);
            pnlAside.Controls.Add(txtNombre);
            pnlAside.Controls.Add(lblHusuarios);
            pnlAside.Controls.Add(lblValor);
            pnlAside.Controls.Add(panel1);
            pnlAside.Controls.Add(label1);
            pnlAside.Controls.Add(btnGuardar);
            pnlAside.Controls.Add(lblApellido);
            pnlAside.Controls.Add(lblNombre);
            pnlAside.Dock = DockStyle.Right;
            pnlAside.Location = new Point(659, 0);
            pnlAside.Name = "pnlAside";
            pnlAside.Size = new Size(603, 785);
            pnlAside.TabIndex = 2;
            // 
            // lblIdReserva
            // 
            lblIdReserva.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblIdReserva.ForeColor = Color.DarkGray;
            lblIdReserva.Location = new Point(75, 552);
            lblIdReserva.Name = "lblIdReserva";
            lblIdReserva.Padding = new Padding(8, 0, 0, 0);
            lblIdReserva.Size = new Size(457, 44);
            lblIdReserva.TabIndex = 5;
            lblIdReserva.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(12, 138, 199);
            panel4.Location = new Point(78, 498);
            panel4.Name = "panel4";
            panel4.Size = new Size(457, 4);
            panel4.TabIndex = 20;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = SystemColors.Control;
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.Location = new Point(75, 460);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "  2345-6789";
            txtTelefono.Size = new Size(457, 25);
            txtTelefono.TabIndex = 4;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTelefono.ForeColor = Color.DimGray;
            lblTelefono.ImeMode = ImeMode.NoControl;
            lblTelefono.Location = new Point(67, 415);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(112, 28);
            lblTelefono.TabIndex = 18;
            lblTelefono.Text = "TELEFONO";
            lblTelefono.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(12, 138, 199);
            panel3.Location = new Point(78, 599);
            panel3.Name = "panel3";
            panel3.Size = new Size(457, 4);
            panel3.TabIndex = 16;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(12, 138, 199);
            panel2.Location = new Point(71, 290);
            panel2.Name = "panel2";
            panel2.Size = new Size(228, 4);
            panel2.TabIndex = 14;
            // 
            // dtpFechaDeNacimiento
            // 
            dtpFechaDeNacimiento.CalendarFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFechaDeNacimiento.Checked = false;
            dtpFechaDeNacimiento.Cursor = Cursors.Hand;
            dtpFechaDeNacimiento.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFechaDeNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaDeNacimiento.Location = new Point(75, 357);
            dtpFechaDeNacimiento.Name = "dtpFechaDeNacimiento";
            dtpFechaDeNacimiento.Size = new Size(459, 39);
            dtpFechaDeNacimiento.TabIndex = 3;
            dtpFechaDeNacimiento.Value = new DateTime(2023, 8, 11, 0, 0, 0, 0);
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblValor.ForeColor = Color.DimGray;
            lblValor.ImeMode = ImeMode.NoControl;
            lblValor.Location = new Point(67, 519);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(223, 28);
            lblValor.TabIndex = 6;
            lblValor.Text = "NUMERO DE RESERVA";
            lblValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(71, 320);
            label1.Name = "label1";
            label1.Size = new Size(232, 28);
            label1.TabIndex = 11;
            label1.Text = "FECHA DE NACIMENTO";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmRegistroUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 785);
            Controls.Add(pnlMain);
            Controls.Add(pnlAside);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmRegistroUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Usuario";
            Load += FrmRegistroUsuario_Load;
            pnlAside.ResumeLayout(false);
            pnlAside.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Label lblNombre;
        private Label lblApellido;
        private Button btnGuardar;
        private Panel panel1;
        private Label lblHusuarios;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Panel pnlAside;
        private Panel panel3;
        private Panel panel2;
        private Label lblValor;
        private Panel panel4;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private DateTimePicker dtpFechaDeNacimiento;
        private Label label1;
        private Label lblIdReserva;
    }
}