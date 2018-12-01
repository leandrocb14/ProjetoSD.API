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
        #region Propriedades
        private DoencaDAO DoencaDAO;
        #endregion

        #region Construtores
        public DoencaBLL()
        {
            this.DoencaDAO = new DoencaDAO();
        }
        #endregion

        #region Métodos Publicos
        /// <summary>
        /// Método utilizado para buscar nome da doença.
        /// </summary>
        /// <param name="nomeDoenca">Representa o nome da doença</param>
        /// <returns></returns>
        public List<Doenca> BuscarDoenca(string nomeDoenca)
        {
            ValidaParametroEmBrancoOuVazio(nomeDoenca, "nomeDoenca");
            return DoencaDAO.BuscarDoenca(nomeDoenca);
        }
        /// <summary>
        /// Método utilizado para adicionar uma doença.
        /// </summary>
        /// <param name="idMedico">Representa o código de usuário que descobriu.</param>
        /// <param name="oQueEh">Representa o nome da doença.</param>
        /// <param name="tratamento">Representa as formas para tratar a doença.</param>
        /// <param name="evite">Representa as formas para se evitar a doença</param>
        public void AdicionarDoenca(int idMedico, string oQueEh, string tratamento, string evite)
        {
            ValidaParametroEmBrancoOuVazio(oQueEh, "oQueEh");
            ValidaParametroEmBrancoOuVazio(tratamento, "tratamento");
            ValidaParametroEmBrancoOuVazio(evite, "evite");
            this.DoencaDAO.CadastrarDoenca(idMedico, oQueEh, tratamento, evite);
        }
        #endregion
    }
}