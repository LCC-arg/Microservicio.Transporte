using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class CaracteristicaTransporteResponse
    {
        public int Id { get; set; }
        public string valor { get; set; }
        public int TransporteId { get; set; }
        public int CaracteristicaId { get; set; }
    }
}
