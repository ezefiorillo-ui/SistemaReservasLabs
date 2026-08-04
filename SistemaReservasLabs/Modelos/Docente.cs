using SistemaReservasLabs.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservasLabs.Modelos
{

    public class Docente : Usuario
    {
        private const int LimiteSemanal = 5;

        public Docente(string legajo, string nombre) : base(legajo, nombre) { }

        public override int ObtenerLimiteReservasSemanales() => LimiteSemanal;

        public override bool PuedeCancelar(Reserva reserva) =>
            reserva.Usuario.Legajo == this.Legajo; // solo sus propias reservas

		public override int ObtenerAnticipacionMaximaDias() => 30; // hasta 30 días antes

		public override string ObtenerTipoUsuario() => "Docente";
    }

}
