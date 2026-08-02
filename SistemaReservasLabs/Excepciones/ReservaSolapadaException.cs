using System;

namespace SistemaReservasLabs.Excepciones
{
    // Se lanza cuando una nueva reserva pisa el horario de otra ya existente
    // en el mismo laboratorio y la misma fecha.
    public class ReservaSolapadaException : Exception
    {
        public ReservaSolapadaException() { }

        public ReservaSolapadaException(string mensaje) : base(mensaje) { }

        // Constructor con inner exception: útil si esta excepción se lanza
        // dentro de un catch de otra más general, y querés conservar el detalle original.
        public ReservaSolapadaException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}