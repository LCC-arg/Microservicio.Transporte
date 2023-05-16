using Domain;

namespace Application.Interfaces.ICompaniaTransporte
{
    public interface ICompaniaTransporteQuery
    {
        public CompaniaTransporte GetCompaniaTransporteById(int companiaTransporteId);
        public List<CompaniaTransporte> GetAllCompaniaTransporte();
    }
}
