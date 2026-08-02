using System;

namespace SistemaReservasLabs.Excepciones
{
    // Se lanza cuando se intenta reservar un laboratorio que no existe,
    // o que existe pero no está habilitado para reservas.
    public class LaboratorioNoDisponibleException : Exception
    {
        public LaboratorioNoDisponibleException() { }

        public LaboratorioNoDisponibleException(string mensaje) : base(mensaje) { }

        public LaboratorioNoDisponibleException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}