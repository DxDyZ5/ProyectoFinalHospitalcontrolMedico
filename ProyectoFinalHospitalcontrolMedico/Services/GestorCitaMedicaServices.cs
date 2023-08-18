using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Services
{
    public class GestorCitaMedicaServices : ICitaMedica
    {
        private readonly SistemaMedicoAPIContext _SistemaMedicoContext;

        public GestorCitaMedicaServices(SistemaMedicoAPIContext context)
        {
            _SistemaMedicoContext = context;
        }

        public string ReservarCita(CitaMedicaDTO citaDTO)
        {
            var paciente = _SistemaMedicoContext.Pacientes.Find(citaDTO.IdPaciente);
            

            if (paciente != null)
            {
                var medico = _SistemaMedicoContext.Medicos.Find(citaDTO.IdMedico);
                if (medico != null)
                {
                    var CitaCreate = new Cita
                    {
                        IdPaciente = citaDTO.IdPaciente,
                        IdMedico = citaDTO.IdMedico,
                        FechaCitaHora = citaDTO.FechaCitaHora
                    };

                    _SistemaMedicoContext.Citas.Add(CitaCreate);
                    _SistemaMedicoContext.SaveChanges();

                    string mensaje = $"Cita medica reservada correctamente. Detalles:\n" +
                             $"Paciente: {paciente.NombrePac}\n" +
                             $"Medico: {medico.NombreMed}\n" +
                             $"Fecha: {citaDTO.FechaCitaHora}";

                    return mensaje;
                }
            }


            return "Error. Verifique los datos e intentelo nuevamente.";
        }
    }
}
