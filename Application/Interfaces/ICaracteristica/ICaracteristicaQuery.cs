using Domain;

namespace Application.Interfaces.ICaracteristica
{
    public interface ICaracteristicaQuery
    {
         List<Caracteristica> GetAllCaracteristicas();
         Caracteristica GetCaracteristicasById(int caracteristicaId);
    }
}
