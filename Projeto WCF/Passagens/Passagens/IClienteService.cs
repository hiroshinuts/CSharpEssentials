using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Passagens
{
    [ServiceContract] //Contrato do WCF
    public interface IClienteService
    {
        //WINDOWS FORM
        //[OperationContract] //Todos os metódos devem seguir o contrato do WCF
        //Cliente Buscar(string nome);

        //WINDOWS FORM
        //[OperationContract]
        //void Add(Cliente c);

        //WEB VIA NAVEGADOR
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "getClientes/")]
        List<Cliente> getClientes();

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "SearchCliente/{nome}" )]
        [OperationContract] //Todos os metódos devem seguir o contrato do WCF
        Cliente Buscar(string nome);

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "addCliente/{nome};{cpf}")]
        [OperationContract]
        bool Add(string nome, string cpf);

    }
}
