using SistemaReservasLabs.Excepciones;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
using System;
using System.Windows.Forms;

namespace SistemaReservasLabs.Formularios
{
    public partial class FrmGestionLaboratorios : Form
    {
        private readonly IRepositorio<Laboratorio> _repoLaboratorios;

        public FrmGestionLaboratorios(IRepositorio<Laboratorio> repoLaboratorios)
        {
            InitializeComponent();
            _repoLaboratorios = repoLaboratorios;
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvLaboratorios.DataSource = null;
            dgvLaboratorios.DataSource = _repoLaboratorios.ListarTodos();
        }

        private bool ValidarCampos(out int capacidad)
        {
            capacidad = 0;

            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUbicacion.Text) ||
                string.IsNullOrWhiteSpace(txtCapacidad.Text))
            {
                MessageBox.Show("Completá todos los campos obligatorios.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtCapacidad.Text, out capacidad))
            {
                MessageBox.Show("Capacidad debe ser un número.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out int capacidad)) return;

            try
            {
                var nuevoLab = new Laboratorio(txtId.Text, txtNombre.Text, txtUbicacion.Text,
                                                capacidad, txtEquipamiento.Text);
                _repoLaboratorios.Agregar(nuevoLab);
                CargarGrilla();
                LimpiarCampos();
            }
            catch (RegistroDuplicadoException ex)
            {
                MessageBox.Show(ex.Message, "Laboratorio duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out int capacidad)) return;

            try
            {
                var labModificado = new Laboratorio(txtId.Text, txtNombre.Text, txtUbicacion.Text,
                                                     capacidad, txtEquipamiento.Text);
                _repoLaboratorios.Actualizar(labModificado);
                CargarGrilla();
                LimpiarCampos();
            }
            catch (ArchivoDatosCorruptoException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccioná un laboratorio de la grilla para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacion = MessageBox.Show($"¿Eliminar el laboratorio '{txtId.Text}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                _repoLaboratorios.Eliminar(txtId.Text);
                CargarGrilla();
                LimpiarCampos();
            }
        }

        private void dgvLaboratorios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvLaboratorios.Rows[e.RowIndex];
            txtId.Text = fila.Cells["Id"].Value?.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            txtUbicacion.Text = fila.Cells["Ubicacion"].Value?.ToString();
            txtCapacidad.Text = fila.Cells["CapacidadPCs"].Value?.ToString();
            txtEquipamiento.Text = fila.Cells["Equipamiento"].Value?.ToString();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtUbicacion.Clear();
            txtCapacidad.Clear();
            txtEquipamiento.Clear();
        }
    }
}