using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.Exceptions
{
    public class MedicoNaoEncontradoException : Exception
    {

        public MedicoNaoEncontradoException(string message) : base(message)
        {

        }
    }
}