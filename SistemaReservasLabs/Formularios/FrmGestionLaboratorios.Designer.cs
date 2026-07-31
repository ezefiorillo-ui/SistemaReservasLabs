namespace SistemaReservasLabs.Formularios
{
    partial class FrmGestionLaboratorios
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
            lblId = new Label();
            lblNombre = new Label();
            lblUbicacion = new Label();
            lblCapacidad = new Label();
            lblEquipamiento = new Label();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtUbicacion = new TextBox();
            txtCapacidad = new TextBox();
            txtEquipamiento = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            dgvLaboratorios = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorios).BeginInit();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(20, 25);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Id:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(220, 25);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblUbicacion
            // 
            lblUbicacion.AutoSize = true;
            lblUbicacion.Location = new Point(20, 60);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(63, 15);
            lblUbicacion.TabIndex = 2;
            lblUbicacion.Text = "Ubicación:";
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Location = new Point(300, 60);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(89, 15);
            lblCapacidad.TabIndex = 3;
            lblCapacidad.Text = "Capacidad PCs:";
            // 
            // lblEquipamiento
            // 
            lblEquipamiento.AutoSize = true;
            lblEquipamiento.Location = new Point(20, 95);
            lblEquipamiento.Name = "lblEquipamiento";
            lblEquipamiento.Size = new Size(84, 15);
            lblEquipamiento.TabIndex = 4;
            lblEquipamiento.Text = "Equipamiento:";
            // 
            // txtId
            // 
            txtId.Location = new Point(100, 22);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(300, 22);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(180, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(100, 57);
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.Size = new Size(180, 23);
            txtUbicacion.TabIndex = 7;
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(420, 57);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(60, 23);
            txtCapacidad.TabIndex = 8;
            // 
            // txtEquipamiento
            // 
            txtEquipamiento.Location = new Point(120, 92);
            txtEquipamiento.Name = "txtEquipamiento";
            txtEquipamiento.Size = new Size(500, 23);
            txtEquipamiento.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(120, 130);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 30);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(230, 130);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 30);
            btnModificar.TabIndex = 11;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(340, 130);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 30);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvLaboratorios
            // 
            dgvLaboratorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLaboratorios.Location = new Point(20, 175);
            dgvLaboratorios.Name = "dgvLaboratorios";
            dgvLaboratorios.Size = new Size(640, 280);
            dgvLaboratorios.TabIndex = 13;
            // 
            // FrmGestionLaboratorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(dgvLaboratorios);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(txtEquipamiento);
            Controls.Add(txtCapacidad);
            Controls.Add(txtUbicacion);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(lblEquipamiento);
            Controls.Add(lblCapacidad);
            Controls.Add(lblUbicacion);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmGestionLaboratorios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Laboratorios";
            ((System.ComponentModel.ISupportInitialize)dgvLaboratorios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblNombre;
        private Label lblUbicacion;
        private Label lblCapacidad;
        private Label lblEquipamiento;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtUbicacion;
        private TextBox txtCapacidad;
        private TextBox txtEquipamiento;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private DataGridView dgvLaboratorios;
    }
}