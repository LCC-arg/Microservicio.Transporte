using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Request;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTransporteApi.CaracteristicaTest
{
    public class CaracteristicaUpdate_Test
    {
        private Mock<ICaracteristicaCommand> mockCaracteristicaCommand;
        private Mock<ICaracteristicaQuery> mockCaracteristicaQuery;

        public CaracteristicaUpdate_Test()
        {
            mockCaracteristicaCommand = new Mock<ICaracteristicaCommand>();
            mockCaracteristicaQuery = new Mock<ICaracteristicaQuery>();
        }

        [Fact]
        public void CaracteristicaUpdate_ShouldReturnCorrectResponse()
        {
            //Arrange
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Descripcion Test" };
            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Marca" };

            var listaCaracteristicaExistentes = new List<Caracteristica> { caracteristica };

            mockCaracteristicaQuery.Setup(q => q.GetCaracteristicasById(It.IsAny<int>())).Returns(caracteristica);
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristicaExistentes);
            mockCaracteristicaCommand.Setup(q => q.ActualizeCaracteristica(It.IsAny<int>(), It.IsAny<CaracteristicaRequest>()))
            .Returns((int id, CaracteristicaRequest request) =>
            {
                caracteristica.CaracteristicaId = id;
                caracteristica.Descripcion = request.Descripcion;

                return caracteristica;
            });

            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            //Act
            var result = service.UpdateCaracteristica(1, caracteristicaRequest);

            //Assert
            result.Id.Should().Be(caracteristica.CaracteristicaId);
            result.Descripcion.Should().Be(caracteristicaRequest.Descripcion);
        }

        [Fact]
        public void CaracteristicaUpdate_ShouldThrowExceptionIfCaracteristicaIsNull()
        {
            //Arrange
            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Marca" };

            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateCaracteristica(1, caracteristicaRequest));
        }

        [Fact]
        public void CaracteristicaUpdate_ShouldThrowExceptionIfDescripcionExists()
        {
            //Arrange
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Marca" };
            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Marca" };

            var listaCaracteristicaExistentes = new List<Caracteristica> { caracteristica };

            mockCaracteristicaQuery.Setup(q => q.GetCaracteristicasById(It.IsAny<int>())).Returns(caracteristica);
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristicaExistentes);

            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            //Act & Assert
            Assert.Throws<ValorConflictException>(() => service.UpdateCaracteristica(1, caracteristicaRequest));
        }
    }
}
