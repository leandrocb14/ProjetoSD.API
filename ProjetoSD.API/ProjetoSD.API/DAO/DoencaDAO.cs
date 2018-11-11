using ProjetoSD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.DAO
{
    public class DoencaDAO
    {
        private EntidadeContext EntidadeContext;
        public DoencaDAO()
        {
            this.EntidadeContext = new EntidadeContext();
        }

        public List<Doenca> BuscarDoenca(string nomeDoenca)
        {
            var query = from d in EntidadeContext.Doencas
                        where d.Nome.Contains(nomeDoenca)
                        select d;
            if (query.Count() == 0)
            {
                throw new ArgumentException("Não existe nenhuma doença com esse nome.");
            }
            return query.ToList();
        }
        public void CadastrarDoenca(string nomeDoenca, string descricao, string profilaxia)
        {
            this.EntidadeContext.Doencas.Add(new Doenca(nomeDoenca, descricao, profilaxia));
            this.EntidadeContext.SaveChanges();
        }
    }
}