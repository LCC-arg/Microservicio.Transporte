using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class CaracteristicaTransporteRequest
    {
        public int CaracteristicaId { get; set; }
        public int TransporteId { get; set; }
        public string Valor { get; set; }
    }
}
