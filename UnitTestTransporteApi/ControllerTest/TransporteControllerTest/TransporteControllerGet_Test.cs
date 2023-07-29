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
    public class TransporteControllerGet_Test
    {
        [Fact]
        public void TransporteControllerGetById_ReturnStatusCode200()
        {
            //Arrange
            var mockTransporteService = new Mock<ITransporteService>();
            var controller = new TransporteController(mockTransporteService.Object);
            var expectedCode = 200;

            var transporteGetResponse = new TransporteGetResponse 
            {
                Id = 1,
                TipoTransporteResponse = new TipoTransporteResponse
                {
                    Id = 2,
                    Descripcion = "Tipo Transporte Test"
                },
                CompaniaTransporteResponse = new CompaniaTransporteResponse
                {
                    Id = 3,
                    Cuit = "Cuit Test",
                    RazonSocial = "Razon Social Test",
                    Imagen = "Imagen Test"
                }
            };

            mockTransporteService.Setup(t => t.GetTransportebyId(It.IsAny<int>())).Returns(transporteGetResponse);

            //Act
            var result = controller.GetTransportebyId(1);

            //Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as TransporteGetResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(transporteGetResponse.Id);
            response.TipoTransporteResponse.Should().Be(transporteGetResponse.TipoTransporteResponse);
            response.CompaniaTransporteResponse.Should().Be(transporteGetResponse.CompaniaTransporteResponse);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }

        [Fact]
        public void TransporteControllerGetById_Return404NotFound()
        {
            //Arrange
            var mockTransporteService = new Mock<ITransporteService>();
            var controller = new TransporteController(mockTransporteService.Object);
            var expectedCode = 404;
            var expectedErrorMessage = "El Transporte con ese ID no existe en la base de datos.";

            mockTransporteService.Setup(c => c.GetTransportebyId(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            //Act
            var result = controller.GetTransportebyId(1);

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
        public void TransporteControllerGetAll_ReturnStatusCode200()
        {
            //Arrange
            var mockTransporteService = new Mock<ITransporteService>();
            var controller = new TransporteController(mockTransporteService.Object);
            var expectedCode = 200;

            var listaTransporteResponse = new List<TransporteGetResponse>
            {
                new TransporteGetResponse 
                {
                    Id = 1,
                    TipoTransporteResponse = new TipoTransporteResponse
                    {
                        Id = 2,
                        Descripcion = "Tipo Transporte Test"
                    },
                    CompaniaTransporteResponse = new CompaniaTransporteResponse
                    {
                        Id = 3,
                        Cuit = "Cuit Test",
                        RazonSocial = "Razon Social Test",
                        Imagen = "Imagen Test"
                    }
                },
                new TransporteGetResponse 
                { 
                    Id = 2,
                    TipoTransporteResponse = new TipoTransporteResponse
                    {
                        Id = 1,
                        Descripcion = "Tipo Transporte2 Test"
                    },
                    CompaniaTransporteResponse = new CompaniaTransporteResponse
                    {
                        Id = 1,
                        Cuit = "Cuit Test2",
                        RazonSocial = "Razon Social Test2",
                        Imagen = "Imagen Test2"
                    }
                },
            };

            mockTransporteService.Setup(T => T.GetAllTransporte()).Returns(listaTransporteResponse);
            
            //Act
            var result = controller.GetAllTransporte();

            //Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);

            var response = jsonResult.Value as List<TransporteGetResponse>;
            Assert.NotNull(response);

            response.Should().BeEquivalentTo(listaTransporteResponse);
            jsonResult.StatusCode.Should().Be(expectedCode);
        }
    }
}
