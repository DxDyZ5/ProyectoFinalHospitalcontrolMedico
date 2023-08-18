using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinalHospitalcontrolMedico.Interfaces;
using ProyectoFinalHospitalcontrolMedico.Models;

namespace ProyectoFinalHospitalcontrolMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly IConsulta _consultas;

        public ConsultasController(IConsulta consultass)
        {
            _consultas = consultass;
        }


        [HttpGet("ConsultarPacientes")]
        public IActionResult FiltroPacientes(string? nombre, string? cedula, bool? asegurado, string tipoDeFiltro)
        {
           
            var pacientes = _consultas.ConsultarPacientes(nombre, cedula, asegurado);

            switch (tipoDeFiltro.ToLower())
            {
                case "conteo":
                    int conteoPacientes = pacientes.Count;
                    return Ok(new { message = "Cantidad de pacientes: " + conteoPacientes});

                case "suma":
                    int sumaAsegurados = pacientes.Count(p => p.Asegurado == true);
                    int sumaNoAsegurados = pacientes.Count(p => p.Asegurado == false);
                    return Ok(new { message = "Asegurados: " + sumaAsegurados + " No asegurados: " + sumaNoAsegurados });

                case "promedio":
                case "maximo":
                case "minimo":
                    return BadRequest(new { message = "Esta consulta no es aplicable a pacientes." });

                default:
                    return BadRequest(new { message = "Tipo de filtro no válido. Use (conteo, suma, promedio, maximo, minimo)." });
            }
        }


        [HttpGet("ConsultarMedicos")]
        public IActionResult FiltroMedicos(string? nombre, string? especialidad, string tipoDeFiltro)
        {
            
            var medicos = _consultas.ConsultarMedicos(nombre, especialidad);

            switch (tipoDeFiltro.ToLower())
            {
                case "conteo":
                    int conteoMedicos = medicos.Count;
                    return Ok(new { message = "Cantidad de medicos: " + conteoMedicos });
                case "suma":
                case "promedio":
                case "maximo":
                case "minimo":
                   return BadRequest(new { message = "Esta consulta no es aplicable a medicos." });
                default:
                    return BadRequest(new { message = "Tipo de filtro no válido. Use (conteo, suma, promedio, maximo, minimo)." });
            }
        }

        [HttpGet("ConsultarHabitacion")]
        public IActionResult FiltroHabitacion(string? tipo, string tipoDeFiltro)
        {
            var habitacion = _consultas.ConsultarHabitaciones(tipo);

            switch (tipoDeFiltro.ToLower())
            {
                case "conteo":
                    int conteohabitacion = habitacion.Count;
                    return Ok(new { message = "Cantidad de habitaciones: " + conteohabitacion });

                case "suma":
                    decimal sumaPrecios = habitacion.Sum(h => h.PrecioPorDia);
                    return Ok(new { message = "Suma de los precios de las habitaciones: " + sumaPrecios });

                case "promedio":
                    decimal promedioPrecios = habitacion.Average(h => h.PrecioPorDia);
                    return Ok(new { message = "Promedio de los precios de las habitaciones: " + promedioPrecios });

                case "maximo":
                    decimal maximoPrecio = habitacion.Max(h => h.PrecioPorDia);
                    return Ok(new { message = "Precio mas alto de las habitaciones: " + maximoPrecio });

                case "minimo":
                    decimal minimoPrecio = habitacion.Min(h => h.PrecioPorDia);
                    return Ok(new { message = "Precio mas bajo de las habitaciones: " + minimoPrecio });

                default:
                    return BadRequest(new { message = "Tipo de filtro no válido. Use (conteo, suma, promedio, maximo, minimo)." });
            }
        }

        [HttpGet("ConsultarCitasMedicas")]
        public IActionResult FiltroCitasMedicas(DateTime fecha, int? idMedico, int? idPaciente, string tipoDeFiltro)
        {
            var citasMedicas = _consultas.ConsultarCitasMedicas(fecha, idMedico, idPaciente);

            

            switch (tipoDeFiltro.ToLower())
            {
                case "conteo":
                    int conteoCitas = citasMedicas.Count;
                    return Ok(new { message = "Cantidad de citas: " + conteoCitas });

                case "suma":
                case "promedio":
                case "maximo":
                case "minimo":
                    return BadRequest(new { message = "Esta consulta no es aplicable a citas medicas." });

                default:
                    return BadRequest(new { message = "Tipo de filtro no valido. Use (conteo, suma, promedio, maximo, minimo)." });
            }
        }

        [HttpGet("ConsultarIngresos")]
        public IActionResult FiltroIngresos(DateTime fecha, int? idHabitacion, string tipoDeFiltro)
        {
            var ingresos = _consultas.ConsultarIngresos(fecha, idHabitacion);

            switch (tipoDeFiltro.ToLower())
            {
                case "conteo":
                    int conteoIngresos = ingresos.Count;
                    return Ok(new { message = "Cantidad de ingresos: " + conteoIngresos });

                case "suma":
                case "promedio":
                case "maximo":
                case "minimo":
                    return BadRequest(new { message = "Esta consulta no es aplicable a ingresos." });

                default:
                    return BadRequest(new { message = "Tipo de filtro no valido. Use (conteo, suma, promedio, maximo, minimo)." });
            }
        }



        [HttpGet("ConsultarAltasMedicas")]
        public IActionResult FiltroAltasMedicas(int? idPaciente, DateTime fecha, string tipoDeFiltro)
        {
            var altasMedicas = _consultas.ConsultarAltasMedicas(idPaciente, fecha);
            
                switch (tipoDeFiltro.ToLower())
                {
                    case "conteo":
                        int conteoAltas = altasMedicas.Count;
                    return Ok(new { message = "Cantidad de altas medicas: " + conteoAltas});

                case "suma":
                    case "promedio":
                    case "maximo":
                    case "minimo":
                        return BadRequest(new { message = "Esta consulta no es aplicable a altas medicas." });

                    default:
                        return BadRequest(new { message = "Tipo de filtro no valido. Use (conteo, suma, promedio, maximo, minimo)." });
            }
            

           
        }


    }
}
