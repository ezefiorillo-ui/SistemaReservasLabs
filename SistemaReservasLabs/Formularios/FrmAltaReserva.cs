using SistemaReservasLabs.Excepciones;
using SistemaReservasLabs.Logica;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaReservasLabs.Formularios
{
    public partial class FrmAltaReserva : Form
    {
        private readonly GestorReservas _gestorReservas;
        private readonly IRepositorio<Laboratorio> _repoLaboratorios;
        private readonly Usuario _usuarioLogueado;

        public FrmAltaReserva(GestorReservas gestorReservas, IRepositorio<Laboratorio> repoLaboratorios,
                               Usuario usuarioLogueado)
        {
            InitializeComponent();
            _gestorReservas = gestorReservas;
            _repoLaboratorios = repoLaboratorios;
            _usuarioLogueado = usuarioLogueado;

            cmbLaboratorio.DataSource = _repoLaboratorios.ListarTodos();
            cmbLaboratorio.DisplayMember = "Nombre";

            dtpFecha.MinDate = DateTime.Today; // no dejar elegir fechas pasadas

            Campos_Changed(this, EventArgs.Empty);
        }

        private void Campos_Changed(object sender, EventArgs e)
        {
            if (cmbLaboratorio.SelectedItem is not Laboratorio lab) return;

            bool disponible = _gestorReservas.ConsultarDisponibilidad(
                lab.Id, dtpFecha.Value, dtpHoraInicio.Value.TimeOfDay, dtpHoraFin.Value.TimeOfDay);

            lblDisponibilidad.Text = disponible ? "✅ Disponible" : "❌ No disponible";
            lblDisponibilidad.ForeColor = disponible ? Color.Green : Color.Red;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbLaboratorio.SelectedItem is not Laboratorio labSeleccionado)
            {
                MessageBox.Show("Seleccioná un laboratorio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan horaInicio = dtpHoraInicio.Value.TimeOfDay;
            TimeSpan horaFin = dtpHoraFin.Value.TimeOfDay;

            if (horaFin <= horaInicio)
            {
                MessageBox.Show("La hora de fin debe ser posterior a la hora de inicio.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idReserva = Guid.NewGuid().ToString();

                var nuevaReserva = new Reserva(
                    idReserva, labSeleccionado, _usuarioLogueado, dtpFecha.Value,
                    horaInicio, horaFin, txtMotivo.Text, EstadoReserva.Confirmada);

                _gestorReservas.CrearReserva(nuevaReserva);

                MessageBox.Show("Reserva creada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (ReservaSolapadaException ex)
            {
                MessageBox.Show(ex.Message, "Horario ocupado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (LaboratorioNoDisponibleException ex)
            {
                MessageBox.Show(ex.Message, "Laboratorio no disponible",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo reservar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmAltaReserva_Load(object sender, EventArgs e)
        {

        }
    }
}