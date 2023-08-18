using System;
using System.Collections.Generic;

namespace ProyectoFinalHospitalcontrolMedico.Models
{
    public partial class Ingreso
    {
        public Ingreso()
        {
            Alta = new HashSet<Alta>();
        }

        public int IdIngreso { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdHabitacion { get; set; }
        public DateTime FechaInicioInter { get; set; }

        public virtual Habitacione? IdHabitacionNavigation { get; set; }
        public virtual Paciente? IdPacienteNavigation { get; set; }
        public virtual ICollection<Alta> Alta { get; set; }
    }
}
