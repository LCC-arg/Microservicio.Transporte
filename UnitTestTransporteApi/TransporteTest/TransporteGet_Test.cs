using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Interfaces.ITipoTransporte;
using Application.Interfaces.ITransporte;
using Application.Request;
using Application.Responses;
using Application.UseCase;
using Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTransporteApi.TransporteTest
{
    public class TransporteGet_Test
    {
        private Mock<ITransporteCommand> mockTransporteCommand;
        private Mock<ITransporteQuery> mockTransporteQuery;
        private Mock<ITipoTransporteQuery> mockTipoTransporteQuery;
        private Mock<ICompaniaTransporteQuery> mockCompaniaTransporteQuery;

        public TransporteGet_Test()
        {
            mockTransporteCommand = new Mock<ITransporteCommand>();
            mockTransporteQuery = new Mock<ITransporteQuery>();
            mockTipoTransporteQuery = new Mock<ITipoTransporteQuery>();
            mockCompaniaTransporteQuery = new Mock<ICompaniaTransporteQuery>();
        }

        [Fact]
        public void TransporteGetById_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Descripcion Test" };

            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };

            var listaTransportesExistentes = new List<Transporte> {transporte};

            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransportesExistentes);
            mockTransporteQuery.Setup(q => q.GetTransporteById(It.IsAny<int>())).Returns(transporte);

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act
            var result = service.GetTransportebyId(1);

            //Assert
            result.Id.Should().Be(transporte.TransporteId);
            result.CompaniaTransporteResponse.Id.Should().Be(transporte.CompaniaTransporteId);
            result.CompaniaTransporteResponse.RazonSocial.Should().Be(transporte.CompaniaTransporte.RazonSocial);
            result.CompaniaTransporteResponse.Cuit.Should().Be(transporte.CompaniaTransporte.Cuit);
            result.TipoTransporteResponse.Id.Should().Be(transporte.TipoTransporteId);
            result.TipoTransporteResponse.Descripcion.Should().Be(transporte.TipoTransporte.Descripcion);
        }

        [Fact]
        public void TransporteGetById_ShouldThrowExceptionIfTransporteIsNull()
        {
            //Arrange
            var listaTransportesExistentes = new List<Transporte>();

            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransportesExistentes);
            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act & Assert
            Assert.Throws<ValorBadRequestException>(() => service.GetTransportebyId(1));
        }

        [Fact]
        public void GetAllTransporte_ShouldReturnCorrectResponse()
        {
            //Arrange
            var compania = new CompaniaTransporte { CompaniaTransporteId = 1, Cuit = "Test cuit", RazonSocial = "Test Razon Social", ImagenLogo = "Test Imagen" };
            var tipoTransporte = new TipoTransporte { TipoTransporteId = 1, Descripcion = "Descripcion Test" };

            var transporte = new Transporte { TransporteId = 1, TipoTransporte = tipoTransporte, TipoTransporteId = 1, CompaniaTransporte = compania, CompaniaTransporteId = 1 };

            List<TransporteGetResponse> listaTransporteGetResponse = new List<TransporteGetResponse>();
            var listaTransporteExistentes = new List<Transporte> { transporte };

            foreach (var t in listaTransporteExistentes)
            {
                var transporteGetResponse = new TransporteGetResponse
                {
                    Id = t.TransporteId,
                    TipoTransporteResponse = new TipoTransporteResponse
                    {
                        Id = t.TipoTransporteId,
                        Descripcion = t.TipoTransporte.Descripcion
                    },
                    CompaniaTransporteResponse = new CompaniaTransporteResponse
                    {
                        Id = t.CompaniaTransporteId,
                        Cuit = t.CompaniaTransporte.Cuit,
                        RazonSocial = t.CompaniaTransporte.RazonSocial,
                        Imagen = t.CompaniaTransporte.ImagenLogo
                    }
                };
                listaTransporteGetResponse.Add(transporteGetResponse);
            }

            mockTransporteQuery.Setup(q => q.GetAllTransporte()).Returns(listaTransporteExistentes);

            var service = new TransporteService(mockTransporteCommand.Object, mockTransporteQuery.Object, mockTipoTransporteQuery.Object, mockCompaniaTransporteQuery.Object);

            //Act
            var result = service.GetAllTransporte();

            //Assert
            result.Should().BeEquivalentTo(listaTransporteGetResponse);
        }
    }
}
