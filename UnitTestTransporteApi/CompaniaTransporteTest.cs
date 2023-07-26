using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Request;
using Application.Responses;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;

namespace UnitTestTransporteApi
{
    public class CompaniaTransporteTest
    {

        private Mock<ICompaniaTransporteCommand> mockCompaniaTransporteCommand;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;
        

        public CompaniaTransporteTest()
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

            foreach(var ct in listaCompaniasExistentes)
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

            var listaCompaniasExistentes = new List<CompaniaTransporte>{compania};

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
            var result = service.UpdateCompaniaTransporte(1,companiaRequest);

            //Assert
            result.Id.Should().Be(compania.CompaniaTransporteId);
            result.Cuit.Should().Be(companiaRequest.Cuit);
            result.RazonSocial.Should().Be(companiaRequest.RazonSocial);
            result.Imagen.Should().Be(companiaRequest.Imagen);
        }

        [Fact]
        public void UpdateCompaniaTransporte_ShouldShouldThrowExceptionifCompaniaisNull()
        {
            //Arrange
            var companiaRequest = new CompaniaTransporteRequest { Cuit = "123456", Imagen = "Imagen", RazonSocial = "Razon Social" };
            var listaCompaniasExistentes = new List<CompaniaTransporte>();
            mockCompaniaTransporteQuery.Setup(q => q.GetAllCompaniaTransporte()).Returns(listaCompaniasExistentes);

            var service = new CompaniaTransporteService(mockCompaniaTransporteCommand.Object, mockCompaniaTransporteQuery.Object);

            // Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.UpdateCompaniaTransporte(1,companiaRequest));
        }

        [Fact]
        public void UpdateCompaniaTransporte_ShouldShouldThrowExceptionifRazonSocialExists()
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
            Assert.Throws<ValorConflictException>(() => service.UpdateCompaniaTransporte(1,companiaRequest));
        }

        [Fact]
        public void UpdateCompaniaTransporte_ShouldShouldThrowExceptionifCuitExists()
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
