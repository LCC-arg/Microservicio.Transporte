using Application.Request;
using Domain;

namespace Application.Interfaces.ITransporte
{
    public interface ITransporteCommand
    {
        public Transporte InsertTransporte(Transporte transporte);
        public Transporte DeleteTransporte(int transporteId);
        public Transporte ActualizeTransporte(int transporteId, TransporteRequest transporteRequest);
    }
}
