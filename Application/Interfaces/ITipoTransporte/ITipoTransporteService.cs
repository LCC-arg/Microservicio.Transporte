using Application.Request;
using Application.Responses;
using Domain;

namespace Application.Interfaces.ITipoTransporte
{
    public interface ITipoTransporteService
    {
        public TipoTransporteResponse CreateTipoTransporte(TipoTransporteRequest tipoTransporte);
        public TipoTransporteResponse RemoveTipoTransporte(int tipoTransporteId);
        public TipoTransporteResponse GetTipoTransportebyId(int tipoTransporteId);
        public TipoTransporteResponse UpdateTipoTransporte(int tipoTransporteId, TipoTransporteRequest tipoTransporte);
        public List<TipoTransporteResponse> GetAllTipoTransporte();
    }
}
