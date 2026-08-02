using SistemaReservasLabs.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasLabs.Modelos
{
    public class Alumno : Usuario
    {
        // TODO: definir con el equipo el límite semanal real de Alumno (más bajo que Docente)
        private const int LimiteSemanal = 2;

        public Alumno(string legajo, string nombre) : base(legajo, nombre) { }

        public override int ObtenerLimiteReservasSemanales() => LimiteSemanal;

        public override bool PuedeCancelar(Reserva reserva) =>
            reserva.Usuario.Legajo == this.Legajo; // solo sus propias reservas

        public override string ObtenerTipoUsuario() => "Alumno";
    }
}
