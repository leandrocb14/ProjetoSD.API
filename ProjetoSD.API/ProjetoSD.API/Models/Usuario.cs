using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoStatus TipoStatus { get; set; }

        public Medico Medico { get; set; }

        public Usuario()
        {

        }
        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
        public Usuario(string email, string senha, Medico medico) : this(email, senha)
        {
            this.Medico = medico;
        }
        public Usuario(int id, string email, TipoStatus tipoStatus)
        {
            this.Id = id;
            this.Email = email;
            this.TipoStatus = tipoStatus;
        }
    }
}