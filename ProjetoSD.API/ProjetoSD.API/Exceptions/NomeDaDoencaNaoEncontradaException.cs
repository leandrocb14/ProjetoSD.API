using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.Exceptions
{
    public class NomeDaDoencaNaoEncontradaException : Exception
    {
        public NomeDaDoencaNaoEncontradaException(string message) : base(message)
        {

        }
    }
}