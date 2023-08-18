using System;
using System.Collections.Generic;

namespace ProyectoFinalHospitalcontrolMedico.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Cita = new HashSet<Cita>();
            Ingresos = new HashSet<Ingreso>();
        }

        public int IdPaciente { get; set; }
        public string? Cedula { get; set; }
        public string? NombrePac { get; set; }
        public bool? Asegurado { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
