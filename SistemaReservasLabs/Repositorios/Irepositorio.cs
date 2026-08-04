using System.Collections.Generic;

namespace SistemaReservasLabs.Repositorios
{

    public interface IRepositorio<T>
    {
        void Agregar(T item);
        void Actualizar(T item);
        void Eliminar(string id);
        T ObtenerPorId(string id);
        List<T> ListarTodos();
    }
}