using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;
using ProyectoFinalHospitalcontrolMedico.Services;

namespace ProyectoFinalHospitalcontrolMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly Ipaciente _pacientes;

        public PacienteController(Ipaciente pacientes)
        {
            _pacientes = pacientes;
        }


        [HttpGet("ObtenerPaciente")]
        public IActionResult GetPaciente() 
        {
            var pacientes = _pacientes.GetPacientes();

            var pacienteDto = pacientes.Select(paciente => new PacienteDTO
            {
                Cedula = paciente.Cedula,
                NombrePac = paciente.NombrePac,
                Asegurado = paciente.Asegurado

            }).ToList();
            return Ok(pacienteDto);
        }

        [HttpPost("InsertarPaciente")]
        public IActionResult InsertPaciente([FromBody] PacienteDTO pacienteDTO)
        {
            var pacienteCREATE = new Paciente 
            {
                Cedula = pacienteDTO.Cedula,
                NombrePac = pacienteDTO.NombrePac,
                Asegurado = pacienteDTO.Asegurado
            };
            

            _pacientes.InsertPaciente(pacienteCREATE);
            return Ok(new { message = "Paciente Insertado correctamente" });
        }

        [HttpPut("ActualizarPaciente")]
        public IActionResult UpdatePaciente([FromBody] PacienteDTO_U pacienteDTO) 
        {
            var pacienteCREATE = new Paciente
            {
                IdPaciente = pacienteDTO.IdPaciente,
                Cedula = pacienteDTO.Cedula,
                NombrePac = pacienteDTO.NombrePac,
                Asegurado = pacienteDTO.Asegurado
            };

            _pacientes.UpdatePaciente(pacienteCREATE);
            return Ok(new { message = "Paciente actualizado correctamente" });
        }

        [HttpDelete("EliminarPaciente")]
        public IActionResult DeletePaciente(int idPaciente)
        {
            _pacientes.EliminarPaciente(idPaciente);
            return Ok(new { message = "Paciente eliminado correctamente" });
        }


    }
}
