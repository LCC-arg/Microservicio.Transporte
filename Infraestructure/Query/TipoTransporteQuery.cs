using Application.Interfaces.ITipoTransporte;
using Domain;

namespace Infraestructure.Query
{
    public class TipoTransporteQuery : ITipoTransporteQuery
    {
        private readonly TransporteContext _context;

        public TipoTransporteQuery(TransporteContext context)
        {
            _context = context;
        }

        public List<TipoTransporte> GetAllTipoTransporte()
        {
            var ListaTipoTransporte = _context.TipoTransporte.OrderBy(c => c.TipoTransporteId).ToList();
            return ListaTipoTransporte;
        }

        public TipoTransporte GetTipoTransporteById(int tipoTransporteId)
        {
            var tipoTransporte = _context.TipoTransporte.FirstOrDefault(c => c.TipoTransporteId == tipoTransporteId);
            return tipoTransporte;
        }
    }
}
