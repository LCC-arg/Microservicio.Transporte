using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValorConflictException : Exception
    {
        public ValorConflictException(string mensaje) : base(mensaje)
        {
        }
    }
}
