using Application.Request;
using Domain;

namespace Application.Interfaces.ITipoTransporte
{
    public interface ITipoTransporteCommand
    {
        public TipoTransporte InsertTipoTransporte(TipoTransporte tipoTransporte);
        public TipoTransporte DeleteTipoTransporte(int tipoTransporteId);
        public TipoTransporte ActualizeTipoTransporte(int tipoTransporteId, TipoTransporteRequest tipoTransporteRequest);
    }
}