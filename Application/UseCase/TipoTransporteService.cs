using Application.Exceptions;
using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Application.Responses;
using Domain;

namespace Application.UseCase
{
    public class TipoTransporteService : ITipoTransporteService
    {
        private readonly ITipoTransporteCommand _command;
        private readonly ITipoTransporteQuery _query;

        public TipoTransporteService(ITipoTransporteCommand command, ITipoTransporteQuery query)
        {
            _command = command;
            _query = query;
        }

        public TipoTransporteResponse CreateTipoTransporte(TipoTransporteRequest tipoTransporteRequest)
        {
            bool ExisteDescripcion = _query.GetAllTipoTransporte().Any(m => m.Descripcion.ToUpper() == tipoTransporteRequest.Descripcion.ToUpper());
            if (ExisteDescripcion) { throw new ValorConflictException("La descripcion ingresada ya se encuentra en la base de datos."); };

            var tipoTransporte = new TipoTransporte
            {
                Descripcion = tipoTransporteRequest.Descripcion
            };
            _command.InsertTipoTransporte(tipoTransporte);
            return new TipoTransporteResponse
            {
                Id = tipoTransporte.TipoTransporteId,
                Descripcion = tipoTransporte.Descripcion
            };
        }

        public List<TipoTransporteResponse> GetAllTipoTransporte()
        {
            List<TipoTransporteResponse> listaTipoResponse = new List<TipoTransporteResponse>();
            var lista = _query.GetAllTipoTransporte();
            foreach (var transporte in lista)
            {
                var TipoTransporteResponse = new TipoTransporteResponse
                {
                    Id = transporte.TipoTransporteId,
                    Descripcion= transporte.Descripcion
                };
                listaTipoResponse.Add(TipoTransporteResponse);
            }
            return listaTipoResponse;
        }

        public TipoTransporteResponse GetTipoTransportebyId(int tipoTransporteId)
        {
            var tipoTransporte = _query.GetTipoTransporteById(tipoTransporteId);
            if (tipoTransporte == null) { throw new ValorBadRequestException("No existe ningun tipo de transporte registrado con ese ID"); }

            return new TipoTransporteResponse
            {
                Id = tipoTransporte.TipoTransporteId,
                Descripcion = tipoTransporte.Descripcion
            };
        }

        public TipoTransporteResponse RemoveTipoTransporte(int tipoTransporteId)
        {
            bool ValidarTipo = _query.GetAllTipoTransporte().Any(c => c.TipoTransporteId == tipoTransporteId);
            if (!ValidarTipo) { throw new ValorBadRequestException("El tipo de transporte con ID " + tipoTransporteId + " no existe en la base de datos."); }

            var tipoTransporte = _command.DeleteTipoTransporte(tipoTransporteId);
            return new TipoTransporteResponse
            {
                Id = tipoTransporte.TipoTransporteId,
                Descripcion = tipoTransporte.Descripcion
            };
        }

        public TipoTransporteResponse UpdateTipoTransporte(int tipoTransporteId, TipoTransporteRequest tipoTransporteRequest)
        {
            bool ValidarTipo = _query.GetAllTipoTransporte().Any(c => c.TipoTransporteId == tipoTransporteId);
            if (!ValidarTipo) { throw new ValorBadRequestException("El tipo de transporte con ID " + tipoTransporteId + " no existe en la base de datos."); }

            bool ExisteDescripcion = _query.GetAllTipoTransporte().Any(m => m.Descripcion.ToUpper() == tipoTransporteRequest.Descripcion.ToUpper());
            if (ExisteDescripcion) { throw new ValorConflictException("La descripcion ingresada ya se encuentra en la base de datos."); };

            var tipoTransporte = _command.ActualizeTipoTransporte(tipoTransporteId, tipoTransporteRequest);
            return new TipoTransporteResponse
            {
                Id = tipoTransporte.TipoTransporteId,
                Descripcion = tipoTransporte.Descripcion
            };
        }
    }
}
