using Application.Exceptions;
using Application.Interfaces.ITransporte;
using Application.Request;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace TransporteWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class TransporteController : ControllerBase
    {
        private readonly ITransporteService _transporteService;

        public TransporteController(ITransporteService transporteService)
        {
            _transporteService = transporteService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TransporteResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult CreateTransporte(TransporteRequest transporteRequest)
        {
            try
            {
                var result = _transporteService.CreateTransporte(transporteRequest);
                return new JsonResult(result) { StatusCode = 201 };

            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransporteGetResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult GetTransportebyId(int id)
        {
            try
            {
                var result = _transporteService.GetTransportebyId(id);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(TransporteGetResponse), 200)]
        public IActionResult GetAllTransporte()
        {
            var result = _transporteService.GetAllTransporte();
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult DeleteTransporte(int id)
        {
            try
            {
                var result = _transporteService.RemoveTransporte(id);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TransporteResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult UpdateTransporte(int id, TransporteRequest transporteRequest)
        {
            try
            {
                var result = _transporteService.UpdateTransporte(id,transporteRequest);
                return new JsonResult(result);
            }
            catch (ValorBadRequestException valor)
            {
                return NotFound(new { valor.Message });
            }
        }
    }
}
