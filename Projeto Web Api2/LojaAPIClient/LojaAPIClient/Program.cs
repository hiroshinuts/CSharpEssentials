﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://localhost:51257/api/carrinho/1/produto/6237/quantidade");
            request.Method = "PUT";

            string xml = "<Produto xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Id>6237</Id><Nome>Videogame 4</Nome><Preco>4000</Preco><Quantidade>10</Quantidade></Produto>";
            byte[] xmlytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlytes, 0, xml.Length);
            request.ContentType = "application/xml";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.Read();
        }

        static void TestaDelete()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51257/api/carrinho/1/produto/3467");
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.Read();
        }

        static void TestaPost2()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51257/api/carrinho/1");
            request.Method = "POST";
            request.Accept = "application/xml";

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Endereco>Rua Vergueiro 3185, 8 andar, Sao Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>6237</Id><Nome>PostXml</Nome><Preco>1000</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlytes, 0, xml.Length);
            request.ContentType = "application/xml";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["location"]);
            Console.Read();
        }

        static void TestaGet()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51257/api/carrinho/1");
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.WriteLine(conteudo);
            Console.Read();
        }

        static void TestaGetXml()
        {
              string conteudo;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://localhost:51257/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.WriteLine(conteudo);
            Console.Read();
        }

        static void TestaGetJson()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51257/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.WriteLine(conteudo);
            Console.Read();
        }

        static void TestaPostJson()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51257/api/carrinho/1");
            request.Method = "POST";
            request.Accept = "application/json";

            string json = "{'Produtos':[{'Id':6237,'Preco':4000.0,'Nome':'Xbox','Quantidade':4}],'Endereco':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':5}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonBytes, 0, json.Length);
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.WriteLine(conteudo);
            Console.Read();
        }

        static void TestaPostXml()
        {
            string conteudo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:51257/api/carrinho/1");
            request.Method = "POST";
            request.Accept = "application/xml";

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Endereco>Rua Vergueiro 3185, 8 andar, Sao Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>6237</Id><Nome>PostXml</Nome><Preco>1000</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlytes, 0, xml.Length);
            request.ContentType = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }
            Console.WriteLine(conteudo);
            Console.Read();
        }

    }
}
