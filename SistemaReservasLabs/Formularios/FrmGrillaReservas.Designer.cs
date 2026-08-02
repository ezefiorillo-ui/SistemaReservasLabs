namespace SistemaReservasLabs.Formularios
{
    partial class FrmGrillaReservas
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
            lblLaboratorio = new Label();
            lblFecha = new Label();
            cmbLaboratorio = new ComboBox();
            dtpFecha = new DateTimePicker();
            btnBuscar = new Button();
            dataGridView1 = new DataGridView();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblLaboratorio
            // 
            lblLaboratorio.AutoSize = true;
            lblLaboratorio.Location = new Point(20, 25);
            lblLaboratorio.Name = "lblLaboratorio";
            lblLaboratorio.Size = new Size(71, 15);
            lblLaboratorio.TabIndex = 0;
            lblLaboratorio.Text = "Laboratorio:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(340, 25);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(110, 22);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(200, 23);
            cmbLaboratorio.TabIndex = 2;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(390, 22);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 23);
            dtpFecha.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(560, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 25);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(640, 350);
            dataGridView1.TabIndex = 5;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(20, 425);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(150, 30);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar Reserva";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmGrillaReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(btnCancelar);
            Controls.Add(dataGridView1);
            Controls.Add(btnBuscar);
            Controls.Add(dtpFecha);
            Controls.Add(cmbLaboratorio);
            Controls.Add(lblFecha);
            Controls.Add(lblLaboratorio);
            Name = "FrmGrillaReservas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Grilla de Reservas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLaboratorio;
        private Label lblFecha;
        private ComboBox cmbLaboratorio;
        private DateTimePicker dtpFecha;
        private Button btnBuscar;
        private DataGridView dataGridView1;
        private Button btnCancelar;
    }
}