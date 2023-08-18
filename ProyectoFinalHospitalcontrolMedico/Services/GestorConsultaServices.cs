using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProyectoFinalHospitalcontrolMedico.Services
{
    public class GestorConsultaServices : IConsulta
    {
        private readonly SistemaMedicoAPIContext _SistemaMedicoContext;


        public GestorConsultaServices(SistemaMedicoAPIContext context)
        {
            _SistemaMedicoContext = context;
        }

        public List<PacienteDTO> ConsultarPacientes(string? nombre, string? cedula, bool? asegurado)
        {
            var query = _SistemaMedicoContext.Pacientes.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.NombrePac.Contains(nombre));
            }
                

            if (!string.IsNullOrEmpty(cedula))
            {
                query = query.Where(p => p.Cedula.Contains(cedula));
            }
                

            if (asegurado != null)
            {
                query = query.Where(p => p.Asegurado == asegurado);
            }

            return query.Select(p => new PacienteDTO
            {
                Cedula = p.Cedula,
                NombrePac = p.NombrePac,
                Asegurado = p.Asegurado
            }).ToList();
        }

        public List<MedicoDTO> ConsultarMedicos(string? nombre, string? especialidad)
        {
            var query = _SistemaMedicoContext.Medicos.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(m => m.NombreMed.Contains(nombre));
            }

            if (!string.IsNullOrEmpty(especialidad))
            {
                query = query.Where(m => m.Especialidad.Contains(especialidad));
            }

            return query.Select(m => new MedicoDTO
            {
                NombreMed = m.NombreMed,
                Especialidad = m.Especialidad
            }).ToList();
        }

        public List<HabitacionDTO> ConsultarHabitaciones(string? tipo)
        {
            var query = _SistemaMedicoContext.Habitaciones.AsQueryable();

            if (!string.IsNullOrEmpty(tipo))
                query = query.Where(h => h.Tipo.Contains(tipo));

            return query.Select(h =>  new HabitacionDTO
            {
                Tipo = h.Tipo,
                PrecioPorDia = h.PrecioPorDia
            }).ToList();
        }

        public List<CitaMedicaDTO> ConsultarCitasMedicas(DateTime fecha, int? idMedico, int? idPaciente)
        {
           var query = _SistemaMedicoContext.Citas.AsQueryable();

            if (fecha != null)
                query = query.Where(c => c.FechaCitaHora.Date == fecha.Date);

            if (idMedico.HasValue && idMedico.Value > 0)
                query = query.Where(c => c.IdMedico == idMedico.Value);

            if (idPaciente.HasValue && idPaciente.Value > 0)
                query = query.Where(c => c.IdPaciente == idPaciente.Value);

            return query.Select(c => new CitaMedicaDTO
            {
                IdPaciente = c.IdPaciente,
                IdMedico = c.IdMedico,
                FechaCitaHora = c.FechaCitaHora
            }).ToList();
        }

        public List<IngresoDTO> ConsultarIngresos(DateTime fecha, int? idHabitacion)
        {
            var query = _SistemaMedicoContext.Ingresos.AsQueryable();

            if (fecha != null)
                query = query.Where(i => i.FechaInicioInter.Date == fecha.Date);

            if (idHabitacion.HasValue && idHabitacion.Value > 0)
                query = query.Where(i => i.IdHabitacion == idHabitacion.Value);

            return query.Select(i => new IngresoDTO
            {
                IdHabitacion = i.IdHabitacion,
                FechaInicioInter = i.FechaInicioInter
            }).ToList();
        }
        public List<AltaDTO> ConsultarAltasMedicas(int? idPaciente, DateTime fecha)
        {
           var query = _SistemaMedicoContext.Altas.AsQueryable();

            if (fecha != null)
                query = query.Where(a => a.FechaSalida.Date == fecha.Date);

            if (idPaciente.HasValue && idPaciente.Value > 0)
                query = query.Where(a => a.IdIngresoNavigation.IdPaciente == idPaciente.Value);


            return query.Select(a => new AltaDTO
            {
                IdIngreso = a.IdIngresoNavigation.IdPaciente,
                FechaSalida = a.FechaSalida

            }).ToList();
        }
        

        

        

        
    }
}
