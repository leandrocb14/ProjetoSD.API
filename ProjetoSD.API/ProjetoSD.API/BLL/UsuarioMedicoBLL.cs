using ProjetoSD.API.DAO;
using ProjetoSD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.BLL
{
    public class UsuarioMedicoBLL : ValidacaoBLL
    {
        #region Propriedades
        private UsuarioMedicoDAO UsuarioDAO;
        #endregion

        #region Construtores
        public UsuarioMedicoBLL()
        {
            this.UsuarioDAO = new UsuarioMedicoDAO();
        }
        #endregion

        #region Métodos Publicos
        /// <summary>
        /// Usado para verificar o login do usuário
        /// </summary>
        /// <param name="email">Representa o email do usuário.</param>
        /// <param name="senha">Representa a senha do usuário.</param>
        /// <returns>Retorna o restante das informações desse usuário</returns>
        public int BuscaUsuarioMedico(string email, string senha)
        {
            ValidaParametroEmBrancoOuVazio(email, "email");
            ValidaParametroEmBrancoOuVazio(senha, "senha");
            return this.UsuarioDAO.BuscaUsuarioMedico(email, senha);            
        }

        /// <summary>
        /// Usado para cadastrar um novo usuário.
        /// </summary>        
        /// <param name="email">Representa o email do usuário.</param>
        /// <param name="senha">Representa a senha do usuário.</param>
        public void CadastraUsuario(string crm, string nome, UF uF, string profissao, string email, string senha)
        {
            ValidaParametroEmBrancoOuVazio(crm, "crm");
            ValidaParametroEmBrancoOuVazio(nome, "nome");
            ValidaParametroEmBrancoOuVazio(Convert.ToString(uF), "UF");
            ValidaParametroEmBrancoOuVazio(profissao, "profissao");
            ValidaParametroEmBrancoOuVazio(email, "email");
            ValidaParametroEmBrancoOuVazio(senha, "senha");
            this.UsuarioDAO.CadastraUsuario(crm, nome, uF, profissao, email, senha);
        }

        /// <summary>
        /// Método utilizado para alterar a senha do usuário.
        /// </summary>
        /// <param name="idMedico">Representa o código do usuário na qual se deseja que seja alterado.</param>
        /// <param name="novaSenha">Representa a nova senha do usuário.</param>
        public void AtualizaSenha(int idMedico, string novaSenha)
        {
            ValidaParametroEmBrancoOuVazio(novaSenha, "novaSenha");            
            this.UsuarioDAO.AtualizaSenha(idMedico, novaSenha);
        }

        /// <summary>
        /// Método utilizado para buscar informações do usuário.
        /// </summary>
        /// <param name="idMedico">Representa o código do usuário a ser consultado.</param>
        /// <returns></returns>
        public Medico BuscaInformacoesUsuario(int idMedico)
        {               
            return this.UsuarioDAO.BuscaInformacoesUsuario(idMedico);
        }

        /// <summary>
        /// Método utilizado para alterar os dados da profissão do usuário.
        /// </summary>
        /// <param name="idMedico">Representa o código do usuário a ser consultado.</param>
        /// <param name="novaProfissao">Representa a nova profissão do usuário.</param>
        public void AlterarProfissaoUsuario(int idMedico, string novaProfissao)
        {
            ValidaParametroEmBrancoOuVazio(novaProfissao, "novaProfissao");
            this.UsuarioDAO.AlterarProfissaoUsuario(idMedico, novaProfissao);
        }
        #endregion
    }
}