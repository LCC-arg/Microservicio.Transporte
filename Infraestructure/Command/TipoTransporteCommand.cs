using Application.Interfaces.ITipoTransporte;
using Application.Request;
using Domain;
using System.Reflection.PortableExecutable;

namespace Infraestructure.Command
{
    public class TipoTransporteCommand : ITipoTransporteCommand
    {
        private readonly TransporteContext _context;

        public TipoTransporteCommand(TransporteContext context)
        {
            _context = context;
        }

        public TipoTransporte DeleteTipoTransporte(int tipoTransporteId)
        {
            var tipotransporte = _context.TipoTransporte.Single(c => c.TipoTransporteId == tipoTransporteId);
            _context.Remove(tipotransporte);
            _context.SaveChanges();
            return tipotransporte;
        }

        public TipoTransporte InsertTipoTransporte(TipoTransporte tipoTransporte)
        {
            _context.Add(tipoTransporte);
            _context.SaveChanges();
            return tipoTransporte;
        }

        public TipoTransporte ActualizeTipoTransporte(int tipoTransporteId, TipoTransporteRequest tipoTransporteRequest)
        {
            var tipoTransporteOriginal = _context.TipoTransporte.FirstOrDefault(c => c.TipoTransporteId == tipoTransporteId);

            tipoTransporteOriginal.Descripcion = tipoTransporteRequest.Descripcion;
            _context.Update(tipoTransporteOriginal);
            _context.SaveChanges();
            return tipoTransporteOriginal;
        }
    }
}
