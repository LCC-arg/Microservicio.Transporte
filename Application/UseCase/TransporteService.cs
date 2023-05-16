using Application.Exceptions;
using Application.Interfaces.ICompaniaTransporte;
using Application.Interfaces.ITipoTransporte;
using Application.Interfaces.ITransporte;
using Application.Request;
using Application.Responses;
using Domain;
using Microsoft.Extensions.Options;
using System.Diagnostics.SymbolStore;
using System.Drawing;

namespace Application.UseCase
{
    public class TransporteService : ITransporteService
    {
        private readonly ITransporteCommand _command;
        private readonly ITransporteQuery _query;
        private readonly ITipoTransporteQuery _tipoTransporteQuery;
        private readonly ICompaniaTransporteQuery _companiaTransporteQuery;

        public TransporteService(ITransporteCommand command, ITransporteQuery query, ITipoTransporteQuery tipoTransporteQuery, ICompaniaTransporteQuery companiaTransporteQuery)
        {
            _command = command;
            _query = query;
            _tipoTransporteQuery = tipoTransporteQuery;
            _companiaTransporteQuery = companiaTransporteQuery;
        }

        public TransporteResponse CreateTransporte(TransporteRequest transporteRequest)
        {
            bool ExisteCompania = _companiaTransporteQuery.GetAllCompaniaTransporte().Any(cm => cm.CompaniaTransporteId == transporteRequest.CompaniaTransporteId);
            if (!ExisteCompania) { throw new ValorBadRequestException("La compania ingresada no existe."); }

            bool ExisteTipo = _tipoTransporteQuery.GetAllTipoTransporte().Any(cm => cm.TipoTransporteId == transporteRequest.TipoTransporteId);
            if (!ExisteTipo) { throw new ValorBadRequestException("El tipo de transporte ingresado no existe."); }


            var transporte = new Transporte
            {
                TipoTransporteId = transporteRequest.TipoTransporteId,
                CompaniaTransporteId = transporteRequest.CompaniaTransporteId
            };
            _command.InsertTransporte(transporte);
            return new TransporteResponse
            {
                Id = transporte.TransporteId,
                CompaniaTransporteId = transporte.CompaniaTransporteId,
                TipoTransporteId = transporte.TipoTransporteId
            };
        }

        public List<TransporteGetResponse> GetAllTransporte()
        {
            List<TransporteGetResponse> listaTransporteGetResponses = new List<TransporteGetResponse>();
            var lista = _query.GetAllTransporte();

            foreach (var transporte in lista)
            {
                var transporteGetResponse = new TransporteGetResponse
                {
                    Id = transporte.TransporteId,
                    TipoTransporteResponse = new TipoTransporteResponse
                    {
                        Id = transporte.TipoTransporteId,
                        Descripcion = transporte.TipoTransporte.Descripcion
                    },
                    CompaniaTransporteResponse = new CompaniaTransporteResponse
                    {
                        Id = transporte.CompaniaTransporteId,
                        RazonSocial = transporte.CompaniaTransporte.RazonSocial,
                        Cuit = transporte.CompaniaTransporte.Cuit
                    }
                };
                listaTransporteGetResponses.Add(transporteGetResponse);
            }
            return listaTransporteGetResponses;
        }

        public TransporteGetResponse GetTransportebyId(int transporteId)
        {
            bool ValidarTransporte = _query.GetAllTransporte().Any(c => c.TransporteId == transporteId);
            if (!ValidarTransporte) { throw new ValorBadRequestException("El transporte con ID " + transporteId + " no existe en la base de datos."); }

            var transporte = _query.GetTransporteById(transporteId);

            return new TransporteGetResponse
            {
                Id = transporte.TransporteId,
                TipoTransporteResponse = new TipoTransporteResponse
                {
                    Id = transporte.TipoTransporteId,
                    Descripcion = transporte.TipoTransporte.Descripcion
                },
                CompaniaTransporteResponse = new CompaniaTransporteResponse
                {
                    Id = transporte.CompaniaTransporteId,
                    RazonSocial = transporte.CompaniaTransporte.RazonSocial,
                    Cuit = transporte.CompaniaTransporte.Cuit
                }
            };  
        }

        public TransporteResponse RemoveTransporte(int transporteId)
        {
            bool ValidarTransporte = _query.GetAllTransporte().Any(c => c.TransporteId == transporteId);
            if (!ValidarTransporte) { throw new ValorBadRequestException("El transporte con ID " + transporteId + " no existe en la base de datos."); }

            var transporte = _command.DeleteTransporte(transporteId);
            return new TransporteResponse
            {
                Id = transporte.TransporteId,
                CompaniaTransporteId = transporte.CompaniaTransporteId,
                TipoTransporteId = transporte.TransporteId
            };
        }

        public TransporteResponse UpdateTransporte(int transporteId, TransporteRequest transporteRequest)
        {
            var caracteristica = _query.GetTransporteById(transporteId);
            if (caracteristica == null) { throw new ValorBadRequestException("No existe ningun transporte registrado con ese ID"); }

            bool ExisteCompania = _companiaTransporteQuery.GetAllCompaniaTransporte().Any(cm => cm.CompaniaTransporteId == transporteRequest.CompaniaTransporteId);
            if (!ExisteCompania) { throw new ValorBadRequestException("La compania ingresada no existe."); }

            bool ExisteTipo = _tipoTransporteQuery.GetAllTipoTransporte().Any(cm => cm.TipoTransporteId == transporteRequest.TipoTransporteId);
            if (!ExisteTipo) { throw new ValorBadRequestException("El tipo de transporte ingresado no existe."); }

            var transporte = _command.ActualizeTransporte(transporteId, transporteRequest);
            return new TransporteResponse
            {
                Id = transporte.TransporteId,
                CompaniaTransporteId = transporte.CompaniaTransporteId,
                TipoTransporteId = transporte.TransporteId
            };
        }
    }
}
