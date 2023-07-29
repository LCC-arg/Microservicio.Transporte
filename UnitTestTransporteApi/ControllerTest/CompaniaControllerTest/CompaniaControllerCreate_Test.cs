using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Request;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TransporteWebApi.Controllers;

namespace UnitTestTransporteApi.ControllerTest.CompaniaControllerTest
{
    public class CompaniaControllerCreate_Test
    {
        [Fact]
        public void CreateCompaniaTransporte_ShouldReturnStatusCode201()
        {
            // Arrange
            var expectedCode = 201;
            var companiaTransporteRequest = new CompaniaTransporteRequest
            {
                Cuit = "Test cuit",
                RazonSocial = "Test Razon Social",
                Imagen = "Test Imagen"
            };

            var companiaResponse = new CompaniaTransporteResponse
            {
                Id = 1,
                Cuit = companiaTransporteRequest.Cuit,
                RazonSocial = companiaTransporteRequest.RazonSocial,
                Imagen = companiaTransporteRequest.Imagen
            };

            var mockCompaniaTransporteService = new Mock<ICompaniaTransporteService>();
            mockCompaniaTransporteService.Setup(s => s.CreateCompaniaTransporte(companiaTransporteRequest)).Returns(companiaResponse);

            var controller = new CompaniaTransporteController(mockCompaniaTransporteService.Object);

            // Act
            var result = controller.CreateCompaniaTransporte(companiaTransporteRequest);

            // Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);
            Assert.Equal(expectedCode, jsonResult.StatusCode);
            var response = jsonResult?.Value as CompaniaTransporteResponse;
            Assert.NotNull(response);

            Assert.Equal(companiaResponse.Id, response.Id);
            Assert.Equal(companiaTransporteRequest.Cuit, response.Cuit);
            Assert.Equal(companiaTransporteRequest.RazonSocial, response.RazonSocial);
            Assert.Equal(companiaTransporteRequest.Imagen, response.Imagen);
        }

        [Fact]
        public void CreateCompaniaTransporte_Return409Conflict()
        {
            // Arrange
            var companiaTransporteRequest = new CompaniaTransporteRequest{ Cuit = "Test cuit", RazonSocial = "Test Razon Social", Imagen = "Test Imagen" };
            var expectedErrorMessage = "El N° de Cuit ingresado ya se encuentra en la base de datos.";
            var expectedCode = 409;
            var mockCompaniaTransporteService = new Mock<ICompaniaTransporteService>();
            mockCompaniaTransporteService.Setup(s => s.CreateCompaniaTransporte(companiaTransporteRequest)).Throws(new ValorConflictException(expectedErrorMessage));

            var controller = new CompaniaTransporteController(mockCompaniaTransporteService.Object);

            // Act
            var result = controller.CreateCompaniaTransporte(companiaTransporteRequest);

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

