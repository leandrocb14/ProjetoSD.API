using ProjetoSD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSD.API.DAO
{
    public class UsuarioMedicoDAO
    {
        private EntidadeContext EntidadeContext;

        public UsuarioMedicoDAO()
        {
            this.EntidadeContext = new EntidadeContext();
        }

        /// <summary>
        /// Verifica se email já é cadastrado.
        /// </summary>
        /// <exception cref="ArgumentException">Exception lançada quando o parâmetro <paramref name="email"/> já for cadastrado.</exception>
        /// <param name="email">Representa o email a ser analisado.</param>
        private void VerificaSeEmailEhCadastrado(string email)
        {
            var query = from q in EntidadeContext.Usuarios
                        where q.Email.Equals(email)
                        select q;
            if (query.FirstOrDefault() != null)
            {
                throw new ArgumentException("O email já está cadastrado para um usuário!");
            }
        }
        #region Métodos refatorados
        /// <summary>
        /// Verifica se <paramref name="crm"/> já está em uso.
        /// </summary>
        /// <exception cref="ArgumentException">Exception lançada quando é verificado que o parametro <paramref name="crm"/> está em uso.</exception>
        /// <param name="crm">Representa o crm a ser analisado.</param>
        private void VerificaSeCRMEhCadastrado(string crm)
        {
            var query = from q in EntidadeContext.Medicos
                        where q.CRM.Equals(crm)
                        select q;
            if (query.FirstOrDefault() != null)
            {
                throw new ArgumentException("O CRM já está cadastrado para um usuário!");
            }
        }

        private Medico BuscaMedico(int idMedico)
        {
            var query = from m in EntidadeContext.Medicos
                        where m.Id.Equals(idMedico)
                        select m;
            var medico = query.FirstOrDefault();
            if (medico == null)
            {
                throw new ArgumentException("Usuário não encontrados!");
            }
            return medico;
        }
        private Usuario BuscaUsuario(int idUsuario)
        {
            var query = from u in EntidadeContext.Usuarios
                        where u.Id.Equals(idUsuario)
                        select u;
            var usuario = query.FirstOrDefault();
            if (usuario == null)
            {
                throw new ArgumentException("Usuário não encontrado!");
            }
            return usuario;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Usado para verificar a existencia da solicitação de login.
        /// </summary>
        /// <param name="email">Representa o email do usuário.</param>
        /// <param name="senha">Representa a senha do usuário.</param>
        /// <returns></returns>
        public int BuscaUsuarioMedico(string email, string senha)
        {
            var query = from u in EntidadeContext.Usuarios
                        join m in EntidadeContext.Medicos on u.Id equals m.UsuarioId
                        where u.Email.Equals(email) && u.Senha.Equals(senha)
                        select m.UsuarioId;
            int UserCode = query.FirstOrDefault();
            if (UserCode == 0)
            {
                throw new NullReferenceException("Usuário não encontrado.");
            }
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Usado para cadastrar um usuário.
        /// </summary>
        /// <param name="email">Representa o email do usuário.</param>
        /// <param name="senha">Representa a senha do usuário.</param>
        public void CadastraUsuario(string crm, string nome, UF uF, string profissao, string email, string senha)
        {
            VerificaSeCRMEhCadastrado(crm);
            VerificaSeEmailEhCadastrado(email);
            this.EntidadeContext.Medicos.Add(new Medico(crm, nome, uF, profissao, new Usuario(email, senha)));
            this.EntidadeContext.SaveChanges();
        }

        public void AtualizaSenha(int idUsuario, string novaSenha)
        {
            var usuario = BuscaUsuario(idUsuario);
            usuario.Senha = novaSenha;
            EntidadeContext.SaveChanges();
        }               

        public Medico BuscaInformacoesUsuario(int idMedico)
        {
            var query = from m in EntidadeContext.Medicos
                        join u in EntidadeContext.Usuarios on m.UsuarioId equals u.Id
                        where m.Id.Equals(idMedico)
                        select new Medico
                        {
                            Id = m.Id,
                            CRM = m.CRM,
                            Nome = m.Nome,
                            UF = m.UF,
                            Profissao = m.Profissao,
                            UsuarioId = m.UsuarioId,
                            Usuario = new Usuario()
                            {
                                Id = u.Id,
                                Email = u.Email
                            }
                        };
            var medico = query.FirstOrDefault();
            if (medico == null)
            {
                throw new ArgumentException("Usuário não encontrados!");
            }
            return medico;
        }
        public void AlterarProfissaoUsuario(int idMedico, string novaProfissao)
        {
            var medico = BuscaMedico(idMedico);
            medico.Profissao = novaProfissao;
            EntidadeContext.SaveChanges();
        }
        #endregion
    }
}