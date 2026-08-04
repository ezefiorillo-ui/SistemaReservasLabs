using System;
using System.Linq;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
using SistemaReservasLabs.Excepciones;

namespace SistemaReservasLabs.Logica
{
    public class GestorReservas
    {
        private readonly IRepositorio<Reserva> _repoReservas;
        private readonly IRepositorio<Laboratorio> _repoLaboratorios;

        public event Action<Reserva> ReservaCreada;
        public event Action<Reserva> ReservaCancelada;

        public GestorReservas(IRepositorio<Reserva> repoReservas, IRepositorio<Laboratorio> repoLaboratorios)
        {
            _repoReservas = repoReservas;
            _repoLaboratorios = repoLaboratorios;
        }

        public void CrearReserva(Reserva nuevaReserva)
        {
            try
            {
                // 1. Validar que el laboratorio exista
                var lab = _repoLaboratorios.ObtenerPorId(nuevaReserva.Laboratorio.Id);
                if (lab == null)
                    throw new LaboratorioNoDisponibleException(
                        $"El laboratorio '{nuevaReserva.Laboratorio.Id}' no existe.");

                // 2. Validar límite semanal del usuario (polimorfismo: cada rol devuelve el suyo)
                int reservasEstaSemana = _repoReservas.ListarTodos()
                    .Count(r => r.Usuario.Legajo == nuevaReserva.Usuario.Legajo
                             && EsMismaSemana(r.Fecha, nuevaReserva.Fecha)
                             && r.Estado != EstadoReserva.Cancelada);

                if (reservasEstaSemana >= nuevaReserva.Usuario.ObtenerLimiteReservasSemanales())
                    throw new InvalidOperationException(
                        $"{nuevaReserva.Usuario.Nombre} alcanzó su límite semanal de reservas.");

                // 3. Validar anticipación máxima según el rol
                int diasDeAnticipacion = (nuevaReserva.Fecha.Date - DateTime.Today).Days;

                if (diasDeAnticipacion > nuevaReserva.Usuario.ObtenerAnticipacionMaximaDias())
                    throw new InvalidOperationException(
                        $"{nuevaReserva.Usuario.Nombre} no puede reservar con más de " +
                        $"{nuevaReserva.Usuario.ObtenerAnticipacionMaximaDias()} días de anticipación.");

                // 4. Validar solapamiento con LINQ
                bool haySolapamiento = _repoReservas.ListarTodos().Any(r =>
                    r.Laboratorio.Id == nuevaReserva.Laboratorio.Id &&
                    r.Fecha.Date == nuevaReserva.Fecha.Date &&
                    r.Estado != EstadoReserva.Cancelada &&
                    r.HoraInicio < nuevaReserva.HoraFin &&
                    nuevaReserva.HoraInicio < r.HoraFin);

                if (haySolapamiento)
                    throw new ReservaSolapadaException(
                        $"Ya existe una reserva para el laboratorio {lab.Nombre} en ese horario.");

                // 5. Si pasó todas las validaciones, se guarda
                _repoReservas.Agregar(nuevaReserva);
                ReservaCreada?.Invoke(nuevaReserva);
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine($"Intento de creación de reserva procesado: {nuevaReserva.Id}");
            }
        }

        public void CancelarReserva(string idReserva, Usuario usuarioQueCancelca)
        {
            var reserva = _repoReservas.ObtenerPorId(idReserva);
            if (reserva == null)
                throw new InvalidOperationException($"No existe la reserva '{idReserva}'.");

            if (!usuarioQueCancelca.PuedeCancelar(reserva))
                throw new UnauthorizedAccessException("No tenés permiso para cancelar esta reserva.");

            reserva.Estado = EstadoReserva.Cancelada;
            _repoReservas.Actualizar(reserva);

            ReservaCancelada?.Invoke(reserva);
        }

        // Consulta de disponibilidad: ¿está libre el laboratorio en ese rango horario?
        public bool ConsultarDisponibilidad(string idLaboratorio, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            bool ocupado = _repoReservas.ListarTodos().Any(r =>
                r.Laboratorio.Id == idLaboratorio &&
                r.Fecha.Date == fecha.Date &&
                r.Estado != EstadoReserva.Cancelada &&
                r.HoraInicio < horaFin &&
                horaInicio < r.HoraFin);

            return !ocupado;
        }

        private bool EsMismaSemana(DateTime fecha1, DateTime fecha2)
        {
            var inicioSemana1 = fecha1.AddDays(-(int)fecha1.DayOfWeek);
            var inicioSemana2 = fecha2.AddDays(-(int)fecha2.DayOfWeek);
            return inicioSemana1.Date == inicioSemana2.Date;
        }
    }
}