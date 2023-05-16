using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class TransporteGetResponse
    {
        public int Id { get; set; }
        public CompaniaTransporteResponse CompaniaTransporteResponse { get; set; }
        public TipoTransporteResponse TipoTransporteResponse { get; set; }
    }
}
