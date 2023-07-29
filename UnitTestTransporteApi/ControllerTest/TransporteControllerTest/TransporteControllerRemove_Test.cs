using Application.Exceptions;
using Application.Interfaces.ITransporte;
using Application.Request;
using Application.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.TransporteControllerTest
{
    public class TransporteControllerRemove_Test
    {
        [Fact]
        public void TransporteControllerRemove_ReturnStatusCode200()
        {
            //Arrange
            var mockTransporteService = new Mock<ITransporteService>();
            var controller = new TransporteController(mockTransporteService.Object);
            var expectedCode = 200;

            var transporteResponse = new TransporteResponse { Id = 1, TipoTransporteId = 3, CompaniaTransporteId = 3 };

            mockTransporteService.Setup(t => t.RemoveTransporte(It.IsAny<int>())).Returns(transporteResponse);

            //Act
            var result = controller.DeleteTransporte(1);

            //Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as TransporteResponse;
            Assert.NotNull(response);

            response.CompaniaTransporteId.Should().Be(transporteResponse.CompaniaTransporteId);
            response.TipoTransporteId.Should().Be(transporteResponse.TipoTransporteId);
            response.Id.Should().Be(transporteResponse.Id);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void TransporteControllerRemove_Return404NotFound()
        {
            //Arrange
            var mockTransporteService = new Mock<ITransporteService>();
            var controller = new TransporteController(mockTransporteService.Object);
            var expectedCode = 404;
            var expectedErrorMessage = "El Transporte ingresado no existe en la base de datos.";

            mockTransporteService.Setup(T => T.RemoveTransporte(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            //Act
            var result = controller.DeleteTransporte(1);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal(expectedCode, notFoundResult.StatusCode);

            var errorMessage = notFoundResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(expectedErrorMessage, errorMessage.Message); ;
        }
    }
}
