using Application.Request;
using Application.Responses;
using Domain;

namespace Application.Interfaces.ICompaniaTransporte
{
    public interface ICompaniaTransporteService 
    {
        public CompaniaTransporteResponse CreateCompaniaTransporte(CompaniaTransporteRequest companiaRequest);
        public CompaniaTransporteResponse RemoveCompaniaTransporte(int companiaTransporteId);
        public CompaniaTransporteResponse GetCompaniaTransportebyId(int companiaTransporteId);
        public CompaniaTransporteResponse UpdateCompaniaTransporte(int companiaTransporteId, CompaniaTransporteRequest companiaRequest);
        public List<CompaniaTransporteResponse> GetAllCompaniaTransporte();
    }
}