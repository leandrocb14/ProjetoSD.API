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
    public class DoencaController : ApiController
    {
        private DoencaBLL DoencaBLL;
        public DoencaController()
        {
            this.DoencaBLL = new DoencaBLL();
        }
        [HttpGet]
        public HttpResponseMessage BuscaPorNome(string nomeDoenca = "")
        {
            try
            {
                List<Doenca> doencas = this.DoencaBLL.BuscarDoenca(nomeDoenca);
                return Request.CreateResponse(HttpStatusCode.OK, doencas);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage Adiciona(int idMedico = 0, string oQueEh = "", string tratamento = "", string evite = "")
        {
            try
            {
                this.DoencaBLL.AdicionarDoenca(idMedico, oQueEh, tratamento, evite);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}