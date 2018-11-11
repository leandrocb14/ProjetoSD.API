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
        /// Usado para verificar a existencia da solicitação de login.
        /// </summary>
        /// <param name="email">Representa o email do usuário.</param>
        /// <param name="senha">Representa a senha do usuário.</param>
        /// <returns></returns>
        public Medico BuscaUsuarioMedico(string email, string senha)
        {
            var query = from u in EntidadeContext.Usuarios
                        join m in EntidadeContext.Medicos on u.Id equals m.UsuarioId
                        where u.Email.Equals(email) && u.Senha.Equals(senha)
                        select new Medico
                        {
                            Id = m.Id,
                            CRM = m.CRM,
                            Nome = m.Nome,
                            UF = m.UF,
                            Profissao = m.Profissao,
                            UsuarioId = m.UsuarioId,
                            Usuario = u
                        };
            Medico Medico = query.FirstOrDefault();
            if (Medico == null)
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

        public void AtualizaSenha(int? id, string novaSenha)
        {
            var query = from u in EntidadeContext.Usuarios
                        where u.Id.Equals(id)
                        select u;
            if (query == null)
            {
                throw new ArgumentException("Não existe um usuário com esse id!");
            }
            Usuario usuario = query.FirstOrDefault();
            usuario.Senha = novaSenha;
            EntidadeContext.SaveChanges();
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
    }
}