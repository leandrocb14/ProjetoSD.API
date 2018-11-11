using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.Models
{
    public class Doenca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Profilaxia { get; set; }
        public TipoStatus TipoStatus { get; set; }

        public Doenca()
        {

        }

        public Doenca(string nome, string descricao, string profilaxia)
        {
            Nome = nome;
            Descricao = descricao;
            Profilaxia = profilaxia;
        }
    }
}