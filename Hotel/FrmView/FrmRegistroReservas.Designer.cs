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
            lblCalcularValor = new Label();
            lblReservas = new Label();
            lblValor = new Label();
            pnlLine = new Panel();
            cmbFormaPago = new ComboBox();
            label1 = new Label();
            btnSiguiente = new Button();
            dtpCheckOut = new DateTimePicker();
            lblCheckOut = new Label();
            dtpCheckIn = new DateTimePicker();
            lblCheckIn = new Label();
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
            pnlMain.BackgroundImageLayout = ImageLayout.Center;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(603, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(659, 785);
            pnlMain.TabIndex = 1;
            // 
            // pnlAside
            // 
            pnlAside.Controls.Add(lblCalcularValor);
            pnlAside.Controls.Add(lblReservas);
            pnlAside.Controls.Add(lblValor);
            pnlAside.Controls.Add(pnlLine);
            pnlAside.Controls.Add(cmbFormaPago);
            pnlAside.Controls.Add(label1);
            pnlAside.Controls.Add(btnSiguiente);
            pnlAside.Controls.Add(dtpCheckOut);
            pnlAside.Controls.Add(lblCheckOut);
            pnlAside.Controls.Add(dtpCheckIn);
            pnlAside.Controls.Add(lblCheckIn);
            pnlAside.Dock = DockStyle.Left;
            pnlAside.Location = new Point(0, 0);
            pnlAside.Name = "pnlAside";
            pnlAside.Size = new Size(603, 785);
            pnlAside.TabIndex = 0;
            // 
            // lblCalcularValor
            // 
            lblCalcularValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblCalcularValor.ForeColor = Color.DarkGray;
            lblCalcularValor.Location = new Point(72, 548);
            lblCalcularValor.Name = "lblCalcularValor";
            lblCalcularValor.Padding = new Padding(8, 0, 0, 0);
            lblCalcularValor.Size = new Size(457, 44);
            lblCalcularValor.TabIndex = 4;
            lblCalcularValor.Text = "$";
            lblCalcularValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblReservas
            // 
            lblReservas.AutoSize = true;
            lblReservas.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblReservas.ForeColor = Color.FromArgb(12, 138, 199);
            lblReservas.Location = new Point(75, 111);
            lblReservas.Name = "lblReservas";
            lblReservas.Size = new Size(454, 54);
            lblReservas.TabIndex = 12;
            lblReservas.Text = "SISTEMA DE RESERVAS";
            lblReservas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblValor.ForeColor = Color.DimGray;
            lblValor.ImeMode = ImeMode.NoControl;
            lblValor.Location = new Point(67, 514);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(276, 32);
            lblValor.TabIndex = 6;
            lblValor.Text = "VALOR DE LA RESERVA";
            lblValor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLine
            // 
            pnlLine.BackColor = Color.FromArgb(12, 138, 199);
            pnlLine.Location = new Point(72, 595);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(457, 4);
            pnlLine.TabIndex = 8;
            // 
            // cmbFormaPago
            // 
            cmbFormaPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFormaPago.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            cmbFormaPago.FormattingEnabled = true;
            cmbFormaPago.Location = new Point(72, 451);
            cmbFormaPago.Name = "cmbFormaPago";
            cmbFormaPago.Size = new Size(457, 39);
            cmbFormaPago.TabIndex = 3;
            cmbFormaPago.SelectedIndexChanged += cmbFormaPago_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DimGray;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(65, 414);
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
            btnSiguiente.Location = new Point(308, 620);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(221, 56);
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
            dtpCheckOut.Location = new Point(70, 351);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(459, 39);
            dtpCheckOut.TabIndex = 2;
            dtpCheckOut.Value = new DateTime(2023, 11, 9, 0, 0, 0, 0);
            dtpCheckOut.ValueChanged += dtpCheckOut_ValueChanged;
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lblCheckOut.ForeColor = Color.DimGray;
            lblCheckOut.ImeMode = ImeMode.NoControl;
            lblCheckOut.Location = new Point(65, 315);
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
            dtpCheckIn.Location = new Point(70, 252);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(459, 39);
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
            lblCheckIn.Location = new Point(65, 216);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(245, 32);
            lblCheckIn.TabIndex = 3;
            lblCheckIn.Text = "FECHA DE CHECK IN";
            lblCheckIn.TextAlign = ContentAlignment.MiddleLeft;
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmRegistroReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Reservas";
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
        private Label lblCheckIn;
        private DateTimePicker dtpCheckIn;
        private Label lblCheckOut;
        private Label lblValor;
        private Label lblCalcularValor;
        private Panel pnlLine;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label1;
        private ComboBox cmbFormaPago;
        private DateTimePicker dtpCheckOut;
        private Button btnSiguiente;
        private Label lblReservas;
    }
}