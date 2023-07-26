using Application.Exceptions;
using Application.Interfaces.ICaracteristica;
using Application.Interfaces.ICompaniaTransporte;
using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Application.Responses;
using Domain;
using System.Reflection.PortableExecutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.UseCase
{
    public class CaracteristicaService : ICaracteristicaService
    {
        private readonly ICaracteristicaCommand _command;
        private readonly ICaracteristicaQuery _query;
        

        public CaracteristicaService(ICaracteristicaCommand command, ICaracteristicaQuery query)
        {
            _command = command;
            _query = query;
        }

        public CaracteristicaResponse CreateCaracteristica(CaracteristicaRequest caracteristica)
        {
            bool ExisteDescripcion = _query.GetAllCaracteristicas().Any(m => m.Descripcion.ToUpper() == caracteristica.Descripcion.ToUpper());
            if (ExisteDescripcion) { throw new ValorConflictException("La descripcion ingresada ya se encuentra en la base de datos."); };

            var caracteristicaOriginal = new Caracteristica
            {
                Descripcion = caracteristica.Descripcion,
            }; 
            _command.InsertCaracteristica(caracteristicaOriginal);
            return new CaracteristicaResponse
            {
                Id = caracteristicaOriginal.CaracteristicaId,
                Descripcion = caracteristicaOriginal.Descripcion
            };
        }

        public List<CaracteristicaResponse> GetAllCaracteristica()
        {
            List<CaracteristicaResponse> listaCaracteristicaResponses = new List<CaracteristicaResponse>();
            var lista = _query.GetAllCaracteristicas();

            foreach(var caracteristica in lista)
            {
                var caracteristicaResponse = new CaracteristicaResponse
                {
                    Id = caracteristica.CaracteristicaId,
                    Descripcion = caracteristica.Descripcion
                };
                listaCaracteristicaResponses.Add(caracteristicaResponse);
            }
            return listaCaracteristicaResponses;
        }

        public CaracteristicaResponse GetCaracteristicabyId(int caracteristicaId)
        {
            var caracteristicas = _query.GetCaracteristicasById(caracteristicaId);
            if (caracteristicas == null) { throw new ValorBadRequestException("No existe ninguna caracteristica registrada con ese ID"); }

            return new CaracteristicaResponse
            {
                Id = caracteristicas.CaracteristicaId,
                Descripcion = caracteristicas.Descripcion
            };
        }

        public CaracteristicaResponse RemoveCaracteristica(int caracteristicaId)
        {
            bool ValidarCaracteristica = _query.GetAllCaracteristicas().Any(c => c.CaracteristicaId == caracteristicaId);
            if (!ValidarCaracteristica) { throw new ValorBadRequestException("La caracteristica con ID " + caracteristicaId + " no existe en la base de datos."); }
            
            var caracteristica = _command.DeleteCaracteristica(caracteristicaId);

            return  new CaracteristicaResponse
            {
                Id = caracteristica.CaracteristicaId,
                Descripcion = caracteristica.Descripcion
            };
        }

        public CaracteristicaResponse UpdateCaracteristica(int caracteristicaId, CaracteristicaRequest caracteristicaRequest)
        {
            var caracteristica = _query.GetCaracteristicasById(caracteristicaId);
            if (caracteristica == null) { throw new ValorBadRequestException("No existe ninguna caracteristica registrada con ese ID"); }

            bool ExisteDescripcion = _query.GetAllCaracteristicas().Any(m => m.Descripcion.ToUpper() == caracteristicaRequest.Descripcion.ToUpper());
            if (ExisteDescripcion) { throw new ValorConflictException("La descripcion ingresada ya se encuentra en la base de datos."); };

            var caracteristicas = _command.ActualizeCaracteristica(caracteristicaId, caracteristicaRequest);

            return new CaracteristicaResponse
            {
                Id = caracteristicas.CaracteristicaId,
                Descripcion = caracteristicas.Descripcion
            };
        }
    }
}
