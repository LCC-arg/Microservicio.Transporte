using Application.Exceptions;
using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Application.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.TipoTransporteTest
{
    public class TipoTransporteControllerGet_Test
    {
        [Fact]
        public void TipoTransporteControllerGetbyId_ReturnStatusCode200()
        {
            var mockTipoTransporte = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporte.Object);

            var expectedCode = 200;
            var tipoResponse = new TipoTransporteResponse { Descripcion = "Descripcion Test", Id = 1 };

            mockTipoTransporte.Setup(T => T.GetTipoTransportebyId(It.IsAny<int>())).Returns(tipoResponse);

            var result = controller.GetTipoTransportebyId(1);
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
        public void TipoTransporteControllerGetbyId_Return404NotFound()
        {
            var mockTipoTransporteService = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporteService.Object);

            var expectedErrorMessage = "No existe Transporte con ese ID en la base de datos.";
            var expectedCode = 404;

            mockTipoTransporteService.Setup(s => s.GetTipoTransportebyId(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            // Act
            var result = controller.GetTipoTransportebyId(1);

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
        public void TipoTransporteControllerGetAll_ReturnStatusCode200()
        {
            //Arrange
            var mockTipoTransporteService = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporteService.Object);
            var expectedCode = 200;

            var listaTipoTransporteResponse = new List<TipoTransporteResponse>
            {
                new TipoTransporteResponse { Id = 1, Descripcion = "Test Descripcion"},
                new TipoTransporteResponse { Id = 2, Descripcion = "Test Descripcion2"}
            };

            mockTipoTransporteService.Setup(T => T.GetAllTipoTransporte()).Returns(listaTipoTransporteResponse);

            //Act
            var result = controller.GetAllTipoTransporte();


            //Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as List<TipoTransporteResponse>;
            Assert.NotNull(response);

            response.Should().BeEquivalentTo(listaTipoTransporteResponse);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }
    }
}
