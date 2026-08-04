using System;
using System.Collections.Generic;
using System.Linq;
using SistemaReservasLabs.Modelos;
using SistemaReservasLabs.Repositorios;

namespace SistemaReservasLabs.Logica
{
    
    public class UsoPorLaboratorio
    {
        public string LaboratorioNombre { get; set; }
        public int CantidadReservas { get; set; }
        public TimeSpan HorasTotales { get; set; }
    }

    public class RankingUsuario
    {
        public string UsuarioNombre { get; set; }
        public int CantidadReservas { get; set; }
    }

    public class RankingLaboratorio
    {
        public string LaboratorioNombre { get; set; }
        public int CantidadReservas { get; set; }
    }

    public class GeneradorReportes
    {
        private readonly IRepositorio<Reserva> _repoReservas;

        public GeneradorReportes(IRepositorio<Reserva> repoReservas)
        {
            _repoReservas = repoReservas;
        }




        // Reporte 1: uso por laboratorio (cantidad de reservas y horas totales)
        public List<UsoPorLaboratorio> ObtenerUsoPorLaboratorio()
        {
            return _repoReservas.ListarTodos()
                .Where(r => r.Estado != EstadoReserva.Cancelada)
                .GroupBy(r => r.Laboratorio.Nombre)
                .Select(grupo => new UsoPorLaboratorio
                {
                    LaboratorioNombre = grupo.Key,
                    CantidadReservas = grupo.Count(),
                    HorasTotales = TimeSpan.FromTicks(grupo.Sum(r => r.DuracionReserva.Ticks))
                })
                .OrderByDescending(x => x.CantidadReservas)
                .ToList();
        }

        // Reporte 2: ranking de usuarios con más reservas
        public List<RankingUsuario> ObtenerRankingUsuarios(int top = 10)
        {
            return _repoReservas.ListarTodos()
                .Where(r => r.Estado != EstadoReserva.Cancelada)
                .GroupBy(r => r.Usuario.Nombre)
                .Select(grupo => new RankingUsuario
                {
                    UsuarioNombre = grupo.Key,
                    CantidadReservas = grupo.Count()
                })
                .OrderByDescending(x => x.CantidadReservas)
                .Take(top)
                .ToList();
        }

        // Reporte 3: reservas del día de hoy
        public List<Reserva> ObtenerReservasDeHoy()
        {
            return _repoReservas.ListarTodos()
                .Where(r => r.Fecha.Date == DateTime.Today
                         && r.Estado != EstadoReserva.Cancelada)
                .OrderBy(r => r.HoraInicio)
                .ToList();
        }

        //Reporte 4: ranking de reservas por laboratorio

        public List<RankingLaboratorio> ObtenerRankingLaboratorios(int top = 10)
        {
            return _repoReservas.ListarTodos()
                .Where(r => r.Estado != EstadoReserva.Cancelada)
                .GroupBy(r => r.Laboratorio.Nombre)
                .Select(g => new RankingLaboratorio { LaboratorioNombre = g.Key, CantidadReservas = g.Count() })
                .OrderByDescending(x => x.CantidadReservas)
                .Take(top)
                .ToList();
        }
    }
}