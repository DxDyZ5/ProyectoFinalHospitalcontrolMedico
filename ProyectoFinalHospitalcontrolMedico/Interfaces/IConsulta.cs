using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Interfaces
{
    public interface IConsulta
    {

            List<PacienteDTO> ConsultarPacientes(string? nombre, string? cedula, bool? asegurado);
            List<MedicoDTO> ConsultarMedicos(string? nombre, string? especialidad);
            List<HabitacionDTO> ConsultarHabitaciones(string? tipo);
            List<CitaMedicaDTO> ConsultarCitasMedicas(DateTime fecha, int? idDoctor, int? idPaciente);
            List<IngresoDTO> ConsultarIngresos(DateTime fecha, int? idHabitacion);
            List<AltaDTO> ConsultarAltasMedicas(int? idPaciente, DateTime fecha);
        

    }
}
