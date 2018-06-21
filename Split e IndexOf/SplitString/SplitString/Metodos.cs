using System;
using System.Collections.Generic;
using System.Text;

namespace SplitString
{
    public class Metodos
    {
        
        public string SplitaString()
        {

            string header = "A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|Y|Z";

            string[] palavrasExplitadas = header.Split('|');

            List<string> listaDasLetrasSplitadas = new List<string>();

            foreach (var item in palavrasExplitadas)
            {
                listaDasLetrasSplitadas.Add(item);
            }

            var abc = listaDasLetrasSplitadas;

            //Resultado = 1
            string LetraTargetIndex = "B";

            var resultado = listaDasLetrasSplitadas.IndexOf(LetraTargetIndex).ToString();

            return resultado;
        }

    }
}
