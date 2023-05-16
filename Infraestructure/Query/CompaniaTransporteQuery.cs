using Application.Interfaces.ICompaniaTransporte;
using Domain;

namespace Infraestructure.Query
{
    public class CompaniaTransporteQuery : ICompaniaTransporteQuery
    {
        private readonly TransporteContext _context;

        public CompaniaTransporteQuery(TransporteContext context)
        {
            _context = context;
        }

        public List<CompaniaTransporte> GetAllCompaniaTransporte()
        {
            var listaCompaniaTransporte = _context.CompaniaTransporte.OrderBy(Ct => Ct.CompaniaTransporteId).ToList();
            return listaCompaniaTransporte;
        }

        public CompaniaTransporte GetCompaniaTransporteById(int companiaTransporteId)
        {
            var companiaTransporte = _context.CompaniaTransporte.FirstOrDefault(Ct => Ct.CompaniaTransporteId == companiaTransporteId);
            return companiaTransporte;
        }
    }
}
