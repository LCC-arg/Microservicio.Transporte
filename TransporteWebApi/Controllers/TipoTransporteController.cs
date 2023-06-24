using Application.Exceptions;
using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TransporteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransporteController : ControllerBase
    {
        private readonly ITipoTransporteService _tipoTransporteService;

        public TipoTransporteController(ITipoTransporteService tipoTransporteService)
        {
            _tipoTransporteService = tipoTransporteService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TipoTransporteResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult CreateTipoTransporte(TipoTransporteRequest tipoTransporteRequest)
        {
            try
            {
                var result = _tipoTransporteService.CreateTipoTransporte(tipoTransporteRequest);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ValorConflictException valor)
            {
                return Conflict(new { valor.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TipoTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetTipoTransportebyId(int id)
        {
            try
            {
                var result = _tipoTransporteService.GetTipoTransportebyId(id);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(TipoTransporteResponse), 200)]
        public IActionResult GetAllTipoTransporte()
        {
            var result = _tipoTransporteService.GetAllTipoTransporte();
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TipoTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult DeleteTipoTransporte(int id)
        {
            try
            {
                var result = _tipoTransporteService.RemoveTipoTransporte(id);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TipoTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult UpdateCompaniaTransporte(int id, TipoTransporteRequest tipoTransporteRequest)
        {
            try
            {
                var result = _tipoTransporteService.UpdateTipoTransporte(id, tipoTransporteRequest);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
            catch (ValorConflictException valor)
            {
                return Conflict(new { valor.Message });
            }
        }
    }
}
