using Application.Exceptions;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Request;
using Application.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.CaracteristicaTransporteTest
{
    public class CaracteristicaTransporteControllerGet_Test
    {
        [Fact]
        public void CaracteristicaTransporteControllerGetAll_ReturnStatusCode200() 
        {
            var mockCaracteristicaTransporteService = new Mock<ICaracteristicaTransporteService>();
            var controller = new CaracteristicaTransporteController(mockCaracteristicaTransporteService.Object);

            var expectedCode = 200;

            var listaCaracteristicaTransporteResponse = new List<CaracteristicaTransporteResponse>
            {
                new CaracteristicaTransporteResponse { Id = 1, CaracteristicaId = 1, TransporteId = 1, valor = "Valor Test1" },
                new CaracteristicaTransporteResponse { Id = 2, CaracteristicaId = 2, TransporteId = 2, valor = "Valor Test2" },
            };

            mockCaracteristicaTransporteService.Setup(c => c.GetAllCaracteristicaTransporte(null, null)).Returns(listaCaracteristicaTransporteResponse);
            var result = controller.GetAllCaracteristicaTransporte(null, null);

            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as List<CaracteristicaTransporteResponse>;
            Assert.NotNull(response);

            response.Should().BeEquivalentTo(listaCaracteristicaTransporteResponse);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void CaracteristicaTransporteControllerGetById_ReturnStatusCode200()
        {
            var mockCaracteristicaTransporteService = new Mock<ICaracteristicaTransporteService>();
            var controller = new CaracteristicaTransporteController(mockCaracteristicaTransporteService.Object);

            var expectedCode = 200;

            var caracTransporteResponse = new CaracteristicaTransporteResponse { Id = 1, CaracteristicaId = 1, TransporteId = 1, valor = "Valor Test1" };

            mockCaracteristicaTransporteService.Setup(c => c.GetCaracteristicaTransportebyId(It.IsAny<int>())).Returns(caracTransporteResponse);

            var result = controller.GetCaracteristicaTransportebyId(1);

            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as CaracteristicaTransporteResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(caracTransporteResponse.Id);
            response.CaracteristicaId.Should().Be(caracTransporteResponse.CaracteristicaId);
            response.TransporteId.Should().Be(caracTransporteResponse.TransporteId);
            response.valor.Should().Be(caracTransporteResponse.valor);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void CaracteristicaTransporteControllerGetById_Return404NotFound()
        {
            var mockCaracteristicaTransporteService = new Mock<ICaracteristicaTransporteService>();
            var controller = new CaracteristicaTransporteController(mockCaracteristicaTransporteService.Object);

            var expectedCode = 404;
            var expectedErrorMessage = "No se encuentra ninguna CaracteristicaTransporte con ese ID en la base de datos.";

            mockCaracteristicaTransporteService.Setup(c => c.GetCaracteristicaTransportebyId(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            var result = controller.GetCaracteristicaTransportebyId(1);

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
