namespace SistemaReservasLabs.Formularios
{
    partial class FrmAltaReserva
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
            cmbLaboratorio = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHoraInicio = new Label();
            lblHoraFin = new Label();
            lblMotivo = new Label();
            dtpHoraInicio = new DateTimePicker();
            dtpHoraFin = new DateTimePicker();
            btnConfirmar = new Button();
            txtMotivo = new TextBox();
            SuspendLayout();
            // 
            // lblLaboratorio
            // 
            lblLaboratorio.AutoSize = true;
            lblLaboratorio.Location = new Point(30, 25);
            lblLaboratorio.Name = "lblLaboratorio";
            lblLaboratorio.Size = new Size(71, 15);
            lblLaboratorio.TabIndex = 0;
            lblLaboratorio.Text = "Laboratorio:";
            // 
            // cmbLaboratorio
            // 
            cmbLaboratorio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLaboratorio.FormattingEnabled = true;
            cmbLaboratorio.Location = new Point(130, 22);
            cmbLaboratorio.Name = "cmbLaboratorio";
            cmbLaboratorio.Size = new Size(250, 23);
            cmbLaboratorio.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(30, 65);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(130, 65);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(213, 23);
            dtpFecha.TabIndex = 3;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(30, 105);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(68, 15);
            lblHoraInicio.TabIndex = 4;
            lblHoraInicio.Text = "Hora Inicio:";
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Location = new Point(30, 145);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(55, 15);
            lblHoraFin.TabIndex = 5;
            lblHoraFin.Text = "Hora Fin:";
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Location = new Point(30, 185);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(48, 15);
            lblMotivo.TabIndex = 6;
            lblMotivo.Text = "Motivo:";
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(130, 102);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.Size = new Size(84, 23);
            dtpHoraInicio.TabIndex = 7;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(130, 142);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.Size = new Size(84, 23);
            dtpHoraFin.TabIndex = 8;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(150, 270);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(150, 35);
            btnConfirmar.TabIndex = 9;
            btnConfirmar.Text = "Confirmar Reserva";
            btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(130, 182);
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(250, 60);
            txtMotivo.TabIndex = 10;
            // 
            // FrmAltaReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 361);
            Controls.Add(txtMotivo);
            Controls.Add(btnConfirmar);
            Controls.Add(dtpHoraFin);
            Controls.Add(dtpHoraInicio);
            Controls.Add(lblMotivo);
            Controls.Add(lblHoraFin);
            Controls.Add(lblHoraInicio);
            Controls.Add(dtpFecha);
            Controls.Add(lblFecha);
            Controls.Add(cmbLaboratorio);
            Controls.Add(lblLaboratorio);
            MinimizeBox = false;
            Name = "FrmAltaReserva";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nueva Reserva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLaboratorio;
        private ComboBox cmbLaboratorio;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblHoraInicio;
        private Label lblHoraFin;
        private Label lblMotivo;
        private DateTimePicker dtpHoraInicio;
        private DateTimePicker dtpHoraFin;
        private Button btnConfirmar;
        private TextBox txtMotivo;
    }
}