using System;

namespace SistemaReservasLabs.Modelos
{
    public abstract class Usuario
    {
        //Campos
        private string _legajo;
        private string _nombre;

        //Propiedades
        public string Legajo
        {
            get => _legajo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El legajo no puede estar vacío.");
                _legajo = value;
            }
        }

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                _nombre = value;
            }
        }
        //Constructor
        protected Usuario(string legajo, string nombre)
        {
            Legajo = legajo;
            Nombre = nombre;
        }

        // Métodos abstractos: cada subclase (Administrador, Docente, Alumno)
        // los implementa a su manera -> polimorfismo, sin if/switch por TipoUsuario.
        public abstract int ObtenerLimiteReservasSemanales();
        public abstract bool PuedeCancelar(Reserva reserva);

        // Útil para mostrar el rol en la UI sin usar un campo "TipoUsuario" propio.
        public abstract string ObtenerTipoUsuario();


        // Para que el ComboBox muestre nombre y rol en vez del tipo del objeto
        public override string ToString()
        {
            return $"{Nombre} ({ObtenerTipoUsuario()})";
        }

    }

}