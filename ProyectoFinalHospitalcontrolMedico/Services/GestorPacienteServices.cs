using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;
using System.Runtime.InteropServices;

namespace ProyectoFinalHospitalcontrolMedico.Services
{
    public class GestorPacienteServices : Ipaciente
    {
        private readonly SistemaMedicoAPIContext _SistemaMedicoContext;

        public GestorPacienteServices(SistemaMedicoAPIContext context)
        {
            _SistemaMedicoContext = context;
        }

        public List<Paciente> GetPacientes()
        {
          return _SistemaMedicoContext.Pacientes.ToList();
        }

        public void InsertPaciente(Paciente paciente)
        {
            if (paciente != null && !paciente.NombrePac.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                _SistemaMedicoContext.Pacientes.Add(paciente);
                _SistemaMedicoContext.SaveChanges();
            }
        }

        public void UpdatePaciente(Paciente paciente)
        {
            var PacienteUpdate = _SistemaMedicoContext.Pacientes.Find(paciente.IdPaciente);
            if (PacienteUpdate != null && !paciente.NombrePac.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                PacienteUpdate.NombrePac = paciente.NombrePac;
                PacienteUpdate.Cedula = paciente.Cedula;
                PacienteUpdate.Asegurado = paciente.Asegurado;
                _SistemaMedicoContext.SaveChanges();
            }
        }

        public void EliminarPaciente(int idPaciente)
        {
            var DeletePaciente = _SistemaMedicoContext.Pacientes.Find(idPaciente);
            if (DeletePaciente != null)
            {
                _SistemaMedicoContext.Pacientes.Remove(DeletePaciente);
                _SistemaMedicoContext.SaveChanges();
            }
        }
    }
}
