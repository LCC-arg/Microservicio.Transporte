using Application.Exceptions;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Request;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TransporteWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CaracteristicaTransporteController : ControllerBase
    {

        private readonly ICaracteristicaTransporteService _caracteristicaTransporteService;

        public CaracteristicaTransporteController(ICaracteristicaTransporteService caracteristicaTransporteService)
        {
            _caracteristicaTransporteService = caracteristicaTransporteService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CaracteristicaTransporteResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult CreateCompaniaTransporte(CaracteristicaTransporteRequest caracteristicaTransporteRequest)
        {
            try
            {
                var result = _caracteristicaTransporteService.CreateCaracteristicaTransporte(caracteristicaTransporteRequest);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ValorConflictException valor)
            {
                return Conflict(new { valor.Message });
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CaracteristicaTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetCaracteristicaTransportebyId(int id)
        {
            try
            {
                var result = _caracteristicaTransporteService.GetCaracteristicaTransportebyId(id);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CaracteristicaTransporteResponse), 200)]
        public IActionResult GetAllCaracteristicaTransporte()
        {
            var result = _caracteristicaTransporteService.GetAllCaracteristicaTransporte();
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CaracteristicaTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult DeleteCaracteristicaTransporte(int id)
        {
            try
            {
                var result = _caracteristicaTransporteService.RemoveCaracteristicaTransporte(id);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CaracteristicaTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult UpdateCaracteristicaTransporte(int id, CaracteristicaTransporteRequest caracteristicaTransporteRequest)
        {
            try
            {
                var result = _caracteristicaTransporteService.UpdateCaracteristicaTransporte(id, caracteristicaTransporteRequest);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }
    }
}
