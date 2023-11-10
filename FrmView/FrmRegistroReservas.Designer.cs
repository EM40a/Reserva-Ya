namespace FrmView
{
    partial class FrmRegistroReservas
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
            pnlContainer = new Panel();
            pnlMain = new Panel();
            pnlAside = new Panel();
            btnCalcularValor = new Button();
            cmbFormaPago = new ComboBox();
            label1 = new Label();
            btnSiguiente = new Button();
            dtpCheckOut = new DateTimePicker();
            panel1 = new Panel();
            lblCalcularValor = new Label();
            lblValor = new Label();
            lblCheckOut = new Label();
            dtpCheckIn = new DateTimePicker();
            lblCheckIn = new Label();
            lblReservas = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            pnlContainer.SuspendLayout();
            pnlAside.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(pnlMain);
            pnlContainer.Controls.Add(pnlAside);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1262, 785);
            pnlContainer.TabIndex = 0;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(12, 138, 199);
            pnlMain.BackgroundImage = Properties.Resources.reservas_img_3;
            pnlMain.BackgroundImageLayout = ImageLayout.Zoom;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(762, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(500, 785);
            pnlMain.TabIndex = 1;
            // 
            // pnlAside
            // 
            pnlAside.Controls.Add(btnCalcularValor);
            pnlAside.Controls.Add(cmbFormaPago);
            pnlAside.Controls.Add(label1);
            pnlAside.Controls.Add(btnSiguiente);
            pnlAside.Controls.Add(dtpCheckOut);
            pnlAside.Controls.Add(panel1);
            pnlAside.Controls.Add(lblCalcularValor);
            pnlAside.Controls.Add(lblValor);
            pnlAside.Controls.Add(lblCheckOut);
            pnlAside.Controls.Add(dtpCheckIn);
            pnlAside.Controls.Add(lblCheckIn);
            pnlAside.Controls.Add(lblReservas);
            pnlAside.Dock = DockStyle.Left;
            pnlAside.Location = new Point(0, 0);
            pnlAside.Name = "pnlAside";
            pnlAside.Size = new Size(762, 785);
            pnlAside.TabIndex = 0;
            // 
            // btnCalcularValor
            // 
            btnCalcularValor.Cursor = Cursors.Hand;
            btnCalcularValor.FlatStyle = FlatStyle.Flat;
            btnCalcularValor.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnCalcularValor.ForeColor = Color.FromArgb(12, 138, 199);
            btnCalcularValor.ImeMode = ImeMode.NoControl;
            btnCalcularValor.Location = new Point(107, 626);
            btnCalcularValor.Name = "btnCalcularValor";
            btnCalcularValor.Size = new Size(180, 56);
            btnCalcularValor.TabIndex = 5;
            btnCalcularValor.Text = "CALCULAR";
            btnCalcularValor.UseVisualStyleBackColor = false;
            btnCalcularValor.Click += btnCalcularValor_Click;
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPago.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(108, 562);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(541, 39);
            cmbFormaPago.TabIndex = 3;
            cmbFormaPago.SelectedIndexChanged += cmbFormaPago_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(108, 525);
            label1.Name = "label1";
            label1.Size = new Size(211, 32);
            label1.TabIndex = 11;
            label1.Text = "FORMA DE PAGO";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSiguiente
            // 
            btnSiguiente.BackColor = Color.FromArgb(12, 138, 199);
            btnSiguiente.Cursor = Cursors.Hand;
            btnSiguiente.FlatStyle = FlatStyle.Flat;
            btnSiguiente.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnSiguiente.ForeColor = Color.White;
            btnSiguiente.ImeMode = ImeMode.NoControl;
            btnSiguiente.Location = new Point(301, 625);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(180, 56);
            btnSiguiente.TabIndex = 6;
            btnSiguiente.Text = "SIGUIENTE";
            btnSiguiente.UseVisualStyleBackColor = false;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.CalendarFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dtpCheckOut.Checked = false;
            dtpCheckOut.Cursor = Cursors.Hand;
            dtpCheckOut.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            dtpCheckOut.Format = DateTimePickerFormat.Short;
            dtpCheckOut.Location = new Point(108, 351);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(543, 39);
            dtpCheckOut.TabIndex = 2;
            dtpCheckOut.Value = new DateTime(2023, 11, 9, 0, 0, 0, 0);
            dtpCheckOut.ValueChanged += dtpCheckOut_ValueChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(12, 138, 199);
            panel1.Location = new Point(106, 496);
            panel1.Name = "panel1";
            panel1.Size = new Size(541, 4);
            panel1.TabIndex = 8;
            // 
            // lblCalcularValor
            // 
            lblCalcularValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblCalcularValor.ForeColor = Color.DarkGray;
            lblCalcularValor.Location = new Point(106, 449);
            lblCalcularValor.Name = "lblCalcularValor";
            lblCalcularValor.Padding = new Padding(8, 0, 0, 0);
            lblCalcularValor.Size = new Size(541, 44);
            lblCalcularValor.TabIndex = 4;
            lblCalcularValor.Text = "$";
            lblCalcularValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblValor.ForeColor = Color.DimGray;
            lblValor.ImeMode = ImeMode.NoControl;
            lblValor.Location = new Point(106, 417);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(276, 32);
            lblValor.TabIndex = 6;
            lblValor.Text = "VALOR DE LA RESERVA";
            lblValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblCheckOut.ForeColor = Color.DimGray;
            lblCheckOut.ImeMode = ImeMode.NoControl;
            lblCheckOut.Location = new Point(106, 316);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(267, 32);
            lblCheckOut.TabIndex = 5;
            lblCheckOut.Text = "FECHA DE CHECK OUT";
            lblCheckOut.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.CalendarFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dtpCheckIn.Checked = false;
            dtpCheckIn.Cursor = Cursors.Hand;
            dtpCheckIn.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            dtpCheckIn.Format = DateTimePickerFormat.Short;
            dtpCheckIn.Location = new Point(108, 249);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(541, 39);
            dtpCheckIn.TabIndex = 1;
            dtpCheckIn.Value = new DateTime(2023, 11, 8, 0, 0, 0, 0);
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblCheckIn.ForeColor = Color.DimGray;
            lblCheckIn.ImeMode = ImeMode.NoControl;
            lblCheckIn.Location = new Point(106, 214);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(245, 32);
            lblCheckIn.TabIndex = 3;
            lblCheckIn.Text = "FECHA DE CHECK IN";
            lblCheckIn.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblReservas
            // 
            lblReservas.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblReservas.ForeColor = Color.FromArgb(12, 138, 199);
            lblReservas.Location = new Point(0, 112);
            lblReservas.Name = "lblReservas";
            lblReservas.Size = new Size(759, 54);
            lblReservas.TabIndex = 1;
            lblReservas.Text = "SISTEMA DE RESERVAS";
            lblReservas.TextAlign = ContentAlignment.TopCenter;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // FrmRegistroReservas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 785);
            Controls.Add(pnlContainer);
            MaximizeBox = false;
            Name = "FrmRegistroReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Reservas";
            FormClosing += FrmRegistroReservas_FormClosing;
            Load += FrmRegistroReservas_Load;
            pnlContainer.ResumeLayout(false);
            pnlAside.ResumeLayout(false);
            pnlAside.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
        private Panel pnlAside;
        private Panel pnlMain;
        private Label lblReservas;
        private Label lblCheckIn;
        private DateTimePicker dtpCheckIn;
        private Label lblCheckOut;
        private Label lblValor;
        private Label lblCalcularValor;
        private Panel panel1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label1;
        private ComboBox cmbFormaPago;
        private DateTimePicker dtpCheckOut;
        private Button btnSiguiente;
        private Button btnCalcularValor;
    }
}