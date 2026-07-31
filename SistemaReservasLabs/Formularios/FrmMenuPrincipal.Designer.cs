namespace SistemaReservasLabs.Formularios
{
    partial class FrmMenuPrincipal
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
            lblUsuario = new Label();
            button1 = new Button();
            btnUsuarios = new Button();
            btnNuevaReserva = new Button();
            btnVerReservas = new Button();
            btnReportes = new Button();
            btnCerrarSesion = new Button();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsuario.Location = new Point(30, 25);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 17);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // button1
            // 
            button1.Location = new Point(100, 70);
            button1.Name = "button1";
            button1.Size = new Size(220, 35);
            button1.TabIndex = 1;
            button1.Text = "Gestión de Laboratorios";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(100, 115);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(220, 35);
            btnUsuarios.TabIndex = 2;
            btnUsuarios.Text = "Gestión de Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnNuevaReserva
            // 
            btnNuevaReserva.Location = new Point(100, 160);
            btnNuevaReserva.Name = "btnNuevaReserva";
            btnNuevaReserva.Size = new Size(220, 35);
            btnNuevaReserva.TabIndex = 3;
            btnNuevaReserva.Text = "Nueva Reserva";
            btnNuevaReserva.UseVisualStyleBackColor = true;
            // 
            // btnVerReservas
            // 
            btnVerReservas.Location = new Point(100, 205);
            btnVerReservas.Name = "btnVerReservas";
            btnVerReservas.Size = new Size(220, 35);
            btnVerReservas.TabIndex = 4;
            btnVerReservas.Text = "Ver Reservas";
            btnVerReservas.UseVisualStyleBackColor = true;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(100, 250);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(220, 35);
            btnReportes.TabIndex = 5;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(140, 305);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(140, 30);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 361);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnReportes);
            Controls.Add(btnVerReservas);
            Controls.Add(btnNuevaReserva);
            Controls.Add(btnUsuarios);
            Controls.Add(button1);
            Controls.Add(lblUsuario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private Button button1;
        private Button btnUsuarios;
        private Button btnNuevaReserva;
        private Button btnVerReservas;
        private Button btnReportes;
        private Button btnCerrarSesion;
    }
}