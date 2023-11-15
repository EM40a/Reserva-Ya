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
            dgvHotel = new DataGridView();
            btnImportar = new Button();
            btnExportar = new Button();
            sfdExportar = new SaveFileDialog();
            grpElegirRegistro = new GroupBox();
            rdbHuespedes = new RadioButton();
            rdbReservas = new RadioButton();
            txtBusqueda = new TextBox();
            btnEliminar = new Button();
            btnEditar = new Button();
            ofdImportar = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgvHotel).BeginInit();
            grpElegirRegistro.SuspendLayout();
            SuspendLayout();
            // 
            // lblReservas
            // 
            lblReservas.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            lblReservas.ForeColor = Color.FromArgb(12, 138, 199);
            lblReservas.Location = new Point(2, 104);
            lblReservas.Name = "lblReservas";
            lblReservas.Size = new Size(1062, 54);
            lblReservas.TabIndex = 2;
            lblReservas.Text = "SISTEMA DE BUSQUEDA";
            lblReservas.TextAlign = ContentAlignment.TopCenter;
            // 
            // dgvHotel
            // 
            dgvHotel.AllowUserToAddRows = false;
            dgvHotel.AllowUserToDeleteRows = false;
            dgvHotel.AllowUserToOrderColumns = true;
            dgvHotel.AllowUserToResizeRows = false;
            dgvHotel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHotel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHotel.Location = new Point(18, 256);
            dgvHotel.Name = "dgvHotel";
            dgvHotel.ReadOnly = true;
            dgvHotel.RowHeadersWidth = 51;
            dgvHotel.RowTemplate.Height = 29;
            dgvHotel.Size = new Size(1027, 294);
            dgvHotel.TabIndex = 6;
            // 
            // btnImportar
            // 
            btnImportar.BackColor = Color.White;
            btnImportar.Cursor = Cursors.Hand;
            btnImportar.FlatStyle = FlatStyle.Flat;
            btnImportar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnImportar.ForeColor = Color.FromArgb(12, 138, 199);
            btnImportar.ImeMode = ImeMode.NoControl;
            btnImportar.Location = new Point(536, 556);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(250, 56);
            btnImportar.TabIndex = 9;
            btnImportar.Text = "IMPORTAR";
            btnImportar.UseVisualStyleBackColor = false;
            btnImportar.Click += btnImportar_Click;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.FromArgb(12, 138, 199);
            btnExportar.Cursor = Cursors.Hand;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportar.ForeColor = Color.White;
            btnExportar.ImeMode = ImeMode.NoControl;
            btnExportar.Location = new Point(795, 556);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(250, 56);
            btnExportar.TabIndex = 10;
            btnExportar.Text = "EXPORTAR";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // sfdExportar
            // 
            sfdExportar.Filter = "Archivos JSON (*.json)|*.json|Archivos XML (*.xml)|*.xml";
            sfdExportar.Title = "Guardar archvo";
            // 
            // grpElegirRegistro
            // 
            grpElegirRegistro.Controls.Add(rdbHuespedes);
            grpElegirRegistro.Controls.Add(rdbReservas);
            grpElegirRegistro.Location = new Point(18, 184);
            grpElegirRegistro.Name = "grpElegirRegistro";
            grpElegirRegistro.Size = new Size(227, 66);
            grpElegirRegistro.TabIndex = 2;
            grpElegirRegistro.TabStop = false;
            // 
            // rdbHuespedes
            // 
            rdbHuespedes.AutoSize = true;
            rdbHuespedes.Cursor = Cursors.Hand;
            rdbHuespedes.Location = new Point(113, 26);
            rdbHuespedes.Name = "rdbHuespedes";
            rdbHuespedes.Size = new Size(103, 24);
            rdbHuespedes.TabIndex = 4;
            rdbHuespedes.Text = "Huespedes";
            rdbHuespedes.UseVisualStyleBackColor = true;
            rdbHuespedes.CheckedChanged += rdbHuespedes_CheckedChanged;
            // 
            // rdbReservas
            // 
            rdbReservas.AutoSize = true;
            rdbReservas.Checked = true;
            rdbReservas.Cursor = Cursors.Hand;
            rdbReservas.Location = new Point(20, 26);
            rdbReservas.Name = "rdbReservas";
            rdbReservas.Size = new Size(87, 24);
            rdbReservas.TabIndex = 3;
            rdbReservas.TabStop = true;
            rdbReservas.Text = "Reservas";
            rdbReservas.UseVisualStyleBackColor = true;
            rdbReservas.CheckedChanged += rdbReservas_CheckedChanged;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtBusqueda.Location = new Point(710, 213);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.PlaceholderText = " Buscar";
            txtBusqueda.Size = new Size(335, 34);
            txtBusqueda.TabIndex = 5;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.IndianRed;
            btnEliminar.ImeMode = ImeMode.NoControl;
            btnEliminar.Location = new Point(18, 556);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(250, 56);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.White;
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Enabled = false;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnEditar.ForeColor = Color.FromArgb(12, 138, 199);
            btnEditar.ImeMode = ImeMode.NoControl;
            btnEditar.Location = new Point(274, 556);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(250, 56);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // ofdImportar
            // 
            ofdImportar.FileName = "openFileDialog1";
            ofdImportar.Title = "Selecciona un archivo";
            // 
            // FrmBusqueda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 653);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(txtBusqueda);
            Controls.Add(grpElegirRegistro);
            Controls.Add(btnExportar);
            Controls.Add(btnImportar);
            Controls.Add(dgvHotel);
            Controls.Add(lblReservas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmBusqueda";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Busqueda";
            Load += FrmBusqueda_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHotel).EndInit();
            grpElegirRegistro.ResumeLayout(false);
            grpElegirRegistro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReservas;
        private DataGridView dgvHotel;
        private Button btnImportar;
        private Button btnExportar;
        private SaveFileDialog sfdExportar;
        private GroupBox grpElegirRegistro;
        private RadioButton rdbHuespedes;
        private RadioButton rdbReservas;
        private TextBox txtBusqueda;
        private Button btnEliminar;
        private Button btnEditar;
        private OpenFileDialog ofdImportar;
    }
}