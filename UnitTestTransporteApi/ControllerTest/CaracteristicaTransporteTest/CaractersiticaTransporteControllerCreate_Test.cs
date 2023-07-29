using Application.Exceptions;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Request;
using Application.Responses;
using Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Drawing;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.CaracteristicaTransporteTest
{
    public class CaractersiticaTransporteControllerCreate_Test
    {
        [Fact]
        public void CaracTransporteControllerCreate_ReturnStatusCode201()
        {
            var mockCaracteristicaTransporteService = new Mock<ICaracteristicaTransporteService>();
            var controller = new CaracteristicaTransporteController(mockCaracteristicaTransporteService.Object);

            var expectedCode = 201;

            var caracTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 3, TransporteId = 2, Valor = "Valor Test" };
            var caracTransporteResponse = new CaracteristicaTransporteResponse { Id = 1, TransporteId = 2, CaracteristicaId = 3, valor = "Valor Test" };

            mockCaracteristicaTransporteService.Setup(CT => CT.CreateCaracteristicaTransporte(It.IsAny<CaracteristicaTransporteRequest>())).Returns(caracTransporteResponse);

            var result = controller.CreateCaracteristicaTransporte(caracTransporteRequest);

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
        public void CaracTransporteControllerCreate_Return404NotFound()
        {
            var mockCaracteristicaTransporteService = new Mock<ICaracteristicaTransporteService>();
            var controller = new CaracteristicaTransporteController(mockCaracteristicaTransporteService.Object);
            var expectedCode = 404;
            var expectedErrorMessage = "No existe una caracteristica registrada en la base de datos con ese ID";

            var caracTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 3, TransporteId = 2, Valor = "Valor Test" };
            mockCaracteristicaTransporteService.Setup(CT => CT.CreateCaracteristicaTransporte(It.IsAny<CaracteristicaTransporteRequest>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            var result = controller.CreateCaracteristicaTransporte(caracTransporteRequest);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
            var NotFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(NotFoundResult);
            Assert.Equal(expectedCode, NotFoundResult.StatusCode);

            var errorMessage = NotFoundResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(expectedErrorMessage, errorMessage.Message);
        }
    }
}
