using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Request;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace TransporteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaracteristicaController : ControllerBase
    {
        private readonly ICaracteristicaService _caracteristicaService;

        public CaracteristicaController(ICaracteristicaService caracteristicaService)
        {
            _caracteristicaService = caracteristicaService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CaracteristicaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _caracteristicaService.GetCaracteristicabyId(id);
                return new JsonResult(result) { StatusCode = 200};
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
            }

        }


        [HttpGet]
        [ProducesResponseType(typeof(CaracteristicaResponse), 200)]
        public IActionResult GetAll()
        {
            var result = _caracteristicaService.GetAllCaracteristica();
            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpPost]
        [ProducesResponseType(typeof(CaracteristicaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult CreateCaracteristica (CaracteristicaRequest caracteristicaRequest)
        {
            try
            {
                var result = _caracteristicaService.CreateCaracteristica(caracteristicaRequest);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ValorConflictException valor)
            {
                return Conflict(new BadRequest { Message = valor.Message });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CaracteristicaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult UpdateCaracteristica(int id, CaracteristicaRequest caracteristicaRequest)
        {
            try
            {
                var result = _caracteristicaService.UpdateCaracteristica(id,caracteristicaRequest);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ValorConflictException valor)
            {
                return Conflict(new BadRequest { Message = valor.Message });
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CaracteristicaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult DeleteCaracteristica(int id)
        {
            try
            {
                var result = _caracteristicaService.RemoveCaracteristica(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new BadRequest { Message = valor.Message });
            }
        }
    }
}
