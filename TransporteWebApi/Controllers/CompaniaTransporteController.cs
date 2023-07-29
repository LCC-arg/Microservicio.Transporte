using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Request;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TransporteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniaTransporteController : ControllerBase
    {
        private readonly ICompaniaTransporteService _companiaTransporteService;

        public CompaniaTransporteController(ICompaniaTransporteService companiaTransporteService)
        {
            _companiaTransporteService = companiaTransporteService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompaniaTransporteResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult CreateCompaniaTransporte(CompaniaTransporteRequest companiaRequest)
        {
            try
            {
                var result = _companiaTransporteService.CreateCompaniaTransporte(companiaRequest);
                return new JsonResult(result) { StatusCode = 201};
            }
            catch(ValorConflictException valor)
            {
                return Conflict(new BadRequest { Message = valor.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CompaniaTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetCompaniaTransportebyId(int id)
        {
            try
            {
                var result = _companiaTransporteService.GetCompaniaTransportebyId(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CompaniaTransporteResponse), 200)]
        public IActionResult GetAllCompaniaTransporte()
        {
            var result = _companiaTransporteService.GetAllCompaniaTransporte();
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CompaniaTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult DeleteCompaniaTransporte(int id)
        {
            try
            {
                var result = _companiaTransporteService.RemoveCompaniaTransporte(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CompaniaTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult UpdateCompaniaTransporte(int id, CompaniaTransporteRequest companiaRequest)
        {
            try
            {
                var result = _companiaTransporteService.UpdateCompaniaTransporte(id, companiaRequest);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound( new BadRequest { Message = valor.Message } );
            }
            catch (ValorConflictException valor)
            {
                return Conflict(new BadRequest { Message = valor.Message }); 
            }
        }
    }
}
