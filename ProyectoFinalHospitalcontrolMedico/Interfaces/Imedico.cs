using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Interfaces
{
    public interface Imedico
    {
        public List<Medico> GetMedicos();
        public void InsertMedicos(Medico medico);

        public void UpdateMedicos(Medico medico);

       public void EliminarMedico(int idMedico);
    }
}
 