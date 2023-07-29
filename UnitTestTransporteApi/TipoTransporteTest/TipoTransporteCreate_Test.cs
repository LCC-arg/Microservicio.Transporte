using Application.Exceptions;
using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.TipoTransporteTest
{
    public class TipoTransporteCreate_Test
    {
        private Mock<ITipoTransporteCommand> mockTipoTransporteCommand;
        private Mock<ITipoTransporteQuery> mockTipoTransporteQuery;


        public TipoTransporteCreate_Test()
        {
            mockTipoTransporteCommand = new Mock<ITipoTransporteCommand>();
            mockTipoTransporteQuery = new Mock<ITipoTransporteQuery>();
        }

        [Fact]
        public void CreateTipoTransporte_ShouldReturnCorrectResponse()
        {
            //Arrange
            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(new List<TipoTransporte>());
            var tipoTransporteRequest = new TipoTransporteRequest
            {
                Descripcion = " Tipo Transporte Descripcion Test"
            };
            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);
            
            //Act
            var result = service.CreateTipoTransporte(tipoTransporteRequest);

            //Asserts
            result.Descripcion.Should().Be(tipoTransporteRequest.Descripcion);
        }

        [Fact]
        public void CreateCompaniaTransporte_IfDescripcionExists()
        {
            var listaTipoTransporteExistentes = new List<TipoTransporte>
            {
                new TipoTransporte
                {
                    Descripcion = "Tipo Transporte Descripcion Test"
                }
            };
            mockTipoTransporteQuery.Setup(q => q.GetAllTipoTransporte()).Returns(listaTipoTransporteExistentes);

            var service = new TipoTransporteService(mockTipoTransporteCommand.Object, mockTipoTransporteQuery.Object);

            var Request = new TipoTransporteRequest
            {
                Descripcion = "Tipo Transporte Descripcion Test"
            };

            // Act & Assert
            Assert.Throws<ValorConflictException>(() => service.CreateTipoTransporte(Request));
        }
    }
    
}
