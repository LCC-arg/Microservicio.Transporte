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
    public class TipoTransporteControllerUpdate_Test
    {
        [Fact]
        public void TipoTransporteControllerUpdate_ReturnStatusCode200()
        {
            //Arrange
            var mockTipoTransporte = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporte.Object);

            var expectedCode = 200;
            var tipoRequest = new TipoTransporteRequest { Descripcion = "Auto" };
            var tipoResponse = new TipoTransporteResponse { Descripcion = tipoRequest.Descripcion, Id = 1 };

            mockTipoTransporte.Setup(T => T.UpdateTipoTransporte(It.IsAny<int>(), It.IsAny<TipoTransporteRequest>())).Returns(tipoResponse);

            //Act
            var result = controller.UpdateTipoTransporte(1,tipoRequest);

            //Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as TipoTransporteResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(tipoResponse.Id);
            response.Descripcion.Should().Be(tipoRequest.Descripcion);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void TipoTransporteControllerUpdate_Return404NotFound()
        {
            //Arrange
            var tipoRequest = new TipoTransporteRequest { Descripcion = "Auto" };
            var mockTipoTransporteService = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporteService.Object);
            var expectedCode = 404;

            var expectedErrorMessage = "El Transporte con ese ID no existe en la base de datos.";
            mockTipoTransporteService.Setup(c => c.UpdateTipoTransporte(It.IsAny<int>(), It.IsAny<TipoTransporteRequest>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            //Act
            var result = controller.UpdateTipoTransporte(1, tipoRequest);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal(expectedCode, notFoundResult.StatusCode);

            var errorMessage = notFoundResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(expectedErrorMessage, errorMessage.Message); ;
        }

        [Fact]
        public void TipoTransporteControllerUpdate_Return409Conflict()
        {
            //Arrange
            var tipoRequest = new TipoTransporteRequest { Descripcion = "Auto" };
            var mockTipoTransporteService = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporteService.Object);
            var expectedCode = 409;

            var expectedErrorMessage = "Esa descripcion ya existe en la base de datos.";
            mockTipoTransporteService.Setup(c => c.UpdateTipoTransporte(It.IsAny<int>(), It.IsAny<TipoTransporteRequest>())).Throws(new ValorConflictException(expectedErrorMessage));

            //Act
            var result = controller.UpdateTipoTransporte(1, tipoRequest);

            // Assert
            Assert.IsType<ConflictObjectResult>(result);
            var conflictResult = result as ConflictObjectResult;
            Assert.NotNull(conflictResult);
            Assert.Equal(expectedCode, conflictResult.StatusCode);

            var errorMessage = conflictResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(expectedErrorMessage, errorMessage.Message); ;
        }
    }
}
