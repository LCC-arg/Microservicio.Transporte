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
    public class CompaniaControllerUpdate_Test
    {
        [Fact]
        public void UpdateCompaniaController_ReturnStatusCode200()
        {
            //Arrange
            var companiaRequest = new CompaniaTransporteRequest { Cuit = "Test 123", Imagen = "Test Imagen", RazonSocial = "Test Razon Social" };
            var mockCompaniaService = new Mock<ICompaniaTransporteService>();
            var controller = new CompaniaTransporteController(mockCompaniaService.Object);
            var expectedCode = 200;

            var companiaResponse = new CompaniaTransporteResponse { Id = 1, Cuit = "Test 123", Imagen = "Test Imagen", RazonSocial = "Test Razon Social" };

            mockCompaniaService.Setup(c => c.UpdateCompaniaTransporte(It.IsAny<int>(), companiaRequest)).Returns(companiaResponse);

            //Act
            var result = controller.UpdateCompaniaTransporte(1, companiaRequest);

            // Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);
            Assert.Equal(jsonResult.StatusCode, expectedCode);

            var response = jsonResult.Value as CompaniaTransporteResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(companiaResponse.Id);
            response.Cuit.Should().Be(companiaRequest.Cuit);
            response.Imagen.Should().Be(companiaRequest.Imagen);
            response.RazonSocial.Should().Be(companiaRequest.RazonSocial);

        }

        [Fact]
        public void UpdateCompaniaController_Return404NotFound()
        {
            //Arrange
            var companiaRequest = new CompaniaTransporteRequest { Cuit = "Test 123", Imagen = "Test Imagen", RazonSocial = "Test Razon Social" };
            var mockCompaniaService = new Mock<ICompaniaTransporteService>();
            var controller = new CompaniaTransporteController(mockCompaniaService.Object);
            var expectedCode = 404;

            var expectedErrorMessage = "La Compania de transporte con ese ID no existe en la base de datos.";
            mockCompaniaService.Setup(c => c.UpdateCompaniaTransporte(It.IsAny<int>(), It.IsAny<CompaniaTransporteRequest>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            //Act
            var result = controller.UpdateCompaniaTransporte(1, companiaRequest);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal(expectedCode, notFoundResult.StatusCode);

            var errorMessage =  notFoundResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(expectedErrorMessage, errorMessage.Message); ;
        }

        [Fact]
        public void UpdateCompaniaController_Return409Conflict()
        {
            //Arrange
            var companiaRequest = new CompaniaTransporteRequest { Cuit = "Test 123", Imagen = "Test Imagen", RazonSocial = "Test Razon Social" };
            var mockCompaniaService = new Mock<ICompaniaTransporteService>();
            var controller = new CompaniaTransporteController(mockCompaniaService.Object);
            var expectedCode = 409;
            var expectedErrorMessage = "La Razon Social ingresada ya se encuentra en la base de datos.";
            mockCompaniaService.Setup(c => c.UpdateCompaniaTransporte(It.IsAny<int>(), companiaRequest)).Throws(new ValorConflictException(expectedErrorMessage));

            //Act
            var result = controller.UpdateCompaniaTransporte(1, companiaRequest);

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
