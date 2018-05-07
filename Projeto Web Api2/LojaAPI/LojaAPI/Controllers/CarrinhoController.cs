using Loja.DAO;
using Loja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LojaAPI.Controllers
{
    public class CarrinhoController : ApiController
    {
        public HttpResponseMessage Get(int id)
        {
            try
            {
                CarrinhoDAO dao = new CarrinhoDAO();
                Carrinho carrinho = dao.Busca(id);
                return Request.CreateResponse(HttpStatusCode.OK, carrinho);
            }
            catch (KeyNotFoundException)
            {
                string mensagem = string.Format("O carrinho {0} não foi encontrado", id);
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.NotFound, error);
            }

        }

        //FromBody , indica que as informações serão enviadas no corpo
        public HttpResponseMessage Post([FromBody]Carrinho carrinho)
        {
            CarrinhoDAO dao = new CarrinhoDAO();
            dao.Adiciona(carrinho);

            //Resposta Universal HttpResponseMessage (200/400/500 etc)
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
            //Caminho onde a resposta aparecerá, "DefaultAPi" é pois só estamos utilizano uma no projeto, para determinar outras é
            // no App_Start/WebApiConfig.cs
            string location = Url.Link("DefaultApi", new { controller = "carrinho", id = carrinho.Id});
            response.Headers.Location = new Uri(location);

            return response;

        }
    }
}
