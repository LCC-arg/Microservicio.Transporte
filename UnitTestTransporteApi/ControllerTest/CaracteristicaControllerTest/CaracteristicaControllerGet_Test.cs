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
    public class CaracteristicaControllerGet_Test
    {
        [Fact]
        public void CaracteristicaControllerGetbyId_ReturnStatusCode200()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 200;
            var caracteristicaResponse = new CaracteristicaResponse { Descripcion = "Tamaño de neumatico", Id = 1 };

            mockCaracteristicaService.Setup(c => c.GetCaracteristicabyId(It.IsAny<int>())).Returns(caracteristicaResponse);

            var result = controller.GetById(1);

            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);
            Assert.Equal(expectedCode, jsonResult.StatusCode);

            var response = jsonResult.Value as CaracteristicaResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(caracteristicaResponse.Id);
            response.Descripcion.Should().Be(caracteristicaResponse.Descripcion);
        }

        [Fact]
        public void CaracteristicaControllerGetbyId_Return404NotFound()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 404;
            var expectedErrorMessage = "No se encuentra ninguna caracteristica con ese Id en la base de datos.";

            mockCaracteristicaService.Setup(c => c.GetCaracteristicabyId(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            var result = controller.GetById(1);

            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal(notFoundResult.StatusCode, expectedCode);

            var errorMessage = notFoundResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(errorMessage.Message, expectedErrorMessage);
        }

        [Fact]
        public void CaracteristicaControllerGetAll_ReturnStatusCode200()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 200;
            var listaCaracteristicaResponse = new List<CaracteristicaResponse> 
            {
                new CaracteristicaResponse { Descripcion = "Tamaño de neumatico", Id = 1 },
                new CaracteristicaResponse { Descripcion = "Marca", Id = 2 },
            };

            mockCaracteristicaService.Setup(c => c.GetAllCaracteristica()).Returns(listaCaracteristicaResponse);

            var result = controller.GetAll();

            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);
            Assert.Equal(expectedCode, jsonResult.StatusCode);

            var response = jsonResult.Value as List<CaracteristicaResponse>;
            Assert.NotNull(response);

            response.Should().BeEquivalentTo(listaCaracteristicaResponse);
        }
    }
}
