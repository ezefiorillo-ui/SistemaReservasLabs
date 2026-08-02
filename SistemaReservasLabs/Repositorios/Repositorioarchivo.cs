using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SistemaReservasLabs.Excepciones;

namespace SistemaReservasLabs.Repositorios
{
    // Repositorio genérico que persiste objetos de tipo T en un archivo de texto.
    // No sabe "de memoria" cómo convertir un T a texto: eso se lo pasan como
    // delegados (funciones) desde afuera, en el constructor. Así esta misma
    // clase sirve para Laboratorio, Usuario o Reserva sin repetir código.
    public class RepositorioArchivo<T> : IRepositorio<T>, IDisposable
    {
        private readonly string _rutaArchivo;
        private readonly Func<T, string> _serializar;      // T -> línea de texto
        private readonly Func<string, T> _deserializar;    // línea de texto -> T
        private readonly Func<T, string> _obtenerId;        // T -> su Id
        private StreamWriter _streamWriter;                 // recurso no administrado
        private bool _disposed = false;

        public RepositorioArchivo(string rutaArchivo,
                                   Func<T, string> serializar,
                                   Func<string, T> deserializar,
                                   Func<T, string> obtenerId)
        {
            _rutaArchivo = rutaArchivo;
            _serializar = serializar;
            _deserializar = deserializar;
            _obtenerId = obtenerId;

            if (!File.Exists(_rutaArchivo))
                File.Create(_rutaArchivo).Close();
        }

        public List<T> ListarTodos()
        {
            try
            {
                return File.ReadAllLines(_rutaArchivo)
                            .Where(linea => !string.IsNullOrWhiteSpace(linea))
                            .Select(linea => _deserializar(linea))
                            .ToList();
            }
            catch (Exception ex) when (!(ex is ArchivoDatosCorruptoException))
            {
                throw new ArchivoDatosCorruptoException(
                    $"No se pudo leer el archivo {_rutaArchivo}.", ex);
            }
        }

        public T ObtenerPorId(string id)
        {
            return ListarTodos().FirstOrDefault(item => _obtenerId(item) == id);
        }

        public void Agregar(T item)
        {
            var lista = ListarTodos();
            var id = _obtenerId(item);

            if (lista.Any(x => _obtenerId(x) == id))
                throw new RegistroDuplicadoException($"Ya existe un registro con Id '{id}'.");

            lista.Add(item);
            GuardarTodos(lista);
        }

        public void Actualizar(T item)
        {
            var lista = ListarTodos();
            var id = _obtenerId(item);
            var indice = lista.FindIndex(x => _obtenerId(x) == id);

            if (indice == -1)
                throw new ArchivoDatosCorruptoException($"No existe un registro con Id {id} para actualizar.");

            lista[indice] = item;
            GuardarTodos(lista);
        }

        public void Eliminar(string id)
        {
            var lista = ListarTodos();
            lista.RemoveAll(item => _obtenerId(item) == id);
            GuardarTodos(lista);
        }

        private void GuardarTodos(List<T> lista)
        {
            // using: abre el StreamWriter y garantiza que se cierre/libere
            // apenas termina el bloque, aunque ocurra una excepción adentro.
            using (_streamWriter = new StreamWriter(_rutaArchivo, append: false))
            {
                foreach (var item in lista)
                    _streamWriter.WriteLine(_serializar(item));
            }
        }

        // --- Implementación de IDisposable ---

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // ya liberamos a mano, que el GC no llame al finalizador
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _streamWriter?.Dispose(); // libera recursos administrados
            }

            _disposed = true;
        }

        // Finalizador: red de seguridad por si alguien se olvida de llamar Dispose()
        ~RepositorioArchivo()
        {
            Dispose(false);
        }
    }
}