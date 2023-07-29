using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Request;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.CaracteristicaTest
{
    public class CaracteristicaCreate_Test
    {
        private Mock<ICaracteristicaCommand> mockCaracteristicaCommand;
        private Mock<ICaracteristicaQuery> mockCaracteristicaQuery;

        public CaracteristicaCreate_Test()
        {
            mockCaracteristicaCommand = new Mock<ICaracteristicaCommand>();
            mockCaracteristicaQuery = new Mock<ICaracteristicaQuery>();
        }

        [Fact]
        public void CaracteristicaCreate_ShouldReturnCorrectResponse()
        {
            //Arrange
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(new List<Caracteristica>());
            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Marca" };

            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            //Act
            var result = service.CreateCaracteristica(caracteristicaRequest);

            //Assert
            result.Descripcion.Should().Be(caracteristicaRequest.Descripcion);
        }

        [Fact]
        public void CreateCaracteristica_IfCaractersiticaExists()
        {
            var listaCaracteristica = new List<Caracteristica>
            {
                new Caracteristica { CaracteristicaId = 1, Descripcion = "Marca"}
            };

            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);

            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            var caracteristicaRequest = new CaracteristicaRequest { Descripcion = "Marca" };

            // Act & Assert
            Assert.Throws<ValorConflictException>(() => service.CreateCaracteristica(caracteristicaRequest));
        }
    }
}
