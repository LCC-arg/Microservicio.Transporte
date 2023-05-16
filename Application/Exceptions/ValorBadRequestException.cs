using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValorBadRequestException : Exception
    {
        public ValorBadRequestException(string mensaje) : base(mensaje)
        {
        }
    }
}
