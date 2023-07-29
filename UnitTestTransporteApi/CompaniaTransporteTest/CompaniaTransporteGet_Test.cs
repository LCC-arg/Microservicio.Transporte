using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Responses;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.CompaniaTransporteTest
{
    public class CompaniaTransporteGet_Test
    {
        private Mock<ICompaniaTransporteCommand> mockCompaniaTransporteCommand;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;

        public CompaniaTransporteGet_Test()
        {
            mockCompaniaTransporteCommand = new Mock<ICompaniaTransporteCommand>();
            mockCompaniaTransporteQuery = new Mock<ICompaniaTransporteQuery>();
        }

        [Fact]
        public void GetCompaniaById_ShouldReturnCorrectResponse()
        {
            var compania = new CompaniaTransporte
            {
                CompaniaTransporteId = 1,
                Cuit = "Test cuit",
                RazonSocial = "Test Razon Social",
                ImagenLogo = "Test Imagen"
            };

            mockCompaniaTransporteQuery.Setup(q => q.GetCompaniaTransporteById(It.IsAny<int>())).Returns(compania);

            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            //Act
            var result = service.GetCompaniaTransportebyId(1);

            //Assert
            result.Id.Should().Be(compania.CompaniaTransporteId);
            result.Cuit.Should().Be(compania.Cuit);
            result.RazonSocial.Should().Be(compania.RazonSocial);
            result.Imagen.Should().Be(compania.ImagenLogo);
        }

        [Fact]
        public void GetCompaniaById_ShouldThrowExceptionifCompaniaisNull()
        {
            //Arrange
            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.GetCompaniaTransportebyId(1));
        }

        [Fact]
        public void GetAllCompaniaTransporte_ShouldReturnCorrectResponse()
        {
            //Arrange
            List<CompaniaTransporteResponse> listaCompaniaResponse = new List<CompaniaTransporteResponse>();
            var listaCompaniasExistentes = new List<CompaniaTransporte>
            {
                new CompaniaTransporte
                {
                    CompaniaTransporteId = 1,
                    RazonSocial = "Test Razon Social",
                    Cuit = "Test Cuit",
                    ImagenLogo = "Test Imagen"
                }
            };

            foreach (var ct in listaCompaniasExistentes)
            {
                var companiaTransporteResponse = new CompaniaTransporteResponse
                {
                    Cuit = ct.Cuit,
                    RazonSocial = ct.RazonSocial,
                    Id = ct.CompaniaTransporteId,
                    Imagen = ct.ImagenLogo
                };
                listaCompaniaResponse.Add(companiaTransporteResponse);
            }

            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            //Act
            var result = service.GetAllCompaniaTransporte();

            //Assert
            result.Should().BeEquivalentTo(listaCompaniaResponse);
        }
    }
}
