using Application.Request;
using Domain;

namespace Application.Interfaces.ICaracteristica
{
    public interface ICaracteristicaCommand
    {
        Caracteristica InsertCaracteristica(Caracteristica caracteristica);
        Caracteristica DeleteCaracteristica(int caracteristicaId);
        Caracteristica ActualizeCaracteristica(int caracteristicaId, CaracteristicaRequest caracteristica);
    }
}