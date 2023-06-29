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

        public List<CaracteristicaTransporte> GetAllCaracteristicaTransporte(int? idTransporte, int? idCaracteristica)
        {
            IQueryable<CaracteristicaTransporte> query = _context.CaracteristicaTransporte;

            if (idTransporte != null)
            {
                query = query.Where(t => t.TransporteId == idTransporte);
            }
            if (idCaracteristica != null)
            {
                query = query.Where(t => t.CaracteristicaId == idCaracteristica);
            }
            var ListaCaracteristicaTransporte = query
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
