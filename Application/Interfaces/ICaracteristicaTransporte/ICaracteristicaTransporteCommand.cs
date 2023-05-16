using Application.Request;
using Domain;

namespace Application.Interfaces.ICaracteristicaTransporte
{
    public interface ICaracteristicaTransporteCommand
    {
        CaracteristicaTransporte InsertCaracteristicaTransporte(CaracteristicaTransporte caracteristicaTransporte);
        CaracteristicaTransporte DeleteCaracteristicaTransporte(int caracteristicaTransporteId);
        CaracteristicaTransporte ActualizeCaracteristicaTransporte(int caracteristicaTransporteId, CaracteristicaTransporteRequest caracteristicaTransporteRequest);
    }
}
