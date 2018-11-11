using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }
        public UF UF { get; set; }
        public string Profissao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Medico()
        {

        }
        public Medico(string cRM, string nome, UF uF, string profissao, Usuario usuario)
        {
            CRM = cRM;
            Nome = nome;
            UF = uF;
            Profissao = profissao;
            this.Usuario = usuario;
        }
    }
}