using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.CaracteristicaTest
{
    public class CaracteristicaRemove_Test
    {
        private Mock<ICaracteristicaCommand> mockCaracteristicaCommand;
        private Mock<ICaracteristicaQuery> mockCaracteristicaQuery;

        public CaracteristicaRemove_Test()
        {
            mockCaracteristicaCommand = new Mock<ICaracteristicaCommand>();
            mockCaracteristicaQuery = new Mock<ICaracteristicaQuery>();
        }

        [Fact]
        public void CaracteristicaRemove_ShouldReturnCorrectResponse()
        {
            //Arrange
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Marca" };
            var listaCaracteristicasExistentes = new List<Caracteristica>() { caracteristica };

            mockCaracteristicaCommand.Setup(q => q.DeleteCaracteristica(It.IsAny<int>())).Returns(caracteristica);
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristicasExistentes);

            //Act
            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            //Assert
            var result = service.RemoveCaracteristica(1);

            result.Id.Should().Be(caracteristica.CaracteristicaId);
            result.Descripcion.Should().Be(caracteristica.Descripcion);
        }

        [Fact]
        public void CaracteristicaRemove_ShouldThrowExcepcionIfCaracteristicaIsNull()
        {
            //Arrange
            var listaCaracteristicaExistentes = new List<Caracteristica>();
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristicaExistentes);

            var service = new CaracteristicaService(mockCaracteristicaCommand.Object, mockCaracteristicaQuery.Object);

            // Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.RemoveCaracteristica(1));
        }
    }

}
