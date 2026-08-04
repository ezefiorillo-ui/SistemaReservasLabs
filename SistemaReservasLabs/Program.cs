using SistemaReservasLabs.Excepciones;
using SistemaReservasLabs.Formularios;
using SistemaReservasLabs.Logica;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;
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

            // --- Repositorio de Laboratorios ---
            Func<Laboratorio, string> serializarLaboratorio = l =>
                $"{l.Id}|{l.Nombre}|{l.Ubicacion}|{l.CapacidadPCs}|{l.Equipamiento}";

            Func<string, Laboratorio> deserializarLaboratorio = linea =>
            {
                var c = linea.Split('|');
                return new Laboratorio(c[0], c[1], c[2], int.Parse(c[3]), c[4]);
            };

            Func<Laboratorio, string> obtenerIdLaboratorio = l => l.Id;

            var repoLaboratorios = new RepositorioArchivo<Laboratorio>(
                "laboratorios.txt", serializarLaboratorio, deserializarLaboratorio, obtenerIdLaboratorio);

            // --- Repositorio de Reservas ---

            Func<Reserva, string> serializarReserva = r =>
                $"{r.Id}|{r.Laboratorio.Id}|{r.Usuario.Legajo}|{r.Fecha:yyyy-MM-dd}|" +
                $"{r.HoraInicio}|{r.HoraFin}|{r.Motivo.Replace("|", " ").Replace("\n", " ").Replace("\r", "")}|{r.Estado}";

            Func<string, Reserva> deserializarReserva = linea =>
            {
                var c = linea.Split('|');
                var lab = repoLaboratorios.ObtenerPorId(c[1]);
                var usu = repoUsuarios.ObtenerPorId(c[2]);

                if (lab == null || usu == null)
                    throw new ArchivoDatosCorruptoException($"Reserva '{c[0]}' referencia datos inexistentes.");

                return new Reserva(
                    c[0], lab, usu, DateTime.Parse(c[3]),
                    TimeSpan.Parse(c[4]), TimeSpan.Parse(c[5]), c[6],
                    Enum.Parse<EstadoReserva>(c[7]));
            };

            var repoReservas = new RepositorioArchivo<Reserva>(
                "reservas.txt", serializarReserva, deserializarReserva, r => r.Id);


            // --- Lógica de negocio ---
            var gestorReservas = new GestorReservas(repoReservas, repoLaboratorios);
            var generadorReportes = new GeneradorReportes(repoReservas);


            // --- Arranca la app ---
            Application.Run(new FrmLogin(repoUsuarios, repoLaboratorios, repoReservas, gestorReservas, generadorReportes));
        }
    }
}