using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.Exceptions
{
    public class EmailJaCadastradoException : Exception
    {
        public EmailJaCadastradoException(string message) : base(message)
        {

        }
    }
}