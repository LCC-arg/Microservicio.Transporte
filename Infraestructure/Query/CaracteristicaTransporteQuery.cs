using Application.Interfaces.ICaracteristicaTransporte;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class CaracteristicaTransporteQuery : ICaracteristicaTransporteQuery
    {
        private readonly TransporteContext _context;

        public CaracteristicaTransporteQuery(TransporteContext context)
        {
            _context = context;
        }

        public List<CaracteristicaTransporte> GetAllCaracteristicaTransporte()
        {
            var ListaCaracteristicaTransporte = _context.CaracteristicaTransporte
                .Include(c => c.Caracteristica)
                .Include(c => c.Transporte)
                .OrderBy(c => c.CaracteristicaTransporteId).ToList();
            return ListaCaracteristicaTransporte;
        }

        public CaracteristicaTransporte GetCaracteristicaTransporteById(int caracteristicaTransporteId)
        {
            var caracteristicaTransporte = _context.CaracteristicaTransporte.FirstOrDefault(Ct => Ct.CaracteristicaTransporteId == caracteristicaTransporteId);
            return caracteristicaTransporte;
        }
    }
}
