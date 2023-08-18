using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Services
{
    public class GestorAltaServices : IAlta
    {
        private readonly SistemaMedicoAPIContext _SistemaMedicoContext;

        public GestorAltaServices(SistemaMedicoAPIContext context)
        {
            _SistemaMedicoContext = context;
        }

        public string DarAlta(AltaDTO altaDTO)
        {
            var ingreso = _SistemaMedicoContext.Ingresos.Find(altaDTO.IdIngreso);

            if (ingreso != null)
            {
                var habitacion = _SistemaMedicoContext.Habitaciones.Find(ingreso.IdHabitacion);
                if (habitacion != null)
                {
                    decimal montoAPagar = (decimal)(altaDTO.FechaSalida - ingreso.FechaInicioInter).TotalDays * habitacion.PrecioPorDia;

                    var altaMedica = new Alta
                    {
                        IdIngreso = altaDTO.IdIngreso,
                        FechaSalida = altaDTO.FechaSalida,
                        MontoPagar = montoAPagar
                    };

                    _SistemaMedicoContext.Altas.Add(altaMedica);
                    _SistemaMedicoContext.SaveChanges();

                   
                    var paciente = _SistemaMedicoContext.Pacientes.Find(ingreso.IdPaciente);
                   
                    
                    string mensaje = $"Alta medica registrada correctamente. Detalles:\n" +
                                     $"Fecha de ingreso: {ingreso.FechaInicioInter}\n" +
                                     $"Paciente: {paciente.NombrePac}\n" +
                                     $"Habitación: {habitacion.Numero}\n" +
                                     $"Monto a pagar: {montoAPagar}";

                    return mensaje;
                }
            }

            return "Error. Verifique los datos e intentelo nuevamente.";
        }
    }
}
