using Application.Interfaces.ITransporte;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Query
{
    public class TransporteQuery : ITransporteQuery
    {
        private readonly TransporteContext _context;

        public TransporteQuery(TransporteContext context)
        {
            _context = context;
        }

        public List<Transporte> GetAllTransporte()
        {
            var ListaTransporte = _context.Transporte
                .Include(c => c.CompaniaTransporte)
                .Include(c => c.TipoTransporte)
                .OrderBy(c => c.TransporteId).ToList();
            return ListaTransporte;
        }

        public Transporte GetTransporteById(int transporteId)
        {
            var transporte = _context.Transporte
                .Include(c => c.CompaniaTransporte)
                .Include(c => c.TipoTransporte)
                .FirstOrDefault(c => c.TransporteId == transporteId);
            return transporte;
        }
    }
}
