using SistemaReservasLabs.Logica;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaReservasLabs.Formularios
{
    public partial class FrmGrillaReservas : Form
    {
        private readonly IRepositorio<Reserva> _repoReservas;
        private readonly IRepositorio<Laboratorio> _repoLaboratorios;
        private readonly GestorReservas _gestorReservas;
        private readonly Usuario _usuarioLogueado;

        public FrmGrillaReservas(IRepositorio<Reserva> repoReservas, IRepositorio<Laboratorio> repoLaboratorios,
                                  GestorReservas gestorReservas, Usuario usuarioLogueado)
        {
            InitializeComponent();
            _repoReservas = repoReservas;
            _repoLaboratorios = repoLaboratorios;
            _gestorReservas = gestorReservas;
            _usuarioLogueado = usuarioLogueado;

            // Combo con opción "Todos" + laboratorios reales
            cmbLaboratorio.Items.Add("Todos");
            foreach (var lab in _repoLaboratorios.ListarTodos())
                cmbLaboratorio.Items.Add(lab.Nombre);
            cmbLaboratorio.SelectedIndex = 0;

            CargarGrilla();
        }

        private void CargarGrilla()
        {
            var reservas = _repoReservas.ListarTodos().AsEnumerable();

            if (cmbLaboratorio.SelectedItem is string labSeleccionado && labSeleccionado != "Todos")
                reservas = reservas.Where(r => r.Laboratorio.Nombre == labSeleccionado);

            reservas = reservas.Where(r => r.Fecha.Date == dtpFecha.Value.Date);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reservas.ToList();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná una reserva de la grilla para cancelar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.CurrentRow.DataBoundItem is not Reserva reservaSeleccionada)
                return;

            var confirmacion = MessageBox.Show(
                $"¿Cancelar la reserva de {reservaSeleccionada.Usuario.Nombre} " +
                $"el {reservaSeleccionada.Fecha:d} de {reservaSeleccionada.HoraInicio} a {reservaSeleccionada.HoraFin}?",
                "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                _gestorReservas.CancelarReserva(reservaSeleccionada.Id, _usuarioLogueado);
                MessageBox.Show("Reserva cancelada.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Sin permiso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo cancelar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}