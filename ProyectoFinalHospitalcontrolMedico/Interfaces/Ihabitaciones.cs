using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Interfaces
{
    public interface Ihabitaciones
    {
        public List<Habitacione> GetHabitaciones();

        public void InsertHabitaciones(Habitacione habitaciones);

        public void UpdateHabitaciones(Habitacione habitaciones);

        public void EliminarHabitaciones(int idHabitaciones);
    }
}
