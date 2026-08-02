using SistemaReservasLabs.Formularios;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
using SistemaReservasLabs.Excepciones;
using System;

namespace SistemaReservasLabs
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // --- Repositorio de Usuarios ---
            Func<Usuario, string> serializarUsuario = u =>
                $"{u.ObtenerTipoUsuario()}|{u.Legajo}|{u.Nombre}";

            Func<string, Usuario> deserializarUsuario = linea =>
            {
                var c = linea.Split('|');
                string tipo = c[0], legajo = c[1], nombre = c[2];
                return tipo switch
                {
                    "Administrador" => new Administrador(legajo, nombre),
                    "Docente" => new Docente(legajo, nombre),
                    "Alumno" => new Alumno(legajo, nombre),
                    _ => throw new ArchivoDatosCorruptoException($"Tipo de usuario desconocido: {tipo}")
                };
            };

            Func<Usuario, string> obtenerIdUsuario = u => u.Legajo;

            var repoUsuarios = new RepositorioArchivo<Usuario>(
                "usuarios.txt", serializarUsuario, deserializarUsuario, obtenerIdUsuario);

            // --- SEED TEMPORAL: carga usuarios de prueba la primera vez ---
            //if (repoUsuarios.ListarTodos().Count == 0)
            //{
            //    repoUsuarios.Agregar(new Administrador("A001", "Ana Torres"));
            //    repoUsuarios.Agregar(new Docente("D001", "Carlos Gomez"));
            //    repoUsuarios.Agregar(new Alumno("AL001", "Lucia Fernandez"));
            //}
            // --- FIN SEED TEMPORAL ---

            // --- Arranca la app ---
            Application.Run(new FrmLogin(repoUsuarios));
        }
    }
}