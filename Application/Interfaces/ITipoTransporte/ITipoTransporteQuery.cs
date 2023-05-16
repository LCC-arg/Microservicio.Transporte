using Domain;

namespace Application.Interfaces.ITipoTransporte
{
    public interface ITipoTransporteQuery
    {
        public TipoTransporte GetTipoTransporteById(int tipoTransporteId);
        public List<TipoTransporte> GetAllTipoTransporte();
    }
}
