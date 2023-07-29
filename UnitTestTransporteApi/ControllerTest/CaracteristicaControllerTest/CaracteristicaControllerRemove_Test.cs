using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
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

namespace UnitTestTransporteApi.ControllerTest.CaracteristicaControllerTest
{
    public class CaracteristicaControllerRemove_Test
    {
        [Fact]
        public void CaracteristicaControllerRemove_ReturnStatusCode200()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 200;
            var caracteristicaResponse = new CaracteristicaResponse { Descripcion = "Marca", Id = 1 };

            mockCaracteristicaService.Setup(c => c.RemoveCaracteristica(It.IsAny<int>())).Returns(caracteristicaResponse);

            var result = controller.DeleteCaracteristica(1);

            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;
            Assert.NotNull(jsonResult);
            Assert.Equal(expectedCode, jsonResult.StatusCode);

            var response = jsonResult.Value as CaracteristicaResponse;
            Assert.NotNull(response);

            response.Id.Should().Be(caracteristicaResponse.Id);
            response.Descripcion.Should().Be(caracteristicaResponse.Descripcion);
        }

        [Fact]
        public void CaracteristicaControllerRemove_Return404NOtFound()
        {
            var mockCaracteristicaService = new Mock<ICaracteristicaService>();
            var controller = new CaracteristicaController(mockCaracteristicaService.Object);
            var expectedCode = 404;
            var expectedErrorMessage = "No se encuentra ninguna caracteristica con ese Id en la base de datos.";

            mockCaracteristicaService.Setup(c => c.RemoveCaracteristica(It.IsAny<int>())).Throws(new ValorBadRequestException(expectedErrorMessage));

            var result = controller.DeleteCaracteristica(1);

            Assert.IsType<NotFoundObjectResult>(result);
            var notFoundResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundResult);
            Assert.Equal(notFoundResult.StatusCode, expectedCode);

            var errorMessage = notFoundResult.Value as BadRequest;
            Assert.NotNull(errorMessage);
            Assert.Equal(errorMessage.Message, expectedErrorMessage);
        }
    }
}
