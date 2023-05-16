using Application.Request;
using Application.Responses;
using Domain;

namespace Application.Interfaces.ITransporte
{
    public interface ITransporteService
    {
        public TransporteResponse CreateTransporte(TransporteRequest transporte);
        public TransporteResponse RemoveTransporte(int transporteId);
        public TransporteGetResponse GetTransportebyId(int transporteId);
        public TransporteResponse UpdateTransporte(int transporteId, TransporteRequest transporte);
        public List<TransporteGetResponse> GetAllTransporte();
    }
}
