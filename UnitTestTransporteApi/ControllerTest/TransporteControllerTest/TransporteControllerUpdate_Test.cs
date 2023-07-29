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
    public class TransporteControllerUpdate_Test
    {
        [Fact]
        public void TransporteControllerUpdate_ReturnStatusCode200()
        {
            //Arrange
            var mockTransporteService = new Mock<ITransporteService>();
            var controller = new TransporteController(mockTransporteService.Object);
            var expectedCode = 200;

            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };
            var transporteResponse = new TransporteResponse { Id = 1, TipoTransporteId = transporteRequest.TipoTransporteId, CompaniaTransporteId = transporteRequest.CompaniaTransporteId};

            mockTransporteService.Setup(t => t.UpdateTransporte(It.IsAny<int>(), It.IsAny<TransporteRequest>())).Returns(transporteResponse);

            //Act
            var result = controller.UpdateTransporte(1, transporteRequest);

            //Arrange
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as TransporteResponse;
            Assert.NotNull(response);

            response.CompaniaTransporteId.Should().Be(transporteRequest.CompaniaTransporteId);
            response.TipoTransporteId.Should().Be(transporteRequest.TipoTransporteId);
            response.Id.Should().Be(transporteResponse.Id);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void TransporteControllerUpdate_Return404NotFound()
        {
            //Arrange
            var mockTransporteService = new Mock<ITransporteService>();
            var controller = new TransporteController(mockTransporteService.Object);
            var expectedCode = 404;
            var expectedErrorMessage = "El Tipo Transporte ingresado no existe en la base de datos.";
            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };

            mockTransporteService.Setup(T => T.UpdateTransporte(It.IsAny<int>(), It.IsAny<TransporteRequest>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            //Act
            var result = controller.UpdateTransporte(1,transporteRequest);

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
