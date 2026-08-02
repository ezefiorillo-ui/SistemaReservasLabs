using System;

namespace SistemaReservasLabs.Modelos
{
    public enum EstadoReserva
    {
        Pendiente,
        Confirmada,
        Cancelada
    }

    public class Reserva
    {
        private TimeSpan _horaInicio;
        private TimeSpan _horaFin;

        public string Id { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }

        public TimeSpan HoraInicio
        {
            get => _horaInicio;
            set => _horaInicio = value;
        }

        public TimeSpan HoraFin
        {
            get => _horaFin;
            set
            {
                if (value <= _horaInicio)
                    throw new ArgumentException("HoraFin no puede ser anterior o igual a HoraInicio.");
                _horaFin = value;
            }
        }

        public string Motivo { get; set; }
        public EstadoReserva Estado { get; set; }

        // Propiedades calculadas
        public TimeSpan DuracionReserva => HoraFin - HoraInicio;

        public bool EstaVencida =>
            Fecha.Date < DateTime.Now.Date ||
            (Fecha.Date == DateTime.Now.Date && HoraFin < DateTime.Now.TimeOfDay);

        // Constructor completo (con motivo)
        public Reserva(string id, Laboratorio laboratorio, Usuario usuario, DateTime fecha,
                        TimeSpan horaInicio, TimeSpan horaFin, string motivo, EstadoReserva estado)
        {
            Id = id;
            Laboratorio = laboratorio;
            Usuario = usuario;
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraFin = horaFin; // dispara la validación del setter
            Motivo = motivo;
            Estado = estado;
        }

        // Constructor sobrecargado (sin motivo) -> encadena con : this(...)
        public Reserva(string id, Laboratorio laboratorio, Usuario usuario, DateTime fecha,
                        TimeSpan horaInicio, TimeSpan horaFin, EstadoReserva estado)
            : this(id, laboratorio, usuario, fecha, horaInicio, horaFin, motivo: string.Empty, estado)
        {
        }
    }
}