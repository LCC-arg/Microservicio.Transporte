using Application.Exceptions;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Request;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TransporteWebApi.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult CreateCaracteristicaTransporte(CaracteristicaTransporteRequest caracteristicaTransporteRequest)
        {
            try
            {
                var result = _caracteristicaTransporteService.CreateCaracteristicaTransporte(caracteristicaTransporteRequest);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
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
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(CaracteristicaTransporteResponse), 200)]
        public IActionResult GetAllCaracteristicaTransporte([FromQuery] int? idTransporte = null, int? idCaracteristica = null)
        {
            var result = _caracteristicaTransporteService.GetAllCaracteristicaTransporte(idTransporte, idCaracteristica);
            return new JsonResult(result) { StatusCode = 200};
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CaracteristicaTransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult DeleteCaracteristicaTransporte(int id)
        {
            try
            {
                var result = _caracteristicaTransporteService.RemoveCaracteristicaTransporte(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
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
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
            }
        }
    }
}
