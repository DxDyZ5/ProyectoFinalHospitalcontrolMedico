using System;
using System.Collections.Generic;

namespace ProyectoFinalHospitalcontrolMedico.Models
{
    public partial class Habitacione
    {
        public Habitacione()
        {
            Ingresos = new HashSet<Ingreso>();
        }

        public int IdHabitacion { get; set; }
        public int? Numero { get; set; }
        public string? Tipo { get; set; }
        public decimal PrecioPorDia { get; set; }

        public virtual ICollection<Ingreso> Ingresos { get; set; }
    }
}
