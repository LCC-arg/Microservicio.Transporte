using Application.Request;
using Application.Responses;
using Domain;

namespace Application.Interfaces.ICaracteristicaTransporte
{
    public interface ICaracteristicaTransporteService
    {
        public CaracteristicaTransporteResponse CreateCaracteristicaTransporte(CaracteristicaTransporteRequest caracteristicaTransporte);
        public CaracteristicaTransporteResponse RemoveCaracteristicaTransporte(int caracteristicaTransporteId);
        public CaracteristicaTransporteResponse GetCaracteristicaTransportebyId(int caracteristicaTransporteId);
        public CaracteristicaTransporteResponse UpdateCaracteristicaTransporte(int caracteristicaTransporteId, CaracteristicaTransporteRequest caracteristicaTransporte);
        public List<CaracteristicaTransporteResponse> GetAllCaracteristicaTransporte(int? idTransporte = null, int? idCaracteristica = null);
    }
}
