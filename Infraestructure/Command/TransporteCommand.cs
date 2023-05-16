using Application.Interfaces.ITransporte;
using Application.Request;
using Domain;

namespace Infraestructure.Command
{
    public class TransporteCommand : ITransporteCommand
    {
        private readonly TransporteContext _context;

        public TransporteCommand(TransporteContext context)
        {
            _context = context;
        }

        public Transporte ActualizeTransporte(int transporteId, TransporteRequest transporteRequest)
        {
            var transporteOriginal = _context.Transporte.FirstOrDefault(c => c.TransporteId == transporteId);

            transporteOriginal.TipoTransporteId = transporteRequest.TipoTransporteId;
            transporteOriginal.CompaniaTransporteId= transporteRequest.CompaniaTransporteId;

            _context.Update(transporteOriginal);
            _context.SaveChanges();

            return transporteOriginal;
        }

        public Transporte DeleteTransporte(int transporteId)
        {
            var transporte = _context.Transporte.Single(c => c.TransporteId == transporteId);
            _context.Remove(transporte);
            _context.SaveChanges();
            return transporte;
        }

        public Transporte InsertTransporte(Transporte transporte)
        {
            _context.Add(transporte);
            _context.SaveChanges();
            return transporte;
        }
    }
}
