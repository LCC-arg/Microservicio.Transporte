using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Interfaces.ICaracteristicaTransporte;
using Application.Interfaces.ITransporte;
using Application.Request;
using Application.Responses;
using Domain;

namespace Application.UseCase
{
    public class CaracteristicaTransporteService : ICaracteristicaTransporteService
    {
        private readonly ICaracteristicaTransporteCommand _command;
        private readonly ICaracteristicaTransporteQuery _query;
        private readonly ICaracteristicaQuery _caracteristicaQuery;
        private readonly ITransporteQuery _transporteQuery;

        public CaracteristicaTransporteService(ICaracteristicaTransporteCommand command, ICaracteristicaTransporteQuery query, ICaracteristicaQuery caracteristicaQuery, ITransporteQuery transporteQuery)
        {
            _command = command;
            _query = query;
            _transporteQuery = transporteQuery;
            _caracteristicaQuery = caracteristicaQuery;
        }

        public CaracteristicaTransporteResponse CreateCaracteristicaTransporte(CaracteristicaTransporteRequest caracteristicaTransporteRequest)
        {
            bool ExisteCaracteristicaId = _caracteristicaQuery.GetAllCaracteristicas().Any(m => m.CaracteristicaId == caracteristicaTransporteRequest.CaracteristicaId);
            if (!ExisteCaracteristicaId) { throw new ValorBadRequestException(" No existe una caracteristica registrada en la base de datos con ese ID"); }

            bool ExisteTransporteId = _transporteQuery.GetAllTransporte().Any(m => m.TransporteId == caracteristicaTransporteRequest.TransporteId);
            if (!ExisteTransporteId) { throw new ValorBadRequestException(" No existe un transporte registrado en la base de datos con ese ID"); }

            var caracteristicaTransporte = new CaracteristicaTransporte
            {
                CaracteristicaId = caracteristicaTransporteRequest.CaracteristicaId,
                TransporteId = caracteristicaTransporteRequest.TransporteId,
                Valor = caracteristicaTransporteRequest.Valor
            };
            _command.InsertCaracteristicaTransporte(caracteristicaTransporte);
            return new CaracteristicaTransporteResponse
            {
                Id = caracteristicaTransporte.CaracteristicaTransporteId,
                CaracteristicaId = caracteristicaTransporte.CaracteristicaId,
                TransporteId = caracteristicaTransporte.TransporteId,
                valor = caracteristicaTransporte.Valor
            };
        }

        public List<CaracteristicaTransporteResponse> GetAllCaracteristicaTransporte(int? idTransporte = null, int? idCaracteristica = null)
        {
            if (idCaracteristica != null)
            {
                bool ExisteCaracteristicaId = _caracteristicaQuery.GetAllCaracteristicas().Any(m => m.CaracteristicaId == idCaracteristica);
                if (!ExisteCaracteristicaId) { throw new ValorBadRequestException(" No existe una caracteristica registrada en la base de datos con ese ID"); }

            }
            if (idTransporte != null)
            {
                bool ExisteTransporteId = _transporteQuery.GetAllTransporte().Any(m => m.TransporteId == idTransporte);
                if (!ExisteTransporteId) { throw new ValorBadRequestException(" No existe un transporte registrado en la base de datos con ese ID"); }
            }



            List<CaracteristicaTransporteResponse> listaCaracteristicaTransporteResponse = new List<CaracteristicaTransporteResponse>();
            var lista = _query.GetAllCaracteristicaTransporte(idTransporte, idCaracteristica);
            foreach (var caracteristicaTransporte in lista)
            {
                var caracTransporteResponse = new CaracteristicaTransporteResponse
                {
                    Id = caracteristicaTransporte.CaracteristicaTransporteId,
                    CaracteristicaId = caracteristicaTransporte.CaracteristicaId,
                    TransporteId = caracteristicaTransporte.TransporteId,
                    valor = caracteristicaTransporte.Valor
                };
                listaCaracteristicaTransporteResponse.Add(caracTransporteResponse);
            }
            return listaCaracteristicaTransporteResponse;
        }

        public CaracteristicaTransporteResponse GetCaracteristicaTransportebyId(int caracteristicaTransporteId)
        {
            var caracteristicaTransporte = _query.GetCaracteristicaTransporteById(caracteristicaTransporteId);
            if (caracteristicaTransporte == null) { throw new ValorBadRequestException("No existe ninguna CaracteristicaTransporte registrada con ese ID"); }

            return new CaracteristicaTransporteResponse
            {
                Id = caracteristicaTransporte.CaracteristicaTransporteId,
                CaracteristicaId = caracteristicaTransporte.CaracteristicaId,
                TransporteId = caracteristicaTransporte.TransporteId,
                valor = caracteristicaTransporte.Valor
            };
        }

        public CaracteristicaTransporteResponse RemoveCaracteristicaTransporte(int caracteristicaTransporteId)
        {
            bool ValidarCT = _query.GetCaracteristicaTransporte().Any(c => c.CaracteristicaTransporteId == caracteristicaTransporteId);
            if (!ValidarCT) { throw new ValorBadRequestException("La CaracteristicaTransporte con ID " + caracteristicaTransporteId + " no existe en la base de datos."); }

            var caracteristicaTransporte = _command.DeleteCaracteristicaTransporte(caracteristicaTransporteId);
            return new CaracteristicaTransporteResponse
            {
                Id = caracteristicaTransporte.CaracteristicaTransporteId,
                CaracteristicaId = caracteristicaTransporte.CaracteristicaId,
                TransporteId = caracteristicaTransporte.TransporteId,
                valor = caracteristicaTransporte.Valor
            };

        }

        public CaracteristicaTransporteResponse UpdateCaracteristicaTransporte(int caracteristicaTransporteId, CaracteristicaTransporteRequest caracteristicaTransporteRequest)
        {
            bool ValidarCT = _query.GetCaracteristicaTransporte().Any(c => c.CaracteristicaTransporteId == caracteristicaTransporteId);
            if (!ValidarCT) { throw new ValorBadRequestException("La CaracteristicaTransporte con ID " + caracteristicaTransporteId + " no existe en la base de datos."); }

            bool ValidarC = _caracteristicaQuery.GetAllCaracteristicas().Any(c => c.CaracteristicaId == caracteristicaTransporteRequest.CaracteristicaId);
            if (!ValidarC) { throw new ValorBadRequestException("No existe Caracteristica con ese ID en la base de datos"); }

            bool ValidarT = _transporteQuery.GetAllTransporte().Any(c => c.TransporteId == caracteristicaTransporteRequest.TransporteId);
            if (!ValidarT) { throw new ValorBadRequestException("No existe Transporte con ese ID en la base de datos"); }

            var caracteristicaTransporte = _command.ActualizeCaracteristicaTransporte(caracteristicaTransporteId, caracteristicaTransporteRequest);

            return new CaracteristicaTransporteResponse
            {
                Id = caracteristicaTransporte.CaracteristicaTransporteId,
                CaracteristicaId = caracteristicaTransporte.CaracteristicaId,
                TransporteId = caracteristicaTransporte.TransporteId,
                valor = caracteristicaTransporte.Valor
            };
        }
    }
}
