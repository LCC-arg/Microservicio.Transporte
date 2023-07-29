using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi.CompaniaTransporteTest
{
    public class CompaniaTransporteRemove_Test
    {
        private Mock<ICompaniaTransporteCommand> mockCompaniaTransporteCommand;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;

        public CompaniaTransporteRemove_Test()
        {
            mockCompaniaTransporteCommand = new Mock<ICompaniaTransporteCommand>();
            mockCompaniaTransporteQuery = new Mock<ICompaniaTransporteQuery>();
        }

        [Fact]
        public void RemoveCompaniaTransporte_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte
            {
                CompaniaTransporteId = 1,
                Cuit = "Test cuit",
                RazonSocial = "Test Razon Social",
                ImagenLogo = "Test Imagen"
            };

            var listaCompaniasExistentes = new List<CompaniaTransporte> { compania };

            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);
            mockCompaniaTransporteCommand.Setup(q => q.DeleteCompaniaTransporte(It.IsAny<int>())).Returns(compania);


            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            // Act
            var result = service.RemoveCompaniaTransporte(1);

            //Assert
            result.Id.Should().Be(compania.CompaniaTransporteId);
            result.Cuit.Should().Be(compania.Cuit);
            result.RazonSocial.Should().Be(compania.RazonSocial);
            result.Imagen.Should().Be(compania.ImagenLogo);
        }


        [Fact]
        public void RemoveCompaniaTransporte_ShouldThrowExceptionifCompaniaisNull()
        {
            //Arrange
            var listaCompaniasExistentes = new List<CompaniaTransporte>();
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            // Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.RemoveCompaniaTransporte(1));
        }
    }
}
