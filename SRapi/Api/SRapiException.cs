using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRapi.Api
{
    public class SRapiException : Exception
    {
        public SRapiException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
