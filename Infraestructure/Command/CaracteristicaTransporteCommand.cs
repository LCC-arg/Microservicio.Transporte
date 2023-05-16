using Application.Interfaces.ICaracteristicaTransporte;
using Application.Request;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class CaracteristicaTransporteCommand : ICaracteristicaTransporteCommand
    {
        private readonly TransporteContext _context;

        public CaracteristicaTransporteCommand(TransporteContext context)
        {
            _context = context;
        }

        public CaracteristicaTransporte ActualizeCaracteristicaTransporte(int caracteristicaTransporteId, CaracteristicaTransporteRequest caracteristicaTransporteRequest)
        {
            var caracteristicaTransporteOriginal = _context.CaracteristicaTransporte.FirstOrDefault(c => c.CaracteristicaTransporteId == caracteristicaTransporteId);

            caracteristicaTransporteOriginal.Valor = caracteristicaTransporteRequest.Valor;
            caracteristicaTransporteOriginal.CaracteristicaId = caracteristicaTransporteRequest.CaracteristicaId;
            caracteristicaTransporteOriginal.TransporteId = caracteristicaTransporteRequest.TransporteId;

            _context.Update(caracteristicaTransporteOriginal);
            _context.SaveChanges();
            return caracteristicaTransporteOriginal;
        }

        public CaracteristicaTransporte DeleteCaracteristicaTransporte(int caracteristicaTransporteId)
        {
            var caracteristicaTransporte = _context.CaracteristicaTransporte.Single(c => c.CaracteristicaTransporteId == caracteristicaTransporteId);
            _context.Remove(caracteristicaTransporte);
            _context.SaveChanges();
            return caracteristicaTransporte;
        }

        public CaracteristicaTransporte InsertCaracteristicaTransporte(CaracteristicaTransporte caracteristicaTransporte)
        {
            _context.Add(caracteristicaTransporte);
            _context.SaveChanges();
            return caracteristicaTransporte;
        }
    }
}
