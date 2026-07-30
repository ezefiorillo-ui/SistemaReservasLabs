using System;

namespace SistemaReservasLaboratorios.Modelos
{
    public class Laboratorio
    {
        private int _capacidadPCs;

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

        public int CapacidadPCs
        {
            get => _capacidadPCs;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La capacidad debe ser mayor a cero.");
                _capacidadPCs = value;
            }
        }

        public string Equipamiento { get; set; }

        public Laboratorio(string id, string nombre, string ubicacion, int capacidadPCs, string equipamiento)
        {
            Id = id;
            Nombre = nombre;
            Ubicacion = ubicacion;
            CapacidadPCs = capacidadPCs;
            Equipamiento = equipamiento;
        }
    }
}