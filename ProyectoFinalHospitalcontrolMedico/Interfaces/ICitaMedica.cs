using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Interfaces
{
    public interface ICitaMedica
    {
        public string ReservarCita(CitaMedicaDTO citaDTO);
    }
}
