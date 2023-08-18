using System;
using System.Collections.Generic;

namespace ProyectoFinalHospitalcontrolMedico.Models
{
    public partial class Cita
    {
        public int IdCita { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public DateTime FechaCitaHora { get; set; }

        public virtual Medico? IdMedicoNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
    }
}
