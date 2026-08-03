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

            dtpFecha.ShowCheckBox = true;   //para consultar reservas en todas las fechas 
            dtpFecha.Checked = false;       //para consultar reservas en todas las fechas

            ConfigurarColumnasGrilla();
            //CargarGrilla();
        }

        private void ConfigurarColumnasGrilla()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "LaboratorioNombre", HeaderText = "Laboratorio", Width = 150 });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "UsuarioNombre", HeaderText = "Usuario", Width = 150 });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Fecha", HeaderText = "Fecha", Width = 90 });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "HoraInicio", HeaderText = "Desde", Width = 70 });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "HoraFin", HeaderText = "Hasta", Width = 70 });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { DataPropertyName = "Estado", HeaderText = "Estado", Width = 90 });
        }

        private void CargarGrilla()
        {
            var reservas = _repoReservas.ListarTodos().AsEnumerable();

            if (cmbLaboratorio.SelectedItem is string labSeleccionado && labSeleccionado != "Todos")
                reservas = reservas.Where(r => r.Laboratorio.Nombre == labSeleccionado);

            if (dtpFecha.Checked) //para consultar reservas en todas las fechas

                reservas = reservas.Where(r => r.Fecha.Date == dtpFecha.Value.Date);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reservas.ToList();

            ColorearFilasPorEstado();
        }

        private void ColorearFilasPorEstado()
        {
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.DataBoundItem is not Reserva reserva) continue;

                fila.DefaultCellStyle.BackColor = reserva.Estado switch
                {
                    EstadoReserva.Confirmada => Color.FromArgb(144, 190, 235),  // azul medio = ocupado
                    EstadoReserva.Pendiente => Color.FromArgb(200, 222, 245),   // azul claro = pendiente
                    EstadoReserva.Cancelada => Color.FromArgb(224, 224, 224),  // gris = cancelada/libre
                    _ => Color.White
                };
            }
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