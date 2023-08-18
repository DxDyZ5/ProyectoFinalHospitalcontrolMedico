using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Interfaces
{
    public interface Ipaciente
    {
        public List<Paciente> GetPacientes();

        public void InsertPaciente(Paciente paciente);

        public void UpdatePaciente(Paciente paciente);

        public void EliminarPaciente(int idPaciente);

    }
}
