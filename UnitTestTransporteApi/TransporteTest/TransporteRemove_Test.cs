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
    public class TransporteRemove_Test
    {
        private Mock<ITransporteCommand> mockTransporteCommand;
        private Mock<ITransporteQuery> mockTransporteQuery;
        private Mock<ITipoTransporteQuery> mockTipoTransporteQuery;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;

        public TransporteRemove_Test()
        {
            mockTransporteCommand = new Mock<ITransporteCommand>();
            mockTransporteQuery = new Mock<ITransporteQuery>();
            mockTipoTransporteQuery = new Mock<ITipoTransporteQuery>();
            mockCompaniaTransporteQuery = new Mock<ICompaniaTransporteQuery>();
        }

        [Fact]
        public void TransporteRemove_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };
            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };

            var listaTransporteExistentes = new List<Transporte> { transporte };

            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporteExistentes);
            mockTransporteCommand.Setup(q => q.DeleteTransporte(It.IsAny<int>())).Returns(transporte);

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act
            var result = service.RemoveTransporte(1);

            //Assert
            result.Id.Should().Be(transporte.TransporteId);
            result.CompaniaTransporteId.Should().Be(transporte.CompaniaTransporteId);
            result.TipoTransporteId.Should().Be(transporte.TipoTransporteId);
        }

        [Fact]
        public void TransporteRemove_ShouldThrowExceptionifTransporteIsNull()
        {
            //Arrange
            var listaTransporteExistentes = new List<Transporte>();
            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporteExistentes);
            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(()  => service.RemoveTransporte(1));
        }
    }
}