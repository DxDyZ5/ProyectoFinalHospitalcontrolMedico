using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Services
{
    public class GestorHabitacionServices : Ihabitaciones
    {
        private readonly SistemaMedicoAPIContext _SistemaMedicoContext;

        public GestorHabitacionServices(SistemaMedicoAPIContext sistemaMedicoContext)
        {
            _SistemaMedicoContext = sistemaMedicoContext;
        }

        public List<Habitacione> GetHabitaciones()
        {
            return _SistemaMedicoContext.Habitaciones.ToList();
        }

        public void InsertHabitaciones(Habitacione habitaciones)
        {
            if (habitaciones != null  && !habitaciones.Tipo.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                _SistemaMedicoContext.Habitaciones.Add(habitaciones);
                _SistemaMedicoContext.SaveChanges();
            }
        }

        public void UpdateHabitaciones(Habitacione habitaciones)
        {
            var HabitacioneUpdate = _SistemaMedicoContext.Habitaciones.Find(habitaciones.IdHabitacion);
            if (HabitacioneUpdate != null && !habitaciones.Tipo.Equals("string", StringComparison.OrdinalIgnoreCase))
            {
                HabitacioneUpdate.Numero = habitaciones.Numero;
                HabitacioneUpdate.Tipo = habitaciones.Tipo;
                HabitacioneUpdate.PrecioPorDia = habitaciones.PrecioPorDia;
                _SistemaMedicoContext.SaveChanges();
            }
        }

        public void EliminarHabitaciones(int idHabitaciones)
        {
            var DeleteHabitacione = _SistemaMedicoContext.Habitaciones.Find(idHabitaciones);
            if (DeleteHabitacione != null)
            {
                _SistemaMedicoContext.Habitaciones.Remove(DeleteHabitacione);
                _SistemaMedicoContext.SaveChanges();
            }
        }

    }
}
