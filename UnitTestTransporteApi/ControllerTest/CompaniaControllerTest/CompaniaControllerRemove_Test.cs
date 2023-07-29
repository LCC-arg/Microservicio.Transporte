using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Request;
using Application.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.CompaniaControllerTest
{
    public class CompaniaControllerRemove_Test
    {
        [Fact]
        public void CompaniaControllerRemove_ReturnStatusCode200()
        {
            //Arrange
            var mockCompaniaService = new Mock<ICompaniaTransporteService>();
            var controller = new CompaniaTransporteController(mockCompaniaService.Object);
            var expectedCode = 200;
            var companiaResponse = new CompaniaTransporteResponse { Id = 1, Cuit = "Test 123", Imagen = "Test Imagen", RazonSocial = "Test Razon Social" };

            mockCompaniaService.Setup(c => c.RemoveCompaniaTransporte(It.IsAny<int>())).Returns(companiaResponse);

            //Act
            var result = controller.DeleteCompaniaTransporte(1);

            // Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);
            Assert.Equal(jsonResult.StatusCode, expectedCode);

            var response = jsonResult.Value as CompaniaTransporteResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(companiaResponse.Id);
            response.Cuit.Should().Be(companiaResponse.Cuit);
            response.Imagen.Should().Be(companiaResponse.Imagen);
            response.RazonSocial.Should().Be(companiaResponse.RazonSocial);

        }

        [Fact]
        public void CompaniaControllerRemove_Return404NotFound()
        {
            var mockCompaniaService = new Mock<ICompaniaTransporteService>();
            var controller = new CompaniaTransporteController(mockCompaniaService.Object);
            var expectedCode = 404;
            var expectedErrorMessage = "La compania de transporte con ese ID no existe en la base de datos.";
            mockCompaniaService.Setup(c => c.RemoveCompaniaTransporte(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            //Act
            var result = controller.DeleteCompaniaTransporte(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
            var NotFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(NotFoundResult);
            Assert.Equal(expectedCode, NotFoundResult.StatusCode);

            var errorMessage = NotFoundResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(expectedErrorMessage, errorMessage.Message);
        }
    }
}
