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
    public class TransporteCreate_Test
    {
        private Mock<ITransporteCommand> mockTransporteCommand;
        private Mock<ITransporteQuery> mockTransporteQuery;
        private Mock<ITipoTransporteQuery> mockTipoTransporteQuery;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;

        public TransporteCreate_Test()
        {
            mockTransporteCommand = new Mock<ITransporteCommand>();
            mockTransporteQuery = new Mock<ITransporteQuery>();
            mockTipoTransporteQuery = new Mock<ITipoTransporteQuery>();
            mockCompaniaTransporteQuery = new Mock<ICompaniaTransporteQuery>();
        }

        [Fact]
        public void TransporteCreate_ShouldReturnCorrectResponse()
        {
            //Arrange
            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };

            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen"};
            var listaCompaniasExistentes = new List<CompaniaTransporte> { compania };

            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };
            var listaTipoTransporteExistentes = new List<TipoTransporte> { tipoTransporte };

            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);
            
            //Act
            var result = service.CreateTransporte(transporteRequest);

            //Assert
            result.TipoTransporteId.Should().Be(transporteRequest.TipoTransporteId);
            result.CompaniaTransporteId.Should().Be(transporteRequest.CompaniaTransporteId);
        }

        [Fact]
        public void TransporteCreate_ShouldThrowExceptionIfTipoIsNull()
        {
            //Arrange
            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };

            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var listaCompaniasExistentes = new List<CompaniaTransporte> { compania };

            var listaTipoTransporteExistentes = new List<TipoTransporte>();

            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.CreateTransporte(transporteRequest));
        }

        [Fact]
        public void TransporteCreate_ShouldThrowExceptionIfCompaniaIsNull()
        {
            //Arrange
            var transporteRequest = new TransporteRequest { CompaniaTransporteId = 1, TipoTransporteId = 1 };
            var listaCompaniasExistentes = new List<CompaniaTransporte>();

            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };
            var listaTipoTransporteExistentes = new List<TipoTransporte> { tipoTransporte };

            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.CreateTransporte(transporteRequest));
        }
    }
}
