using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Application.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.TipoTransporteTest
{
    public class TipoTransporteControllerCreate_Test
    {
        [Fact]
        public void TipoTransporteControllerCreate_ReturnStatusCode201()
        {
            //Arrange
            var mockTipoTransporte = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporte.Object);

            var expectedCode = 201;

            var tipoRequest = new TipoTransporteRequest { Descripcion = "Tipo Transporte Test" };
            var tipoResponse = new TipoTransporteResponse { Descripcion = tipoRequest.Descripcion, Id = 1 };

            mockTipoTransporte.Setup(T => T.CreateTipoTransporte(It.IsAny<TipoTransporteRequest>())).Returns(tipoResponse);

            //Act
            var result = controller.CreateTipoTransporte(tipoRequest);
            
            //Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as TipoTransporteResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(tipoResponse.Id);
            response.Descripcion.Should().Be(tipoResponse.Descripcion);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void CreateTipoTransporte_Return409Conflict()
        {
            // Arrange
            var tipoTransporteRequest = new TipoTransporteRequest { Descripcion = "Tipo Transporte Test" };
            var mockTipoTransporteService = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporteService.Object);
            
            var expectedErrorMessage = "La descripcion ingresada ya se encuentra en la base de datos.";
            var expectedCode = 409;

            mockTipoTransporteService.Setup(s => s.CreateTipoTransporte(It.IsAny<TipoTransporteRequest>())).Throws(new ValorConflictException(expectedErrorMessage));

            // Act
            var result = controller.CreateTipoTransporte(tipoTransporteRequest);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
            var conflictResult = result as ConflictObjectResult;
            Assert.NotNull(conflictResult);
            Assert.Equal(expectedCode, conflictResult.StatusCode);

            var errorMessage = conflictResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(expectedErrorMessage, errorMessage.Message);
        }
    }
}
