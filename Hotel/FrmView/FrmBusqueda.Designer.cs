namespace FrmView
{
    partial class FrmBusqueda
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
            lblReservas = new Label();
            dtgHotel = new DataGridView();
            IdReserva = new DataGridViewTextBoxColumn();
            FechaEntrada = new DataGridViewTextBoxColumn();
            FechaSalida = new DataGridViewTextBoxColumn();
            FormaDePago = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            btnImportar = new Button();
            btnExportar = new Button();
            cmbExtension = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dtgHotel).BeginInit();
            SuspendLayout();
            // 
            // lblReservas
            // 
            lblReservas.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblReservas.ForeColor = Color.FromArgb(12, 138, 199);
            lblReservas.Location = new Point(0, 140);
            lblReservas.Name = "lblReservas";
            lblReservas.Size = new Size(1261, 54);
            lblReservas.TabIndex = 2;
            lblReservas.Text = "SISTEMA DE BUSQUEDA";
            lblReservas.TextAlign = ContentAlignment.TopCenter;
            // 
            // dtgHotel
            // 
            dtgHotel.AllowUserToAddRows = false;
            dtgHotel.AllowUserToDeleteRows = false;
            dtgHotel.AllowUserToOrderColumns = true;
            dtgHotel.AllowUserToResizeRows = false;
            dtgHotel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgHotel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgHotel.Columns.AddRange(new DataGridViewColumn[] { IdReserva, FechaEntrada, FechaSalida, FormaDePago, Valor });
            dtgHotel.Location = new Point(81, 287);
            dtgHotel.Name = "dtgHotel";
            dtgHotel.ReadOnly = true;
            dtgHotel.RowHeadersWidth = 51;
            dtgHotel.RowTemplate.Height = 29;
            dtgHotel.Size = new Size(1100, 294);
            dtgHotel.TabIndex = 1;
            // 
            // IdReserva
            // 
            IdReserva.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            IdReserva.Frozen = true;
            IdReserva.HeaderText = "Id";
            IdReserva.MinimumWidth = 6;
            IdReserva.Name = "IdReserva";
            IdReserva.ReadOnly = true;
            IdReserva.Width = 125;
            // 
            // FechaEntrada
            // 
            FechaEntrada.HeaderText = "Check In";
            FechaEntrada.MinimumWidth = 6;
            FechaEntrada.Name = "FechaEntrada";
            FechaEntrada.ReadOnly = true;
            // 
            // FechaSalida
            // 
            FechaSalida.HeaderText = "Check Out";
            FechaSalida.MinimumWidth = 6;
            FechaSalida.Name = "FechaSalida";
            FechaSalida.ReadOnly = true;
            // 
            // FormaDePago
            // 
            FormaDePago.HeaderText = "Metodo de Pago";
            FormaDePago.MinimumWidth = 6;
            FormaDePago.Name = "FormaDePago";
            FormaDePago.ReadOnly = true;
            // 
            // Valor
            // 
            Valor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Valor.HeaderText = "Valor";
            Valor.MinimumWidth = 6;
            Valor.Name = "Valor";
            Valor.ReadOnly = true;
            // 
            // btnImportar
            // 
            btnImportar.BackColor = Color.White;
            btnImportar.Cursor = Cursors.Hand;
            btnImportar.Enabled = false;
            btnImportar.FlatStyle = FlatStyle.Flat;
            btnImportar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnImportar.ForeColor = Color.FromArgb(12, 138, 199);
            btnImportar.ImeMode = ImeMode.NoControl;
            btnImportar.Location = new Point(81, 645);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(221, 56);
            btnImportar.TabIndex = 7;
            btnImportar.Text = "IMPORTAR";
            btnImportar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.FromArgb(12, 138, 199);
            btnExportar.Cursor = Cursors.Hand;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportar.ForeColor = Color.White;
            btnExportar.ImeMode = ImeMode.NoControl;
            btnExportar.Location = new Point(308, 645);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(221, 56);
            btnExportar.TabIndex = 7;
            btnExportar.Text = "EXPORTAR";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // cmbExtension
            // 
            cmbExtension.Cursor = Cursors.Hand;
            cmbExtension.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbExtension.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            cmbExtension.ForeColor = Color.Gray;
            cmbExtension.FormattingEnabled = true;
            cmbExtension.Items.AddRange(new object[] { "JSON", "XML" });
            cmbExtension.Location = new Point(81, 604);
            cmbExtension.Name = "cmbExtension";
            cmbExtension.Size = new Size(450, 33);
            cmbExtension.TabIndex = 8;
            // 
            // FrmBusqueda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 785);
            Controls.Add(cmbExtension);
            Controls.Add(btnExportar);
            Controls.Add(btnImportar);
            Controls.Add(dtgHotel);
            Controls.Add(lblReservas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmBusqueda";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Busqueda";
            Load += FrmBusqueda_Load;
            ((System.ComponentModel.ISupportInitialize)dtgHotel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblReservas;
        private DataGridView dtgHotel;
        private DataGridViewTextBoxColumn IdReserva;
        private DataGridViewTextBoxColumn FechaEntrada;
        private DataGridViewTextBoxColumn FechaSalida;
        private DataGridViewTextBoxColumn FormaDePago;
        private DataGridViewTextBoxColumn Valor;
        private Button btnImportar;
        private Button btnExportar;
        private ComboBox cmbExtension;
    }
}