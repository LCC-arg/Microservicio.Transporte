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
    public class CompaniaControllerGet_Test
    {
        [Fact] 
        public void CompaniaControllerGetAll_ReturnStatusCode200()
        {
            // Arrange
            var expectedCode = 200;
            var mockCompaniaTransporteService = new Mock<ICompaniaTransporteService>();
            var controller = new CompaniaTransporteController(mockCompaniaTransporteService.Object);
            var listaCompaniaTransporte = new List<CompaniaTransporteResponse>
            {
                new CompaniaTransporteResponse { Id = 1, Cuit = "Cuit1", RazonSocial = "Razon Social 1", Imagen = "Imagen1" },
                new CompaniaTransporteResponse { Id = 2, Cuit = "Cuit2", RazonSocial = "Razon Social 2", Imagen = "Imagen2" }
            };

            mockCompaniaTransporteService.Setup(service => service.GetAllCompaniaTransporte()).Returns(listaCompaniaTransporte);

            // Act
            var result = controller.GetAllCompaniaTransporte();

            // Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as List<CompaniaTransporteResponse>;
            Assert.NotNull(response);

            response.Should().BeEquivalentTo(listaCompaniaTransporte);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void CompaniaControllerGetById_ReturnStatusCode200()
        {
            var expectedCode = 200;
            var mockCompaniaTransporteService = new Mock<ICompaniaTransporteService>();
            var controller = new CompaniaTransporteController(mockCompaniaTransporteService.Object);

            var companiaResponse = new CompaniaTransporteResponse { Id = 1, Cuit = "Cuit1", RazonSocial = "Razon Social 1", Imagen = "Imagen1" };

            mockCompaniaTransporteService.Setup(service => service.GetCompaniaTransportebyId(It.IsAny<int>())).Returns(companiaResponse);

            // Act
            var result = controller.GetCompaniaTransportebyId(1);

            // Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as CompaniaTransporteResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(companiaResponse.Id);
            response.Cuit.Should().Be(companiaResponse.Cuit);
            response.Imagen.Should().Be(companiaResponse.Imagen);
            response.RazonSocial.Should().Be(companiaResponse.RazonSocial);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void CompaniaControllerGetById_Return404NotFound()
        {
            var mockCompaniaService = new Mock<ICompaniaTransporteService>();
            var controller = new CompaniaTransporteController(mockCompaniaService.Object);
            var expectedCode = 404;
            
            var expectedErrorMessage = "La Compania de transporte con ese ID no existe en la base de datos.";
            mockCompaniaService.Setup(c => c.GetCompaniaTransportebyId(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            //Act
            var result = controller.GetCompaniaTransportebyId(1);

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
