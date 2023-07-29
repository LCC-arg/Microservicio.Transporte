using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Request;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTransporteApi.CompaniaTransporteTest
{
    public class CompaniaTransporteCreate_Test
    {
        private Mock<ICompaniaTransporteCommand> mockCompaniaTransporteCommand;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;

        public CompaniaTransporteCreate_Test()
        {
            mockCompaniaTransporteCommand = new Mock<ICompaniaTransporteCommand>();
            mockCompaniaTransporteQuery = new Mock<ICompaniaTransporteQuery>();
        }

        [Fact]
        public void CreateCompaniaTransporte_ShouldReturnCorrectResponse()
        {
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(new List<CompaniaTransporte>());


            var companiaRequest = new CompaniaTransporteRequest
            {
                Cuit = "Test cuit",
                RazonSocial = "Test Razon Social",
                Imagen = "Test Imagen"
            };
            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);
            //Act
            var result = service.CreateCompaniaTransporte(companiaRequest);

            //Asserts
            result.Cuit.Should().Be(companiaRequest.Cuit);
            result.RazonSocial.Should().Be(companiaRequest.RazonSocial);
            result.Imagen.Should().Be(companiaRequest.Imagen);
        }
        [Fact]
        public void CreateCompaniaTransporte_IfExistRazonSocial()
        {
            var listaCompaniasExistentes = new List<CompaniaTransporte>
            {
                new CompaniaTransporte
                {
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
            Assert.Throws<ValorConflictException>(() => service.CreateCompaniaTransporte(companiaRequest));
        }

        [Fact]
        public void CreateCompaniaTransporte_ShouldThrowExceptionWhenCuitExists()
        {
            // Arrange
            var listaCompaniasExistentesCuit = new List<CompaniaTransporte>
            {
                new CompaniaTransporte
                {
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
            Assert.Throws<ValorConflictException>(() => service.CreateCompaniaTransporte(companiaRequest));
        }
    }
}
