using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
       private readonly Ihabitaciones _habitaciones;

        public HabitacionController(Ihabitaciones habitaciones)
        {
            _habitaciones = habitaciones;
        }

        [HttpGet("ObtenerHabitaciones")]
        public IActionResult GetHabitaciones() 
        {
            var habitaciones = _habitaciones.GetHabitaciones();

            var habitacionesDTO = habitaciones.Select(habitacion => new HabitacionDTO
            {
                Numero = habitacion.Numero,
                Tipo = habitacion.Tipo,
                PrecioPorDia = habitacion.PrecioPorDia
            }).ToList();

            return Ok(habitacionesDTO);
        }

        [HttpPost("InsertHabitaciones")]
        public IActionResult insertHabitacion([FromBody] HabitacionDTO habitacionDTO)
        {
            var habitacion = new Habitacione
            {
                Numero = habitacionDTO.Numero,
                Tipo = habitacionDTO.Tipo,
                PrecioPorDia = habitacionDTO.PrecioPorDia
            };

            _habitaciones.InsertHabitaciones(habitacion);
            return Ok(new { message = "Habitacion insertada correctamente" });
        }

        [HttpPut("ActualizarHabitaciones")]
        public IActionResult UpdateHabitacion([FromBody] HabitacionDTO_U habitacionDTO)
        {
            var habitacion = new Habitacione
            {
                IdHabitacion = habitacionDTO.IdHabitacion,
                Numero = habitacionDTO.Numero,
                Tipo = habitacionDTO.Tipo,
                PrecioPorDia = habitacionDTO.PrecioPorDia
            };

            _habitaciones.UpdateHabitaciones(habitacion);
            return Ok(new { message = "Habitacion actualizada correctamente" });
        }


        [HttpDelete("Eliminarhabitacion")]
        public IActionResult DeleteHabitacion(int idHabitacion)
        {
            _habitaciones.EliminarHabitaciones(idHabitacion);
            return Ok(new { message = "Habitacion eliminada correctamente" });
        }
    }

}
