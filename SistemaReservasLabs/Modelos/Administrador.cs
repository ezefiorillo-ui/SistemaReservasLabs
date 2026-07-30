using System;
namespace SistemaReservasLaboratorios.Modelos
{
    public class Administrador : Usuario
    {
        public Administrador(string legajo, string nombre) : base(legajo, nombre) { }

        public override int ObtenerLimiteReservasSemanales() => int.MaxValue;

        public override bool PuedeCancelar(Reserva reserva) => true; // puede cancelar cualquier reserva

        public override string ObtenerTipoUsuario() => "Administrador";
    }


}