using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Services
{
    public class GestorIngresoServices : Iingreso
    {
        private readonly SistemaMedicoAPIContext _SistemaMedicoContext;

        public GestorIngresoServices(SistemaMedicoAPIContext context)
        {
            _SistemaMedicoContext = context;
        }

        public string RegistrarIngreso(IngresoDTO ingresoDTO)
        {
            var paciente = _SistemaMedicoContext.Pacientes.Find(ingresoDTO.IdPaciente);

            if (paciente != null)
            {
                var habitacion = _SistemaMedicoContext.Habitaciones.Find(ingresoDTO.IdHabitacion);
                if (habitacion != null)
                {
                    var IngresoCreate = new Ingreso
                    {
                        IdPaciente = ingresoDTO.IdPaciente,
                        IdHabitacion = ingresoDTO.IdHabitacion,
                        FechaInicioInter = ingresoDTO.FechaInicioInter
                    };

                    _SistemaMedicoContext.Ingresos.Add(IngresoCreate);
                    _SistemaMedicoContext.SaveChanges();

                    string mensaje = $"ingreso registrado correctamente. Detalles:\n" +
                             $"Paciente: {paciente.NombrePac}\n" +
                             $"Tipo de habitacion: {habitacion.Tipo}\n" +
                             $"Fecha: {ingresoDTO.FechaInicioInter}";

                    return mensaje;
                }
            }

            return "Error. Verifique los datos e intentelo nuevamente.";

        }
    }
}
