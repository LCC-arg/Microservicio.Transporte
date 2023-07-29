using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Interfaces.ITransporte;
using Application.Request;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.CaracteristicaTransporteTest
{
    public class CaracteristicaTransporteRemove_Test
    {
        private Mock<ITransporteQuery> mockTransporteQuery;
        private Mock<ICaracteristicaQuery> mockCaracteristicaQuery;
        private Mock<ICaracteristicaTransporteCommand> mockCaracteristicaTransporteCommand;
        private Mock<ICaracteristicaTransporteQuery> mockCaracteristicaTransporteQuery;

        public CaracteristicaTransporteRemove_Test()
        {
            mockTransporteQuery = new Mock<ITransporteQuery>();
            mockCaracteristicaQuery = new Mock<ICaracteristicaQuery>();
            mockCaracteristicaTransporteQuery = new Mock<ICaracteristicaTransporteQuery>();
            mockCaracteristicaTransporteCommand = new Mock<ICaracteristicaTransporteCommand>();
        }

        [Fact]
        public void CaracteristicaTransporteRemove_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Caracteristica Descripcion Test" };

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            var listaCaracteristicaTransporte = new List<CaracteristicaTransporte> { caracteristicaTransporte };

            mockCaracteristicaTransporteQuery.Setup(q => q.GetCaracteristicaTransporte()).Returns(listaCaracteristicaTransporte);
            mockCaracteristicaTransporteCommand.Setup(q => q.DeleteCaracteristicaTransporte(It.IsAny<int>())).Returns(caracteristicaTransporte);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            //Act
            var result = service.RemoveCaracteristicaTransporte(1);

            //Assert
            result.Id.Should().Be(caracteristicaTransporte.CaracteristicaTransporteId);
            result.CaracteristicaId.Should().Be(caracteristicaTransporte.CaracteristicaId);
            result.TransporteId.Should().Be(caracteristicaTransporte.TransporteId);
            result.valor.Should().Be(caracteristicaTransporte.Valor);
        }

        [Fact]
        public void CaracteristicaTransporteRemove_ShouldThrowExceptionIfCaracTransporteIsNull()
        {
            var listaCaracteristicaTransporte = new List<CaracteristicaTransporte>();
            mockCaracteristicaTransporteQuery.Setup(q => q.GetCaracteristicaTransporte()).Returns(listaCaracteristicaTransporte);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.RemoveCaracteristicaTransporte(1));
        }
    }
}
