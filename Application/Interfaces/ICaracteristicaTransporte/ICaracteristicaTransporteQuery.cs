using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICaracteristicaTransporte
{
    public interface ICaracteristicaTransporteQuery
    {
        List<CaracteristicaTransporte> GetAllCaracteristicaTransporte(int? idTransporte = null, int? idCaracteristica = null);
        CaracteristicaTransporte GetCaracteristicaTransporteById(int caracteristicaTransporteId);
    }
}
