﻿using ProjetoSD.API.DAO;
using ProjetoSD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.BLL
{
    public class UsuarioMedicoBLL : ValidacaoBLL
    {
        private UsuarioMedicoDAO UsuarioDAO;

        public UsuarioMedicoBLL()
        {
            this.UsuarioDAO = new UsuarioMedicoDAO();
        }

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

        public void AtualizaSenha(int idUsuario, string novaSenha)
        {
            ValidaParametroEmBrancoOuVazio(novaSenha, "novaSenha");            
            this.UsuarioDAO.AtualizaSenha(idUsuario, novaSenha);
        }

        public Medico BuscaInformacoesUsuario(int idMedico)
        {               
            return this.UsuarioDAO.BuscaInformacoesUsuario(idMedico);
        }

        public void AlterarProfissaoUsuario(int idMedico, string novaProfissao)
        {
            ValidaParametroEmBrancoOuVazio(novaProfissao, "novaProfissao");
            this.UsuarioDAO.AlterarProfissaoUsuario(idMedico, novaProfissao);
        }
    }
}