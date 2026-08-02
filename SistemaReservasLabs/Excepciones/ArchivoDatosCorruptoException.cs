using System;

namespace SistemaReservasLabs.Excepciones
{
    // Se lanza cuando un archivo .txt de datos no se puede leer, o su contenido
    // no respeta el formato esperado (separador "|", cantidad de campos, etc.)
    public class ArchivoDatosCorruptoException : Exception
    {
        public ArchivoDatosCorruptoException() { }

        public ArchivoDatosCorruptoException(string mensaje) : base(mensaje) { }

        public ArchivoDatosCorruptoException(string mensaje, Exception innerException)
            : base(mensaje, innerException) { }
    }
}