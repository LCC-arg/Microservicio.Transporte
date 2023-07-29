using Application.Exceptions;
using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.TipoTransporteTest
{
    public class TipoTransporteUpdate_Test
    {
        private Mock<ITipoTransporteCommand> mockTipoTransporteCommand;
        private Mock<ITipoTransporteQuery> mockTipoTransporteQuery;


        public TipoTransporteUpdate_Test()
        {
            mockTipoTransporteCommand = new Mock<ITipoTransporteCommand>();
            mockTipoTransporteQuery = new Mock<ITipoTransporteQuery>();
        }

        [Fact]
        public void UpdateTipoTransporte_ShouldReturnCorrectResponse()
        {
            //Arrange
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };

            var tipoTransporteRequest = new TipoTransporteRequest { Descripcion = "Request Test Descripcion" };

            var listaTipoTransporteExistentes = new List<TipoTransporte> { tipoTransporte };

            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);
            mockTipoTransporteCommand.Setup(q => q.ActualizeTipoTransporte(It.IsAny<int>(), It.IsAny<TipoTransporteRequest>()))
            .Returns((int id, TipoTransporteRequest request) =>
            {
                tipoTransporte.TipoTransporteId = id;
                tipoTransporte.Descripcion = request.Descripcion;

                return tipoTransporte;
            });

            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            // Act
            var result = service.UpdateTipoTransporte(1, tipoTransporteRequest);

            //Assert
            result.Id.Should().Be(tipoTransporte.TipoTransporteId);
            result.Descripcion.Should().Be(tipoTransporteRequest.Descripcion);
            
        }

        [Fact]
        public void UpdateTipoTransporte_ShouldShouldThrowExceptionifTipoisNull()
        {
            //Arrange
            var tipoTransporteRequest = new TipoTransporteRequest { Descripcion = "Request Test Descripcion" };
            var listaTipoTransporteExistentes = new List<TipoTransporte>();
            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);

            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            // Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateTipoTransporte(1, tipoTransporteRequest));
        }

        [Fact]
        public void UpdateTipoTransporte_ShouldShouldThrowExceptionifDescripcionExists()
        {
            var listaTipoTransporteExistentes = new List<TipoTransporte>
            {
                new TipoTransporte
                {
                    TipoTransporteId = 1,
                    Descripcion = "Tipo Transporte Descripcion Test"
                }
            };
            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);

            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            var tipoTransporteRequest = new TipoTransporteRequest { Descripcion = "Tipo Transporte Descripcion Test" };

            // Act & Assert
            Assert.Throws<ValorConflictException>(() => service.UpdateTipoTransporte(1, tipoTransporteRequest));
        }
    }
}
