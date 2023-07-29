using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Request;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.CompaniaTransporteTest
{
    public class CompaniaTransporteUpdate_Test
    {
        private Mock<ICompaniaTransporteCommand> mockCompaniaTransporteCommand;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;


        public CompaniaTransporteUpdate_Test()
        {
            mockCompaniaTransporteCommand = new Mock<ICompaniaTransporteCommand>();
            mockCompaniaTransporteQuery = new Mock<ICompaniaTransporteQuery>();
        }

        [Fact]
        public void UpdateCompaniaTransporte_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte
            {
                CompaniaTransporteId = 1,
                Cuit = "Test cuit",
                RazonSocial = "Test Razon Social",
                ImagenLogo = "Test Imagen"
            };

            var companiaRequest = new CompaniaTransporteRequest { Cuit = "123456", Imagen = "Imagen", RazonSocial = "Razon Social" };

            var listaCompaniasExistentes = new List<CompaniaTransporte> { compania };

            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);
            mockCompaniaTransporteCommand.Setup(q => q.ActualizeCompaniaTransporte(It.IsAny<int>(), It.IsAny<CompaniaTransporteRequest>()))
            .Returns((int id, CompaniaTransporteRequest request) =>
            {
                compania.CompaniaTransporteId = id;
                compania.Cuit = request.Cuit;
                compania.RazonSocial = request.RazonSocial;
                compania.ImagenLogo = request.Imagen;

                return compania;
            });

            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            // Act
            var result = service.UpdateCompaniaTransporte(1, companiaRequest);

            //Assert
            result.Id.Should().Be(compania.CompaniaTransporteId);
            result.Cuit.Should().Be(companiaRequest.Cuit);
            result.RazonSocial.Should().Be(companiaRequest.RazonSocial);
            result.Imagen.Should().Be(companiaRequest.Imagen);
        }

        [Fact]
        public void UpdateCompaniaTransporte_ShouldThrowExceptionifCompaniaisNull()
        {
            //Arrange
            var companiaRequest = new CompaniaTransporteRequest { Cuit = "123456", Imagen = "Imagen", RazonSocial = "Razon Social" };
            var listaCompaniasExistentes = new List<CompaniaTransporte>();
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            // Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateCompaniaTransporte(1, companiaRequest));
        }

        [Fact]
        public void UpdateCompaniaTransporte_ShouldThrowExceptionifRazonSocialExists()
        {
            var listaCompaniasExistentes = new List<CompaniaTransporte>
            {
                new CompaniaTransporte
                {
                    CompaniaTransporteId = 1,
                    RazonSocial = "Test Razon Social"
                }
            };
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            var companiaRequest = new CompaniaTransporteRequest
            {
                Cuit = "Test cuit",
                RazonSocial = "Test Razon Social",
                Imagen = "Test Imagen"
            };

            // Act & Assert
            Assert.Throws<ValorConflictException>(() => service.UpdateCompaniaTransporte(1, companiaRequest));
        }

        [Fact]
        public void UpdateCompaniaTransporte_ShouldThrowExceptionifCuitExists()
        {
            // Arrange
            var listaCompaniasExistentesCuit = new List<CompaniaTransporte>
            {
                new CompaniaTransporte
                {
                    CompaniaTransporteId = 1,
                    RazonSocial = "Razon social",
                    Cuit ="123"
                }
            };
            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentesCuit);

            var companiaRequest = new CompaniaTransporteRequest
            {
                Cuit = "123",
                RazonSocial = "Test Razon Social",
                Imagen = "Test Imagen"
            };

            // Act & Assert
            Assert.Throws<ValorConflictException>(() => service.UpdateCompaniaTransporte(1, companiaRequest));
        }
    }
}
