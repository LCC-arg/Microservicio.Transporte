using Application.Exceptions;
using Application.Interfaces.ITipoTransporte;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.TipoTransporteTest
{
    public class TipoTransporteRemove_Test
    {
        private Mock<ITipoTransporteCommand> mockTipoTransporteCommand;
        private Mock<ITipoTransporteQuery> mockTipoTransporteQuery;


        public TipoTransporteRemove_Test()
        {
            mockTipoTransporteCommand = new Mock<ITipoTransporteCommand>();
            mockTipoTransporteQuery = new Mock<ITipoTransporteQuery>();
        }

        [Fact]
        public void RemoveTipoTransporte_ShouldReturnCorrectResponse()
        {
            //Arrange
            var tipoTransporte = new TipoTransporte{ TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };

            var listaTipoTransporteExistentes = new List<TipoTransporte> { tipoTransporte };

            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);
            mockTipoTransporteCommand.Setup(q => q.DeleteTipoTransporte(It.IsAny<int>())).Returns(tipoTransporte);


            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            // Act
            var result = service.RemoveTipoTransporte(1);

            //Assert
            result.Id.Should().Be(tipoTransporte.TipoTransporteId);
            result.Descripcion.Should().Be(tipoTransporte.Descripcion);
        }

        [Fact]
        public void RemoveTipoTransporte_ShouldThrowExceptionifTipoisNull()
        {
            //Arrange
            var listaTipoTransporteExistentes = new List<TipoTransporte>();
            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);

            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            // Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.RemoveTipoTransporte(1));
        }
    }
}
