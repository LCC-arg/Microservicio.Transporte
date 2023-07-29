using Application.Exceptions;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Request;
using Application.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.CaracteristicaTransporteTest
{
    public class CaracteristicaTransporteControllerUpdate_Test
    {
        [Fact]
        public void CaracTransporteControllerUpdate_ReturnStatusCode200()
        {
            var mockCaracteristicaTransporteService = new Mock<ICaracteristicaTransporteService>();
            var controller = new CaracteristicaTransporteController(mockCaracteristicaTransporteService.Object);

            var expectedCode = 200;

            var caracTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 3, TransporteId = 2, Valor = "Valor Test" };
            var caracTransporteResponse = new CaracteristicaTransporteResponse { Id = 1, TransporteId = 2, CaracteristicaId = 3, valor = "Valor Test" };

            mockCaracteristicaTransporteService.Setup(CT => CT.UpdateCaracteristicaTransporte(It.IsAny<int>(),It.IsAny<CaracteristicaTransporteRequest>())).Returns(caracTransporteResponse);

            var result = controller.UpdateCaracteristicaTransporte(1,caracTransporteRequest);

            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as CaracteristicaTransporteResponse;
            Assert.NotNull(response);

            response.CaracteristicaId.Should().Be(caracTransporteRequest.CaracteristicaId);
            response.TransporteId.Should().Be(caracTransporteRequest.TransporteId);
            response.valor.Should().Be(caracTransporteRequest.Valor);
            response.Id.Should().Be(caracTransporteResponse.Id);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void CaracTransporteControllerUpdate_Return404NotFound()
        {
            var mockCaracteristicaTransporteService = new Mock<ICaracteristicaTransporteService>();
            var controller = new CaracteristicaTransporteController(mockCaracteristicaTransporteService.Object);
            var caracTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 3, TransporteId = 2, Valor = "Valor Test" };
            var expectedCode = 404;
            var expectedErrorMessage = "No se encuentra ninguna CaracteristicaTransporte con ese ID en la base de datos.";

            mockCaracteristicaTransporteService.Setup(c => c.UpdateCaracteristicaTransporte(It.IsAny<int>(), It.IsAny<CaracteristicaTransporteRequest>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            var result = controller.UpdateCaracteristicaTransporte(1, caracTransporteRequest);

            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal(expectedCode, notFoundResult.StatusCode);

            var response = notFoundResult.Value as BadRequest;
            Assert.NotNull(response);
            Assert.Equal(expectedErrorMessage, response.Message);
        }
    }
}
