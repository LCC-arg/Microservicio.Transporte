using Application.Request;
using Application.Responses;
using Domain;

namespace Application.Interfaces.ICaracteristica
{
    public interface ICaracteristicaService
    {
        public CaracteristicaResponse CreateCaracteristica(CaracteristicaRequest caracteristica);
        public CaracteristicaResponse RemoveCaracteristica(int caracteristicaId);
        public CaracteristicaResponse GetCaracteristicabyId(int caracteristicaId);
        public CaracteristicaResponse UpdateCaracteristica(int caracteristicaId, CaracteristicaRequest caracteristicaRequest);
        public List<CaracteristicaResponse> GetAllCaracteristica();
    }
}
