namespace SistemaReservasLabs.Formularios
{
    partial class FrmReportes
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
            lblTipoReporte = new Label();
            cmbTipoReporte = new ComboBox();
            btnGenerar = new Button();
            dgvReporte = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Location = new Point(20, 25);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new Size(94, 15);
            lblTipoReporte.TabIndex = 0;
            lblTipoReporte.Text = "Tipo de Reporte:";
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Location = new Point(140, 22);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new Size(250, 23);
            cmbTipoReporte.TabIndex = 1;
            // 
            // btnGenerar
            // 
            btnGenerar.Location = new Point(410, 21);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(100, 25);
            btnGenerar.TabIndex = 2;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            // 
            // dgvReporte
            // 
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(20, 65);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.Size = new Size(590, 380);
            dgvReporte.TabIndex = 3;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 461);
            Controls.Add(dgvReporte);
            Controls.Add(btnGenerar);
            Controls.Add(cmbTipoReporte);
            Controls.Add(lblTipoReporte);
            Name = "FrmReportes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipoReporte;
        private ComboBox cmbTipoReporte;
        private Button btnGenerar;
        private DataGridView dgvReporte;
    }
}