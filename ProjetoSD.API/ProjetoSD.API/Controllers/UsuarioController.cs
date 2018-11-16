using ProjetoSD.API.BLL;
using ProjetoSD.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace ProjetoSD.API.Controllers
{
    public class UsuarioController : ApiController
    {
        private UsuarioMedicoBLL UsuarioMedicoBLL;

        public UsuarioController()
        {
            this.UsuarioMedicoBLL = new UsuarioMedicoBLL();
        }

        [HttpPost]
        public HttpResponseMessage ValidaLogin(string email = "", string senha = "")
        {
            try
            {
                int CodeUser = this.UsuarioMedicoBLL.BuscaUsuarioMedico(email, senha);
                return Request.CreateResponse(HttpStatusCode.OK, CodeUser);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage CadastraUsuario(string crm = "", string nome = "", UF uF = UF.AC, string profissao = "", string email = "", string senha = "")
        {
            try
            {
                this.UsuarioMedicoBLL.CadastraUsuario(crm, nome, uF, profissao, email, senha);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }        
    }
}