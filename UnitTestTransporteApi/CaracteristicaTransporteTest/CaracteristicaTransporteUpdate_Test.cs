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
    public class CaracteristicaTransporteUpdate_Test
    {
        private Mock<ITransporteQuery> mockTransporteQuery;
        private Mock<ICaracteristicaQuery> mockCaracteristicaQuery;
        private Mock<ICaracteristicaTransporteCommand> mockCaracteristicaTransporteCommand;
        private Mock<ICaracteristicaTransporteQuery> mockCaracteristicaTransporteQuery;

        public CaracteristicaTransporteUpdate_Test()
        {
            mockTransporteQuery = new Mock<ITransporteQuery>();
            mockCaracteristicaQuery = new Mock<ICaracteristicaQuery>();
            mockCaracteristicaTransporteQuery = new Mock<ICaracteristicaTransporteQuery>();
            mockCaracteristicaTransporteCommand = new Mock<ICaracteristicaTransporteCommand>();
        }

        [Fact]
        public void CaracteristicaTransporteUpdate_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var compania2 = new CompaniaTransporte { CompaniaTransporteId = 2, Cuit = "Test cuit2", RazonSocial = "Test Razon Social2", ImagenLogo = "Test Imagen2" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };
            var tipoTransporte2 = new TipoTransporte { TipoTransporteId = 2, Descripcion = "Tipo Transporte Descripcion Test2" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            var transporte2 = new Transporte { TransporteId = 2, TipoTransporte = tipoTransporte2, TipoTransporteId = 2, CompaniaTransporte = compania2, CompaniaTransporteId = 2 };
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Caracteristica Descripcion Test" };
            var caracteristica2 = new Caracteristica { CaracteristicaId = 2, Descripcion = "Caracteristica Descripcion Test2" };
            var listaCaracteristica = new List<Caracteristica> { caracteristica, caracteristica2 };
            var listaTransporte = new List<Transporte> { transporte, transporte2 };
;

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            var caracteristicaTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 2, TransporteId = 2, Valor = "Valor Test2" };

            var listaCaracteristicaTransporte = new List<CaracteristicaTransporte> { caracteristicaTransporte };

            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporte);
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);
            mockCaracteristicaTransporteQuery.Setup(q => q.GetCaracteristicaTransporte()).Returns(listaCaracteristicaTransporte);
            mockCaracteristicaTransporteCommand.Setup(q => q.ActualizeCaracteristicaTransporte(It.IsAny<int>(), It.IsAny<CaracteristicaTransporteRequest>()))
                .Returns((int id, CaracteristicaTransporteRequest request) => 
                {
                    caracteristicaTransporte.CaracteristicaId = request.CaracteristicaId;
                    caracteristicaTransporte.TransporteId = request.TransporteId;
                    caracteristicaTransporte.Valor = request.Valor;

                    return caracteristicaTransporte;
                });

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            //Act
            var result = service.UpdateCaracteristicaTransporte(1,caracteristicaTransporteRequest);

            //Assert
            result.Id.Should().Be(caracteristicaTransporte.CaracteristicaTransporteId);
            result.CaracteristicaId.Should().Be(caracteristicaTransporteRequest.CaracteristicaId);
            result.TransporteId.Should().Be(caracteristicaTransporteRequest.TransporteId);
            result.valor.Should().Be(caracteristicaTransporteRequest.Valor);
        }

        [Fact]
        public void CaracteristicaTransporteUpdate_ShouldThrowExceptionIfCaracTransporteIsNull()
        {
            var caracteristicaTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 2, TransporteId = 2, Valor = "Valor Test2" };

            var listaCaracteristicaTransporte = new List<CaracteristicaTransporte>();

            mockCaracteristicaTransporteQuery.Setup(q => q.GetCaracteristicaTransporte()).Returns(listaCaracteristicaTransporte);
            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            Assert.Throws<ValorBadRequestException>(() => service.UpdateCaracteristicaTransporte(1, caracteristicaTransporteRequest));
        }

        [Fact]
        public void CaracteristicaTransporteUpdate_ShouldThrowExceptionIfCaracteristicaIsNull()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var compania2 = new CompaniaTransporte { CompaniaTransporteId = 2, Cuit = "Test cuit2", RazonSocial = "Test Razon Social2", ImagenLogo = "Test Imagen2" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };
            var tipoTransporte2 = new TipoTransporte { TipoTransporteId = 2, Descripcion = "Tipo Transporte Descripcion Test2" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            var transporte2 = new Transporte { TransporteId = 2, TipoTransporte = tipoTransporte2, TipoTransporteId = 2, CompaniaTransporte = compania2, CompaniaTransporteId = 2 };
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Caracteristica Descripcion Test" };
            var caracteristica2 = new Caracteristica { CaracteristicaId = 2, Descripcion = "Caracteristica Descripcion Test2" };
            var listaTransporte = new List<Transporte> { transporte, transporte2 };

            var listaCaracteristica = new List<Caracteristica> { caracteristica };


            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            var caracteristicaTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 2, TransporteId = 2, Valor = "Valor Test2" };

            var listaCaracteristicaTransporte = new List<CaracteristicaTransporte> { caracteristicaTransporte};

            mockCaracteristicaTransporteQuery.Setup(q => q.GetCaracteristicaTransporte()).Returns(listaCaracteristicaTransporte);
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateCaracteristicaTransporte(1, caracteristicaTransporteRequest));

        }

        [Fact]
        public void CaracteristicaTransporteUpdate_ShouldThrowExceptionIfTransporteIsNull()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var compania2 = new CompaniaTransporte { CompaniaTransporteId = 2, Cuit = "Test cuit2", RazonSocial = "Test Razon Social2", ImagenLogo = "Test Imagen2" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Descripcion Test" };
            var tipoTransporte2 = new TipoTransporte { TipoTransporteId = 2, Descripcion = "Descripcion Test2" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Descripcion Test" };
            var caracteristica2 = new Caracteristica { CaracteristicaId = 2, Descripcion = "Descripcion Test2" };

            var listaCaracteristica = new List<Caracteristica> { caracteristica, caracteristica2 };
            var listaTransporte = new List<Transporte> { transporte};

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            var caracteristicaTransporteRequest = new CaracteristicaTransporteRequest { CaracteristicaId = 2, TransporteId = 2, Valor = "Valor Test2" };

            var listaCaracteristicaTransporte = new List<CaracteristicaTransporte> { caracteristicaTransporte };

            mockCaracteristicaTransporteQuery.Setup(q => q.GetCaracteristicaTransporte()).Returns(listaCaracteristicaTransporte);
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);
            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporte);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateCaracteristicaTransporte(1, caracteristicaTransporteRequest));

        }
    }
}
