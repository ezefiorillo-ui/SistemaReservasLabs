using System;
using System.Collections.Generic;
using SistemaReservasLabs.Excepciones;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
using System;
using System.Windows.Forms;

namespace SistemaReservasLabs.Formularios
{
    public partial class FrmGestionUsuarios : Form
    {
        private readonly IRepositorio<Usuario> _repoUsuarios;

        public FrmGestionUsuarios(IRepositorio<Usuario> repoUsuarios)
        {
            InitializeComponent();
            _repoUsuarios = repoUsuarios;
        }

        private void FrmGestionUsuarios_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Administrador");
            cmbTipo.Items.Add("Docente");
            cmbTipo.Items.Add("Alumno");

            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = _repoUsuarios.ListarTodos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLegajo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Completá todos los campos.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Usuario nuevoUsuario = cmbTipo.SelectedItem.ToString() switch
                {
                    "Administrador" => new Administrador(txtLegajo.Text, txtNombre.Text),
                    "Docente" => new Docente(txtLegajo.Text, txtNombre.Text),
                    "Alumno" => new Alumno(txtLegajo.Text, txtNombre.Text),
                    _ => throw new InvalidOperationException("Tipo de usuario inválido.")
                };

                _repoUsuarios.Agregar(nuevoUsuario);

                CargarGrilla();
                txtLegajo.Clear();
                txtNombre.Clear();
                cmbTipo.SelectedIndex = -1;
            }
            catch (RegistroDuplicadoException ex)
            {
                MessageBox.Show(ex.Message, "Usuario duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}