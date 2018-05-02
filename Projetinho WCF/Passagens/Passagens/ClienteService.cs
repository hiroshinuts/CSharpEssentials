using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passagens
{
    public class ClienteService : IClienteService
    {
        //WINDOWS FORM
        //public void Add(Cliente c)
        //{
        //    ClienteDao dao = new ClienteDao();
        //    dao.Add(c);
        //}

        //ACESSAR VIA NAVEGADOR
        public bool Add(string nome, string cpf)
        {
            Cliente c = new Cliente();
            c.Nome = nome;
            c.Cpf = cpf;
            ClienteDao dao = new ClienteDao();
            dao.Add(c);

            return true;
        }

        //WINDOWS FORM
        //public Cliente Buscar(string nome)
        //{
        //    ClienteDao dao = new ClienteDao();
        //    return dao.Buscar(nome);
        //}

        //ACESSAR VIA NAVEGADOR
        public Cliente Buscar(string nome)
        {
            ClienteDao dao = new ClienteDao();
            return dao.Buscar(nome);
        }

        public List<Cliente> getClientes()
        {
            return ClienteDao.clientes;
        }

    }
}
