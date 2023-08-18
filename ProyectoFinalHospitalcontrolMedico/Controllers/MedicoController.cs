using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalHospitalcontrolMedico.DTO;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly Imedico _medicos;


        public MedicoController(Imedico medicos)
        {
            _medicos = medicos;
        }
            
        [HttpGet("ObtenerMedicos")]
        public IActionResult GetMedico()
        {
            var medicos = _medicos.GetMedicos();

            var medicoDTo = medicos.Select(medico => new MedicoDTO
            {
                NombreMed = medico.NombreMed,
                Exequatur = medico.Exequatur,
                Especialidad = medico.Especialidad
            }).ToList();

            return Ok(medicoDTo);
        }

        [HttpPost("InsertarMedicos")]
        public IActionResult insertarMedicos([FromBody] MedicoDTO medicoDTO)
        {
            var medicoDTOCREATE = new Medico 
            {
             NombreMed = medicoDTO.NombreMed,
            Exequatur = medicoDTO.Exequatur,
            Especialidad = medicoDTO.Especialidad
        };
            _medicos.InsertMedicos(medicoDTOCREATE);
            return Ok(new { message = "Medico Insertado correctamente" });
        }

        [HttpPut("ActualizaMedicos")]
        public IActionResult UpdateMedico([FromBody] MedicoDTO_U medicoDTOw)
        {
            var medicoDTOCREATE = new Medico
            {
                IdMedico = medicoDTOw.IdMedico,
                NombreMed = medicoDTOw.NombreMed,
                Exequatur = medicoDTOw.Exequatur,
                Especialidad = medicoDTOw.Especialidad
            };

            _medicos.UpdateMedicos(medicoDTOCREATE);
            return Ok(new { message = "Medico actualizado correctamente" });
        }

        [HttpDelete("EliminarMedicos")]

        public IActionResult EliminarMedico(int idMedico)
        {
            _medicos.EliminarMedico(idMedico);
            return Ok(new { message = "Medico eliminado correctamente" });
        }

    }
}
