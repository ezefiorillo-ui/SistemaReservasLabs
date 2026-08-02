using System;

namespace SistemaReservasLabs.Excepciones
{
    // Se lanza cuando se intenta agregar un registro (Laboratorio, Usuario o Reserva)
    // cuyo Id ya existe en el repositorio.
    public class RegistroDuplicadoException : Exception
    {
        public RegistroDuplicadoException() { }

        public RegistroDuplicadoException(string mensaje) : base(mensaje) { }

        public RegistroDuplicadoException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}