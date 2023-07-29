using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Interfaces.ITransporte;
using Application.Responses;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.CaracteristicaTransporteTest
{
    public class CaracteristicaTransporteGet_Test
    {
        private Mock<ITransporteQuery> mockTransporteQuery;
        private Mock<ICaracteristicaQuery> mockCaracteristicaQuery;
        private Mock<ICaracteristicaTransporteCommand> mockCaracteristicaTransporteCommand;
        private Mock<ICaracteristicaTransporteQuery> mockCaracteristicaTransporteQuery;

        public CaracteristicaTransporteGet_Test()
        {
            mockTransporteQuery = new Mock<ITransporteQuery>();
            mockCaracteristicaQuery = new Mock<ICaracteristicaQuery>();
            mockCaracteristicaTransporteQuery = new Mock<ICaracteristicaTransporteQuery>();
            mockCaracteristicaTransporteCommand = new Mock<ICaracteristicaTransporteCommand>();
        }

        [Fact]
        public void GetCaracteristicaTransporteById_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "1234", RazonSocial = "RazonSocial S.A", ImagenLogo = "Test Imagen" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Auto" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Marca" };

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            mockCaracteristicaTransporteQuery.Setup(q => q.GetCaracteristicaTransporteById(It.IsAny<int>())).Returns(caracteristicaTransporte);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            var result = service.GetCaracteristicaTransportebyId(1);

            result.Id.Should().Be(caracteristicaTransporte.CaracteristicaTransporteId);
            result.CaracteristicaId.Should().Be(caracteristicaTransporte.CaracteristicaId);
            result.TransporteId.Should().Be(caracteristicaTransporte.TransporteId);
            result.valor.Should().Be(caracteristicaTransporte.Valor);
        }

        [Fact]
        public void GetCaracteristicaTransporteById_ShouldThrowExceptionIfCaracTransporteIsNull()
        {
            //Arrange
            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.GetCaracteristicaTransportebyId(1));
        }

        [Fact]
        public void GetAllCaracteristicaTransporte_ShouldReturnCorrectResponseWithOutFilters()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "1234", RazonSocial = "RazonSocial S.A", ImagenLogo = "Test Imagen" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Auto" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Marca" };

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            List<CaracteristicaTransporteResponse> listaCaracTransporteResponse = new List<CaracteristicaTransporteResponse>();
            var listaCaracteristicaTransporteExistentes = new List<CaracteristicaTransporte> { caracteristicaTransporte };

            foreach (var ct in listaCaracteristicaTransporteExistentes)
            {
                var CTResponse = new CaracteristicaTransporteResponse
                {
                    
                    Id = ct.CaracteristicaTransporteId,
                    CaracteristicaId = ct.CaracteristicaId,
                    TransporteId = ct.TransporteId,
                    valor = ct.Valor
                };

                listaCaracTransporteResponse.Add(CTResponse);
            }

            mockCaracteristicaTransporteQuery.Setup(q => q.GetAllCaracteristicaTransporte(null,null)).Returns(listaCaracteristicaTransporteExistentes);

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);


            //Act
            var result = service.GetAllCaracteristicaTransporte(null,null);

            //Assert
            result.Should().BeEquivalentTo(listaCaracTransporteResponse);
        }

        [Fact]
        public void GetAllCaracteristicaTransporte_ShouldReturnCorrectResponseIfCaracteristicaDistintaNull()
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

            int idCaracteristicaTest = 2;

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            var caracteristicaTransporte2 = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 2,
                Caracteristica = caracteristica2,
                CaracteristicaId = caracteristica2.CaracteristicaId,
                Transporte = transporte2,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test3"
            };

            var caracteristicaTransporte3 = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 3,
                Caracteristica = caracteristica2,
                CaracteristicaId = caracteristica2.CaracteristicaId,
                Transporte = transporte2,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test3"
            };

            List<CaracteristicaTransporteResponse> listaCaracTransporteResponse = new List<CaracteristicaTransporteResponse>();
            var listaCaracteristicaTransporteExistentes = new List<CaracteristicaTransporte> { caracteristicaTransporte, caracteristicaTransporte2, caracteristicaTransporte3 };

            mockCaracteristicaTransporteQuery.Setup(q => q.GetAllCaracteristicaTransporte(It.IsAny<int?>(), idCaracteristicaTest))
                .Returns((int? idTransporte, int? idCaracteristica) =>
                    listaCaracteristicaTransporteExistentes
                        .Where(ct => idCaracteristica == null || ct.CaracteristicaId == idCaracteristica)
                        .ToList());

            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);

            foreach (var ct in listaCaracteristicaTransporteExistentes)
            {
                if (ct.CaracteristicaId == idCaracteristicaTest)
                {
                    var CTResponse = new CaracteristicaTransporteResponse
                    {
                        Id = ct.CaracteristicaTransporteId,
                        CaracteristicaId = ct.CaracteristicaId,
                        TransporteId = ct.TransporteId,
                        valor = ct.Valor
                    };

                    listaCaracTransporteResponse.Add(CTResponse);
                }
            }
            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);


            //Act
            var result = service.GetAllCaracteristicaTransporte(null,idCaracteristicaTest);

            //Assert
            result.Should().BeEquivalentTo(listaCaracTransporteResponse);
        }

        [Fact]
        public void GetAllCaracteristicaTransporte_ShouldThrowExceptionIfCaracteristicaNoExiste()
        {
            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);
            
            var listaCaracteristica = new List<Caracteristica>();
            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);

            Assert.Throws<ValorBadRequestException>(() => service.GetAllCaracteristicaTransporte(1, 1));
        }

        [Fact]
        public void GetAllCaracteristicaTransporte_ShouldReturnCorrectResponseIfTransporteDistintoNull()
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

            int idTransporteTest = 1;

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            var caracteristicaTransporte2 = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 2,
                Caracteristica = caracteristica2,
                CaracteristicaId = caracteristica2.CaracteristicaId,
                Transporte = transporte2,
                TransporteId = transporte2.TransporteId,
                Valor = "Valor Test2"
            };

            var caracteristicaTransporte3 = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 3,
                Caracteristica = caracteristica2,
                CaracteristicaId = caracteristica2.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test3"
            };

            List<CaracteristicaTransporteResponse> listaCaracTransporteResponse = new List<CaracteristicaTransporteResponse>();
            var listaCaracteristicaTransporteExistentes = new List<CaracteristicaTransporte> { caracteristicaTransporte, caracteristicaTransporte2, caracteristicaTransporte3 };

            mockCaracteristicaTransporteQuery.Setup(q => q.GetAllCaracteristicaTransporte(idTransporteTest, It.IsAny<int?>()))
                .Returns((int? idTransporte, int? idCaracteristica) =>
                    listaCaracteristicaTransporteExistentes
                        .Where(ct => idTransporte == null || ct.TransporteId == idTransporte)
                        .ToList());

            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);
            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporte);

            foreach (var ct in listaCaracteristicaTransporteExistentes)
            {
                if (ct.TransporteId == idTransporteTest)
                {
                    var CTResponse = new CaracteristicaTransporteResponse
                    {
                        Id = ct.CaracteristicaTransporteId,
                        CaracteristicaId = ct.CaracteristicaId,
                        TransporteId = ct.TransporteId,
                        valor = ct.Valor
                    };

                    listaCaracTransporteResponse.Add(CTResponse);
                }
            }
            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);


            //Act
            var result = service.GetAllCaracteristicaTransporte(idTransporteTest, null);

            //Assert
            result.Should().BeEquivalentTo(listaCaracTransporteResponse);
        }

        [Fact]
        public void GetAllCaracteristicaTransporte_ShouldThrowExceptionIfTransporteNoExiste()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "1234", RazonSocial = "RazonSocial S.A", ImagenLogo = "Test Imagen" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Auto" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            var caracteristica = new Caracteristica { CaracteristicaId = 1, Descripcion = "Marca" };

            var listaCaracteristica = new List<Caracteristica> { caracteristica };
            var listaTransporte = new List<Transporte>();

            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);

            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);
            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporte);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.GetAllCaracteristicaTransporte(1, 1));
        }

        [Fact]
        public void GetAllCaracteristicaTransporte_ShouldReturnCorrectResponseWithFilters()
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

            int idTransporteTest = 1;
            int idCaracteristicaTest = 2;

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 1,
                Caracteristica = caracteristica,
                CaracteristicaId = caracteristica.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test"
            };

            var caracteristicaTransporte2 = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 2,
                Caracteristica = caracteristica2,
                CaracteristicaId = caracteristica2.CaracteristicaId,
                Transporte = transporte2,
                TransporteId = transporte2.TransporteId,
                Valor = "Valor Test2"
            };

            var caracteristicaTransporte3 = new CaracteristicaTransporte
            {
                CaracteristicaTransporteId = 3,
                Caracteristica = caracteristica2,
                CaracteristicaId = caracteristica2.CaracteristicaId,
                Transporte = transporte,
                TransporteId = transporte.TransporteId,
                Valor = "Valor Test3"
            };

            List<CaracteristicaTransporteResponse> listaCaracTransporteResponse = new List<CaracteristicaTransporteResponse>();
            var listaCaracteristicaTransporteExistentes = new List<CaracteristicaTransporte> { caracteristicaTransporte, caracteristicaTransporte2, caracteristicaTransporte3 };

            mockCaracteristicaTransporteQuery.Setup(q => q.GetAllCaracteristicaTransporte(idTransporteTest, idCaracteristicaTest))
                .Returns((int? idTransporte, int? idCaracteristica) =>
                    listaCaracteristicaTransporteExistentes
                        .Where(ct => (idTransporte == null || ct.TransporteId == idTransporte) && (idCaracteristica == null || ct.CaracteristicaId == idCaracteristica))
                        .ToList());

            mockCaracteristicaQuery.Setup(q => q.GetAllCaracteristicas()).Returns(listaCaracteristica);
            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporte);

            foreach (var ct in listaCaracteristicaTransporteExistentes)
            {
                if (ct.TransporteId == idTransporteTest && ct.CaracteristicaId == idCaracteristicaTest)
                {
                    var CTResponse = new CaracteristicaTransporteResponse
                    {
                        Id = ct.CaracteristicaTransporteId,
                        CaracteristicaId = ct.CaracteristicaId,
                        TransporteId = ct.TransporteId,
                        valor = ct.Valor
                    };

                    listaCaracTransporteResponse.Add(CTResponse);
                }
            }
            var service = new CaracteristicaTransporteService(mockCaracteristicaTransporteCommand.Object, mockCaracteristicaTransporteQuery.Object, mockCaracteristicaQuery.Object, mockTransporteQuery.Object);


            //Act
            var result = service.GetAllCaracteristicaTransporte(idTransporteTest, idCaracteristicaTest);

            //Assert
            result.Should().BeEquivalentTo(listaCaracTransporteResponse);
        }
    }
}
