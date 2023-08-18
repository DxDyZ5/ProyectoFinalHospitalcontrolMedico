using System;
using System.Collections.Generic;

namespace ProyectoFinalHospitalcontrolMedico.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Cita = new HashSet<Cita>();
        }

        public int IdMedico { get; set; }
        public string? NombreMed { get; set; }
        public string? Exequatur { get; set; }
        public string? Especialidad { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}
