using ProjetoSD.API.DAO;
using ProjetoSD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.BLL
{
    public class DoencaBLL : ValidacaoBLL
    {
        private DoencaDAO DoencaDAO;
        public DoencaBLL()
        {
            this.DoencaDAO = new DoencaDAO();
        }

        public List<Doenca> BuscarDoenca(string nomeDoenca)
        {
            ValidaParametroEmBrancoOuVazio(nomeDoenca, "nomeDoenca");
            return DoencaDAO.BuscarDoenca(nomeDoenca);
        }
        public void AdicionarDoenca(string nomeDoenca, string descricao, string profilaxia)
        {
            ValidaParametroEmBrancoOuVazio(nomeDoenca, "nomeDoenca");
            ValidaParametroEmBrancoOuVazio(descricao, "descricao");
            ValidaParametroEmBrancoOuVazio(profilaxia, "profilaxia");
            this.DoencaDAO.CadastrarDoenca(nomeDoenca, descricao, profilaxia);
        }
    }
}