using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Services
{
    public class GestorMedicoServices : Imedico
    {
        private readonly SistemaMedicoAPIContext _SistemaMedicoContext;

        public GestorMedicoServices(SistemaMedicoAPIContext context)
        {
            _SistemaMedicoContext = context;
        }


        public List<Medico> GetMedicos()
        {
            return _SistemaMedicoContext.Medicos.ToList();
        }


        public void InsertMedicos(Medico medico)
        {
            if (medico != null &&  !medico.NombreMed.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                _SistemaMedicoContext.Medicos.Add(medico);
                _SistemaMedicoContext.SaveChanges();
            }
               
        }
            
        public void UpdateMedicos(Medico medico)
        {
            var MedicoUpdate = _SistemaMedicoContext.Medicos.Find(medico.IdMedico);
            if (MedicoUpdate != null && !medico.NombreMed.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                MedicoUpdate.NombreMed = medico.NombreMed;
                MedicoUpdate.Exequatur = medico.Exequatur;
                MedicoUpdate.Especialidad = medico.Especialidad;
                _SistemaMedicoContext.SaveChanges();
            }
        }

        public void EliminarMedico(int idMedico)
        {
            var medico = _SistemaMedicoContext.Medicos.Find(idMedico);

            if(medico != null )
            {
                _SistemaMedicoContext.Medicos.Remove(medico);
                _SistemaMedicoContext.SaveChanges();
            }
        }


    }
}
