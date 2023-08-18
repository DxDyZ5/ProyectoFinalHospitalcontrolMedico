using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;

namespace ProyectoFinalHospitalcontrolMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesosController : ControllerBase
    {
        private readonly ICitaMedica _citamedica;

        private readonly Iingreso _ingreso;

        private readonly IAlta _alta;

        public ProcesosController(ICitaMedica citamedica, Iingreso ingreso, IAlta alta)
        {
            _citamedica = citamedica;
            _ingreso = ingreso;
            _alta = alta;
        }

        [HttpPost("ReservarCita")]
        public IActionResult ReservarCita([FromBody] CitaMedicaDTO citaDTO)
        {
            if (citaDTO == null || citaDTO.IdPaciente <= 0 || citaDTO.IdMedico <= 0)
            {
                return BadRequest("Datos de cita medica invalidos.");
            }

            try
            {
               string mensaje = _citamedica.ReservarCita(citaDTO);
                return Ok(new { message = mensaje });
            }
            catch (DbUpdateException)
            {
                return BadRequest("Error al reservar la cita medica. Revise los datos e intentelo nuevamente.");
            }
        }

        [HttpPost("RegistrarIngreso")]
        public IActionResult RegistrarIngreso([FromBody] IngresoDTO ingresoDTO)
        {

            if (ingresoDTO == null || ingresoDTO.IdPaciente <= 0 || ingresoDTO.IdHabitacion <= 0)
            {
                return BadRequest("Datos de ingreso invalidos.");
            }
            try
            {
               string mensaje = _ingreso.RegistrarIngreso(ingresoDTO);
                return Ok(new { message = mensaje });
            }
            catch (DbUpdateException)
            {

                return BadRequest("Error al registrar el ingrreso. Revise los datos e intentelo nuevamente.");
            }
        }

        [HttpPost("DarAlta")]
        public IActionResult DarAlta([FromBody] AltaDTO altaDTO)
        {
            if (altaDTO == null || altaDTO.IdIngreso <= 0)
            {
                return BadRequest("Datos de alta medica invalidos.");
            }
            try
            {
                string mensaje = _alta.DarAlta(altaDTO);
                return Ok(new { message = mensaje });
            }
            catch (DbUpdateException)
            {

                return BadRequest("Error al registrar la alta. Revise los datos e intentelo nuevamente.");
            }

        }
    }
}
