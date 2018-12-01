using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.Exceptions
{
    public class CampoNullOuVazioException : Exception
    {
        public CampoNullOuVazioException(string message) : base(message)
        {

        }
    }
}