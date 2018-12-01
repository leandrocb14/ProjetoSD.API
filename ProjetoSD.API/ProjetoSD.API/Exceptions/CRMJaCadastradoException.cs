using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.Exceptions
{
    public class CRMJaCadastradoException : Exception
    {
        public CRMJaCadastradoException(string message) : base(message)
        {

        }
    }
}