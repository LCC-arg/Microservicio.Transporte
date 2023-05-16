using Application.Interfaces.ICaracteristica;
using Application.Request;
using Domain;

namespace Infraestructure.Command
{
    public class CaracteristicaCommand : ICaracteristicaCommand
    {
        private readonly TransporteContext _context;

        public CaracteristicaCommand(TransporteContext context)
        {
            _context = context;
        }

        public Caracteristica DeleteCaracteristica(int caracteristicaId)
        {
            var caracteristica = _context.Caracteristica.Single(c => c.CaracteristicaId == caracteristicaId);
            _context.Remove(caracteristica);
            _context.SaveChanges();
            return caracteristica;
        }

        public Caracteristica InsertCaracteristica(Caracteristica caracteristica)
        {
            _context.Add(caracteristica);
            _context.SaveChanges();
            return caracteristica;
        }

        public Caracteristica ActualizeCaracteristica(int caracteristicaId, CaracteristicaRequest caracteristicaRequest)
        {
            var caracteristicaOriginal = _context.Caracteristica.FirstOrDefault(c => c.CaracteristicaId == caracteristicaId);

            caracteristicaOriginal.Descripcion = caracteristicaRequest.Descripcion;
            _context.Update(caracteristicaOriginal);
            _context.SaveChanges();
            return caracteristicaOriginal;

        }
    }
}
