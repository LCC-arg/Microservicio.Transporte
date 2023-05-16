using Application.Interfaces.ICompaniaTransporte;
using Application.Request;
using Domain;

namespace Infraestructure.Command
{
    public class CompaniaTransporteCommand : ICompaniaTransporteCommand
    {
        private readonly TransporteContext _context;

        public CompaniaTransporteCommand(TransporteContext context)
        {
            _context = context;
        }

        public CompaniaTransporte InsertCompaniaTransporte(CompaniaTransporte companiaTransporte)
        {
            _context.Add(companiaTransporte);
            _context.SaveChanges();
            return companiaTransporte;
        }

        public CompaniaTransporte DeleteCompaniaTransporte(int companiaTransporteId)
        {
            var companiaTransporte = _context.CompaniaTransporte.Single(c => c.CompaniaTransporteId == companiaTransporteId);
            _context.Remove(companiaTransporte);
            _context.SaveChanges();
            return companiaTransporte;
        }

        public CompaniaTransporte ActualizeCompaniaTransporte(int companiaTransporteId, CompaniaTransporteRequest companiaRequest)
        {
            var companiaTransporteOriginal = _context.CompaniaTransporte.FirstOrDefault(c => c.CompaniaTransporteId == companiaTransporteId);

            companiaTransporteOriginal.RazonSocial = companiaRequest.RazonSocial;
            companiaTransporteOriginal.Cuit = companiaRequest.Cuit;
            _context.Update(companiaTransporteOriginal);
            _context.SaveChanges();
            return companiaTransporteOriginal;
        }
    }
}
