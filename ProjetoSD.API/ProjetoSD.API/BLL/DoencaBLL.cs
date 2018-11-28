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
        public void AdicionarDoenca(int idMedico, string oQueEh, string tratamento, string evite)
        {
            ValidaParametroEmBrancoOuVazio(oQueEh, "oQueEh");
            ValidaParametroEmBrancoOuVazio(tratamento, "tratamento");
            ValidaParametroEmBrancoOuVazio(evite, "evite");
            this.DoencaDAO.CadastrarDoenca(idMedico, oQueEh, tratamento, evite);
        }
    }
}