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
    public class CaracteristicaTransporteCreate_Test
    {
        private Mock<ITransporteQuery> mockTransporteQuery;
        private Mock<ICaracteristicaQuery> mockCaracteristicaQuery;
        private Mock<ICaracteristicaTransporteCommand> mockCaracteristicaTransporteCommand;
        private Mock<ICaracteristicaTransporteQuery> mockCaracteristicaTransporteQuery;

        public CaracteristicaTransporteCreate_Test()
        {
            mockTransporteQuery = new Mock<ITransporteQuery>();
            mockCaracteristicaQuery = new Mock<ICaracteristicaQuery>();
            mockCaracteristicaTransporteQuery = new Mock<ICaracteristicaTransporteQuery>();
            mockCaracteristicaTransporteCommand = new Mock<ICaracteristicaTransporteCommand>();
        }

        [Fact]
        public void CaracteristicaTransporteCreate_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "1234", RazonSocial = "RazonSocial S.A", ImagenLogo = "Test Imagen" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Auto" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Marca" };
            var listaTransporteExistentes = new List<Transporte> { transporte };
            var listaCaracteristicaExistentes = new List<Caracteristica> { caracteristica };

            var caracteristicaTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 1, TransporteId = 1, Valor = "Valor Test" };

            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporteExistentes);
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristicaExistentes);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            //Act
            var result = service.CreateCaracteristicaTransporte(caracteristicaTransporteRequest);

            //Assert
            result.TransporteId.Should().Be(caracteristicaTransporteRequest.TransporteId);
            result.CaracteristicaId.Should().Be(caracteristicaTransporteRequest.CaracteristicaId);
            result.valor.Should().Be(caracteristicaTransporteRequest.Valor);
        }

        [Fact]
        public void CaracteristicaTransporteCreate_ShouldThrowExceptionifCaracteristicaIsNull()
        {
            //Arrange
            var listaCaracteristicaExistentes = new List<Caracteristica>();
            var caracteristicaTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 1, TransporteId = 1, Valor = "Valor Test" };

            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristicaExistentes);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.CreateCaracteristicaTransporte(caracteristicaTransporteRequest));
        }

        [Fact]
        public void CaracteristicaTransporteCreate_ShouldThrowExceptionifTransporteIsNull()
        {
            //Arrange
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Marca" };
            var listaTransporteExistentes = new List<Transporte>();
            var listaCaracteristicaExistentes = new List<Caracteristica> { caracteristica };

            var caracteristicaTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 1, TransporteId = 1, Valor = "Valor Test" };

            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporteExistentes);
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristicaExistentes);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);
            
            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.CreateCaracteristicaTransporte(caracteristicaTransporteRequest));
        }
    }
}
