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
            lblReservas.Text = "SISTEMA DE BUSQUEDAS";
            lblReservas.TextAlign = ContentAlignment.TopCenter;
            // 
            // FrmBusqueda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 785);
            Controls.Add(lblReservas);
            Name = "FrmBusqueda";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label lblReservas;
    }
}