using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Responses;
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
    public class CaracteristicaGet_Test
    {
        private Mock<ICaracteristicaCommand> mockCaracteristicaCommand;
        private Mock<ICaracteristicaQuery> mockCaracteristicaQuery;

        public CaracteristicaGet_Test()
        {
            mockCaracteristicaCommand = new Mock<ICaracteristicaCommand>();
            mockCaracteristicaQuery = new Mock<ICaracteristicaQuery>();
        }

        [Fact]
        public void GetCaracteristicaById_ShouldReturnCorrectResponse()
        {
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Descripcion Test" };

            mockCaracteristicaQuery.Setup(q => q.GetCaracteristicasById(It.IsAny<int>())).Returns(caracteristica);

            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            //Act
            var result = service.GetCaracteristicabyId(1);

            //Assert
            result.Id.Should().Be(caracteristica.CaracteristicaId);
            result.Descripcion.Should().Be(caracteristica.Descripcion);
        }

        [Fact]
        public void GetCaracteristicaById_ShouldThrowExceptionIfCaracteristicaIsNull()
        {
            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            Assert.Throws<ValorBadRequestException>(() => service.GetCaracteristicabyId(1));
        }

        [Fact]
        public void GetAllCaracteristica_ShouldReturnCorrectResponse()
        {
            List<CaracteristicaResponse> listaCaracteristicaResponses = new List<CaracteristicaResponse>();
            var listaCaracteristicaExistentes = new List<Caracteristica>()
            {
                new Caracteristica { CaracteristicaId = 1, Descripcion = "Descripcion Test" },
                new Caracteristica {CaracteristicaId = 2, Descripcion = "Descripcion Test 2"}
            };

            foreach (var c in listaCaracteristicaExistentes)
            {
                var caracteristicaResponse = new CaracteristicaResponse { Id = c.CaracteristicaId, Descripcion = c.Descripcion };
                listaCaracteristicaResponses.Add(caracteristicaResponse);
            }

            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristicaExistentes);

            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            var result = service.GetAllCaracteristica();

            result.Should().BeEquivalentTo(listaCaracteristicaResponses);
        }
    }
}
