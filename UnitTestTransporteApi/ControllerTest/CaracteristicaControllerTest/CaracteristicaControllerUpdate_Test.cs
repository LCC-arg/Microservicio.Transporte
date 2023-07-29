using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Request;
using Application.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.CaracteristicaControllerTest
{
    public class CaracteristicaControllerUpdate_Test
    {
        [Fact]
        public void CaracteristicaControllerUpdate_ReturnStatusCode200()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 200;
            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Marca" };
            var caracteristicaResponse = new CaracteristicaResponse { Descripcion = "Marca", Id = 1 };

            mockCaracteristicaService.Setup(c => c.UpdateCaracteristica(It.IsAny<int>(),It.IsAny<CaracteristicaRequest>())).Returns(caracteristicaResponse);

            var result = controller.UpdateCaracteristica(1,caracteristicaRequest);

            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);
            Assert.Equal(expectedCode, jsonResult.StatusCode);

            var response = jsonResult.Value as CaracteristicaResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(caracteristicaResponse.Id);
            response.Descripcion.Should().Be(caracteristicaRequest.Descripcion);
        }

        [Fact]
        public void CaracteristicaControllerUpdate_Return404NOtFound()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 404;
            var expectedErrorMessage = "No se encuentra ninguna caracteristica con ese Id en la base de datos.";
            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Marca" };

            mockCaracteristicaService.Setup(c => c.UpdateCaracteristica(It.IsAny<int>(), It.IsAny<CaracteristicaRequest>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            var result = controller.UpdateCaracteristica(1, caracteristicaRequest);

            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal(notFoundResult.StatusCode, expectedCode);

            var errorMessage = notFoundResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(errorMessage.Message, expectedErrorMessage);
        }

        [Fact]
        public void CaracteristicaControllerUpdate_Return409Conflict()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 409;
            var expectedErrorMessage = "Ya hay una caracteristica con esa descripcion en la base de datos.";
            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Marca" };

            mockCaracteristicaService.Setup(c => c.UpdateCaracteristica(It.IsAny<int>(), It.IsAny<CaracteristicaRequest>())).Throws(new ValorConflictException(expectedErrorMessage));

            var result = controller.UpdateCaracteristica(1, caracteristicaRequest);

            Assert.IsType<ConflictObjectResult>(result);
            var conflictResult = result as ConflictObjectResult;
            Assert.NotNull(conflictResult);
            Assert.Equal(conflictResult.StatusCode, expectedCode);

            var errorMessage = conflictResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(errorMessage.Message, expectedErrorMessage);
        }
    }
}
