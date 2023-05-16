using Application.Request;
using Domain;

namespace Application.Interfaces.ICompaniaTransporte
{
    public interface ICompaniaTransporteCommand
    {
        public CompaniaTransporte InsertCompaniaTransporte(CompaniaTransporte companiaTransporte);
        public CompaniaTransporte DeleteCompaniaTransporte(int companiaTransporteId);
        public CompaniaTransporte ActualizeCompaniaTransporte(int companiaTransporteId, CompaniaTransporteRequest companiaRequest);
    }
}
