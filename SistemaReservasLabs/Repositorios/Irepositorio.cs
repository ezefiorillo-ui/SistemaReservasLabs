using System.Collections.Generic;

namespace SistemaReservasLabs.Repositorios
{
    // Interfaz genérica: define el "contrato" que cualquier repositorio debe
    // cumplir, sin importar si guarda Laboratorios, Usuarios o Reservas.
    // T es un parámetro de tipo: se reemplaza por la clase real al usarla
    // (IRepositorio<Laboratorio>, IRepositorio<Reserva>, etc.)
    public interface IRepositorio<T>
    {
        void Agregar(T item);
        void Actualizar(T item);
        void Eliminar(string id);
        T ObtenerPorId(string id);
        List<T> ListarTodos();
    }
}