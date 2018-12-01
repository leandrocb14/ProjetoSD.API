using ProjetoSD.API.Exceptions;
using ProjetoSD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.DAO
{
    public class DoencaDAO
    {
        #region Propriedades
        private EntidadeContext EntidadeContext;
        #endregion

        #region Construtores
        public DoencaDAO()
        {
            this.EntidadeContext = new EntidadeContext();
        }
        #endregion

        #region Métodos Publicos
        public List<Doenca> BuscarDoenca(string nomeDoenca)
        {
            var query = from d in EntidadeContext.Doencas
                        where d.Nome.Contains(nomeDoenca)
                        select d;
            if (query.Count() == 0)
            {
                throw new NomeDaDoencaNaoEncontradaException("Não existe nenhuma doença com esse nome.");
            }
            return query.ToList();
        }
        public void CadastrarDoenca(int idMedico, string oQueEh, string tratamento, string evite)
        {
            this.EntidadeContext.Doencas.Add(new Doenca(idMedico, oQueEh, tratamento, evite));
            this.EntidadeContext.SaveChanges();
        }
        #endregion
    }
}