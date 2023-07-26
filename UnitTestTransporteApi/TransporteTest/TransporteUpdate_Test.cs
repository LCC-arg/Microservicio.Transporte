using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Interfaces.ITipoTransporte;
using Application.Interfaces.ITransporte;
using Application.Request;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.TransporteTest
{
    public class TransporteUpdate_Test
    {
        private Mock<ITransporteCommand> mockTransporteCommand;
        private Mock<ITransporteQuery> mockTransporteQuery;
        private Mock<ITipoTransporteQuery> mockTipoTransporteQuery;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;

        public TransporteUpdate_Test()
        {
            mockTransporteCommand = new Mock<ITransporteCommand>();
            mockTransporteQuery = new Mock<ITransporteQuery>();
            mockTipoTransporteQuery = new Mock<ITipoTransporteQuery>();
            mockCompaniaTransporteQuery = new Mock<ICompaniaTransporteQuery>();
        }

        [Fact]
        public void TransporteUpdate_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var listaCompaniasExistentes = new List<CompaniaTransporte> { compania };

            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Descripcion Test" };
            var listaTipoTransporteExistentes = new List<TipoTransporte> { tipoTransporte };

            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };

            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };
            
            mockTransporteQuery.Setup(q => q.GetTransporteById(It.IsAny<int>())).Returns(transporte);
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);
            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);


            mockTransporteCommand.Setup(q => q.ActualizeTransporte(It.IsAny<int>(), It.IsAny<TransporteRequest>()))
                .Returns((int id, TransporteRequest request) =>
                {
                    transporte.TransporteId = id;
                    transporte.TipoTransporteId = request.TipoTransporteId;
                    transporte.CompaniaTransporteId = request.CompaniaTransporteId;

                    return transporte;
                });

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            var result = service.UpdateTransporte(1, transporteRequest);

            result.Id.Should().Be(transporte.TransporteId);
            result.TipoTransporteId.Should().Be(transporteRequest.TipoTransporteId);
            result.CompaniaTransporteId.Should().Be(transporteRequest.CompaniaTransporteId);
        }

        [Fact]
        public void TransporteUpdate_ShouldThrowExceptionIfTransporteIsNull()
        {
            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };
            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateTransporte(1, transporteRequest));
        }

        [Fact]
        public void TransporteUpdate_ShouldThrowExceptionIfTipoIsNull()
        {
            //Arrange
            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };

            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var listaCompaniasExistentes = new List<CompaniaTransporte> { compania };

            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Descripcion Test" };
            var listaTipoTransporteExistentes = new List<TipoTransporte>();

            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };

            mockTransporteQuery.Setup(q => q.GetTransporteById(It.IsAny<int>())).Returns(transporte);

            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateTransporte(1, transporteRequest));
        }

        [Fact]
        public void TransporteUpdate_ShouldThrowExceptionIfCompaniaIsNull()
        {
            //Arrange
            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };
            var listaCompaniasExistentes = new List<CompaniaTransporte>();
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };

            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Descripcion Test" };

            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };

            mockTransporteQuery.Setup(q => q.GetTransporteById(It.IsAny<int>())).Returns(transporte);
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateTransporte(1, transporteRequest));
        }
    }
}
