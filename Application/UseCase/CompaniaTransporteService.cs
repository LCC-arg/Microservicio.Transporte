using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Request;
using Application.Responses;
using Domain;
using System.Reflection.PortableExecutable;

namespace Application.UseCase
{
    public class CompaniaTransporteService : ICompaniaTransporteService
    {
        private readonly ICompaniaTransporteCommand _command;
        private readonly ICompaniaTransporteQuery _query;

        public CompaniaTransporteService(ICompaniaTransporteCommand command, ICompaniaTransporteQuery query)
        {
            _command = command;
            _query = query;
        }

        public CompaniaTransporteResponse CreateCompaniaTransporte(CompaniaTransporteRequest companiaRequest)
        {
            bool ExisteRazonSocial = _query.GetAllCompaniaTransporte().Any(m => m.RazonSocial.ToUpper() == companiaRequest.RazonSocial.ToUpper());
            if (ExisteRazonSocial) { throw new ValorConflictException("La Razon Social ingresada ya se encuentra en la base de datos."); };

            bool ExisteCuit = _query.GetAllCompaniaTransporte().Any(m => m.Cuit == companiaRequest.Cuit);
            if (ExisteCuit) { throw new ValorConflictException("El N° de Cuit ingresado ya se encuentra en la base de datos."); };

            var compania = new CompaniaTransporte
            {
                Cuit = companiaRequest.Cuit,
                RazonSocial = companiaRequest.RazonSocial,
                ImagenLogo = companiaRequest.Imagen
            };
            _command.InsertCompaniaTransporte(compania);
            return new CompaniaTransporteResponse
            {
                Id = compania.CompaniaTransporteId,
                Cuit = compania.Cuit,
                RazonSocial = compania.RazonSocial,
                Imagen = compania.ImagenLogo
            };
        }

        public List<CompaniaTransporteResponse> GetAllCompaniaTransporte()
        {
            List<CompaniaTransporteResponse> listaCompaniaResponse = new List<CompaniaTransporteResponse> ();
            var lista = _query.GetAllCompaniaTransporte();
            foreach (var compania in lista)
            {
                var companiaResponse = new CompaniaTransporteResponse
                {
                    Cuit = compania.Cuit,
                    RazonSocial = compania.RazonSocial,
                    Id = compania.CompaniaTransporteId,
                    Imagen = compania.ImagenLogo
                };
                listaCompaniaResponse.Add(companiaResponse);
            }
            return listaCompaniaResponse;
        }

        public CompaniaTransporteResponse GetCompaniaTransportebyId(int companiaTransporteId)
        {
            var compania = _query.GetCompaniaTransporteById(companiaTransporteId);
            if (compania == null) { throw new ValorBadRequestException("No existe ninguna compania de transporte registrada con ese ID"); }
           
            return new CompaniaTransporteResponse
            {
                Id = compania.CompaniaTransporteId,
                Cuit = compania.Cuit,
                RazonSocial = compania.RazonSocial,
                Imagen = compania.ImagenLogo
               
            };
        }

        public CompaniaTransporteResponse RemoveCompaniaTransporte(int companiaTransporteId)
        {
            bool ValidarCt = _query.GetAllCompaniaTransporte().Any(c => c.CompaniaTransporteId == companiaTransporteId);
            if (!ValidarCt) { throw new ValorBadRequestException("La Compania de transporte con ID " + companiaTransporteId + " no existe en la base de datos."); }

            var compania = _command.DeleteCompaniaTransporte(companiaTransporteId);
            return new CompaniaTransporteResponse
            {
                Id = compania.CompaniaTransporteId,
                Cuit = compania.Cuit,
                RazonSocial = compania.RazonSocial,
                Imagen = compania.ImagenLogo
            };
        }

        public CompaniaTransporteResponse UpdateCompaniaTransporte(int companiaTransporteId, CompaniaTransporteRequest companiaRequest)
        {
            bool ValidarCt = _query.GetAllCompaniaTransporte().Any(c => c.CompaniaTransporteId == companiaTransporteId);
            if (!ValidarCt) { throw new ValorBadRequestException("La Compania de transporte con ID " + companiaTransporteId + " no existe en la base de datos."); }

            bool ExisteRazonSocial = _query.GetAllCompaniaTransporte().Any(m => m.RazonSocial.ToUpper() == companiaRequest.RazonSocial.ToUpper());
            if (ExisteRazonSocial) { throw new ValorConflictException("La Razon Social ingresada ya se encuentra en la base de datos."); };

            bool ExisteCuit = _query.GetAllCompaniaTransporte().Any(m => m.Cuit == companiaRequest.Cuit);
            if (ExisteCuit) { throw new ValorConflictException("El N° de Cuit ingresado ya se encuentra en la base de datos."); };

            var compania = _command.ActualizeCompaniaTransporte(companiaTransporteId, companiaRequest);
            return new CompaniaTransporteResponse
            {
                Id = compania.CompaniaTransporteId,
                Cuit = compania.Cuit,
                RazonSocial = compania.RazonSocial,
                Imagen = compania.ImagenLogo
            };
        }
    }
}
