using Application.Interfaces.ICaracteristica;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Query
{
    public class CaracteristicaQuery : ICaracteristicaQuery
    {
        private readonly TransporteContext _context;

        public CaracteristicaQuery(TransporteContext context)
        {
            _context = context;
        }

        public List<Caracteristica> GetAllCaracteristicas()
        {
            var ListaCaracteristicas = _context.Caracteristica.OrderBy(c => c.CaracteristicaId).ToList();
            return ListaCaracteristicas;
        }

        public Caracteristica GetCaracteristicasById(int caracteristicaId)
        {
            var caracteristica = _context.Caracteristica.FirstOrDefault(c => c.CaracteristicaId == caracteristicaId);
            return caracteristica;

        }
    }
}
