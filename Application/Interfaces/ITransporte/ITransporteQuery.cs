using Domain;

namespace Application.Interfaces.ITransporte
{
    public interface ITransporteQuery
    {
        public Transporte GetTransporteById(int transporteId);
        public List<Transporte> GetAllTransporte();
    }
}
