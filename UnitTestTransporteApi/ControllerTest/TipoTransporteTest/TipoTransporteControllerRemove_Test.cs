using Application.Exceptions;
using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Application.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.TipoTransporteTest
{
    public class TipoTransporteControllerRemove_Test
    {
        [Fact]
        public void TipoTransporteControllerRemove_ReturnStatusCode200()
        {
            //Arrange
            var mockTipoTransporte = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporte.Object);

            var expectedCode = 200;
            var tipoResponse = new TipoTransporteResponse { Descripcion = "Descripcion Test", Id = 1 };

            mockTipoTransporte.Setup(T => T.RemoveTipoTransporte(It.IsAny<int>())).Returns(tipoResponse);

            //Act
            var result = controller.DeleteTipoTransporte(1);

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
        public void TipoTransporteControllerRemove_Return404NotFound()
        {
            //Arrange
            var mockTipoTransporteService = new Mock<ITipoTransporteService>();
            var controller = new TipoTransporteController(mockTipoTransporteService.Object);

            var expectedErrorMessage = "No existe Transporte con ese ID en la base de datos.";
            var expectedCode = 404;

            mockTipoTransporteService.Setup(s => s.RemoveTipoTransporte(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            // Act
            var result = controller.DeleteTipoTransporte(1);

            // Assert
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
