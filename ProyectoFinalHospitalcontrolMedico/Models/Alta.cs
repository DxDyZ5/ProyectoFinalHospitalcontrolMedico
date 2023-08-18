using System;
using System.Collections.Generic;

namespace ProyectoFinalHospitalcontrolMedico.Models
{
    public partial class Alta
    {
        public int IdAlta { get; set; }
        public int? IdIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public decimal MontoPagar { get; set; }

        public virtual Ingreso? IdIngresoNavigation { get; set; }
    }
}
