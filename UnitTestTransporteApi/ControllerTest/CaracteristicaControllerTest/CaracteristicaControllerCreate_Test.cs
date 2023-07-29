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
    public class CaracteristicaControllerCreate_Test
    {
        [Fact]
        public void CaracteristicaControllerCreate_ReturnStatusCode201()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 201;

            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Tamaño de neumatico" };
            var caracteristicaResponse = new CaracteristicaResponse { Descripcion = "Tamaño de neumatico", Id = 1 };

            mockCaracteristicaService.Setup(c => c.CreateCaracteristica(It.IsAny<CaracteristicaRequest>())).Returns(caracteristicaResponse);

            var result = controller.CreateCaracteristica(caracteristicaRequest);

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
        public void CaracteristicaControllerCreate_Return409Conflict()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 409;
            var expectedErrorMessage = "Ya se ha registrado una caracteristica con esa descripcion en la base de datos";

            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Tamaño de neumatico" };

            mockCaracteristicaService.Setup(c => c.CreateCaracteristica(It.IsAny<CaracteristicaRequest>())).Throws(new ValorConflictException(expectedErrorMessage));

            var result = controller.CreateCaracteristica(caracteristicaRequest);

            Assert.IsType<ConflictObjectResult>(result);
            var conflictResult = result as ConflictObjectResult;
            Assert.NotNull(conflictResult);
            Assert.Equal(expectedCode, conflictResult.StatusCode);

            var errorMessage = conflictResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(errorMessage.Message, expectedErrorMessage);
        }
    }
}
