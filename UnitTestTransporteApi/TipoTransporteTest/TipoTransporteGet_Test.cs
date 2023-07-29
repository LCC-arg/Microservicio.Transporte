using Application.Exceptions;
using Application.Interfaces.ITipoTransporte;
using Application.Responses;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.TipoTransporteTest
{
    public class TipoTransporteGet_Test
    {
        private Mock<ITipoTransporteCommand> mockTipoTransporteCommand;
        private Mock<ITipoTransporteQuery> mockTipoTransporteQuery;


        public TipoTransporteGet_Test()
        {
            mockTipoTransporteCommand = new Mock<ITipoTransporteCommand>();
            mockTipoTransporteQuery = new Mock<ITipoTransporteQuery>();
        }

        [Fact]
        public void GetTipoTransporteById_ShouldReturnCorrectResponse()
        {
            //Arrange
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" };

            mockTipoTransporteQuery.Setup(q => q.GetTipoTransporteById(It.IsAny<int>())).Returns(tipoTransporte);

            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            //Act
            var result = service.GetTipoTransportebyId(1);

            //Assert
            result.Id.Should().Be(tipoTransporte.TipoTransporteId);
            result.Descripcion.Should().Be(tipoTransporte.Descripcion);
        }

        [Fact]
        public void GetTipoTransporteById_ShouldThrowExceptionifTipoTransporteisNull()
        {
            //Arrange
            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.GetTipoTransportebyId(1));
        }

        [Fact]
        public void GetAllTipoTransporte_ShouldReturnCorrectResponse()
        {
            //Arrange
            List<TipoTransporteResponse> listaTipoTransporteResponse = new List<TipoTransporteResponse>();
            var listaTipoTransporteExistentes = new List<TipoTransporte>
            {
                new TipoTransporte { TipoTransporteId = 1, Descripcion = "Tipo Transporte Descripcion Test" }
            };

            foreach (var tipo in listaTipoTransporteExistentes)
            {
                var tipoTransporteResponse = new TipoTransporteResponse
                {
                    Id = tipo.TipoTransporteId,
                    Descripcion = tipo.Descripcion,
                };
                listaTipoTransporteResponse.Add(tipoTransporteResponse);
            }

            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);

            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            //Act
            var result = service.GetAllTipoTransporte();

            //Assert
            result.Should().BeEquivalentTo(listaTipoTransporteResponse);
        }
    }
}
