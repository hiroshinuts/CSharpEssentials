using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManipulandoArquivosDiretorios
{
    public class Metodos
    {
        public static void Start()
        {
            Metodos metodos = new Metodos();

            // Metodo que chama os demais Metodos
            var caminhoarquivo = metodos.CaminhoDoArquivo();
            var existeArquivo = metodos.ArquivoEncontrado(caminhoarquivo, "txt");

            if (existeArquivo)
            {
                //lista todos os arquvivos a ser lido
                var listaArquivo = metodos.ListaArquivosNoDiretorio(caminhoarquivo, "txt");

                //le Arquivo
                var conteudoArquivo = metodos.LeArquivoSelecionado(caminhoarquivo, listaArquivo[1].ToString());

                //Pega Lista de String e coloca separador

                var linhaComSeparador = metodos.InsereQuebra(conteudoArquivo);
                             
            }
            else
            {
                Console.WriteLine("Nenhum Arquivo foi encontrado");
                Console.Read();
            }

        }

        //Se Encontrar o Arquivo retorna true -- Arquivo na pasta XYZ no Desktop do Usuario
        public string CaminhoDoArquivo()
        {
            //Metodo que acessa o desktop do usuario , Pois o desktop é dinamico Ex: C:/Users/XXXX/Desktop
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            string diretorioSelecionado = Path.Combine(desktop, "C# Essencials\\DiretoriosLerArquivos\\PastaComArquivo\\");

            return diretorioSelecionado;
        }

        //Metodo que retorna se encontrou arquivo
        public bool ArquivoEncontrado(string caminhoArquivo, string extensaoArquivo)
        {
            string nomeArquivo = string.Empty;

            // Busca os arquivos com extensão .txt em todo o diretorio e sub-diretorio
            // SearchOption.AllDirectories = Todos os sub-diretorios entram na busca
            // SearchOption.TopDirectoryOnly = Somente o diretorio atual entra na busca
            //string[] arquivos = Directory.GetFiles(@"C:\", "*.txt", SearchOption.AllDirectories);

            //Passsa o diretorio
            DirectoryInfo diretorio = new DirectoryInfo(caminhoArquivo);
            //Coloca em um Array todos os arquivos no diretorio com a extensao
            FileInfo[] todosArquivos = diretorio.GetFiles(string.Concat("*.", extensaoArquivo));

            if (todosArquivos != null)
            {
                return true;
            }
            else
            {
                return false;
            }

            //Varre o diretorio adicionando no Array
            //foreach (FileInfo file in todosArquivos)
            //{
            //    nomeArquivo = file.Name;
            //}

        }

        public List<string> ListaArquivosNoDiretorio(string caminhoArquivo, string extensaoArquivo)
        {
            List<string> nomeArquivos = new List<string>();

            //Passsa o diretorio
            DirectoryInfo diretorio = new DirectoryInfo(caminhoArquivo);
            //Coloca em um Array todos os arquivos no diretorio com a extensao
            FileInfo[] todosArquivos = diretorio.GetFiles(string.Concat("*.", extensaoArquivo));

            foreach (FileInfo arq in todosArquivos)
            {
                nomeArquivos.Add(arq.ToString());
            }

            return nomeArquivos;
        }

        //Le um arquivo em um diretorio e retorna uma lista com todas as linhas do arquivo
        public List<string> LeArquivoSelecionado(string caminhoDoArquivo, string nomeDoArquivo)
        {
            List<string> listaTodasLinhas = new List<string>();

            var arquivo = string.Concat(caminhoDoArquivo, nomeDoArquivo);

            if (File.Exists(arquivo))
            {
                try
                {
                    using(StreamReader sr = new StreamReader(arquivo))
                    {
                        string linha;
                        while((linha = sr.ReadLine()) != null)
                        {
                            listaTodasLinhas.Add(linha);
                        }

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("O arquivo " + arquivo + "não foi encontrado!");
                Console.ReadKey();
            }


            return listaTodasLinhas;            
        }

        //Separa arquivo tabulado por |
        public List<string> InsereQuebra(List<string> linhaTabulada)
        {
            List<string> listaComPipe = new List<string>();

            string[] colunas;

            foreach (string linha in linhaTabulada)
            {
                colunas = linha.Split("\t");
                var colunaSeparada = string.Join("|", colunas);
                listaComPipe.Add(colunaSeparada);
            }

            return listaComPipe;
        }
        

    }
}
