using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Passagens
{
    [DataContract] //Deve informar a classe com o DataContract -- Dados que irão ser trafegados
    public class Cliente
    {
        [DataMember] //Informar como o cliente irá trafegar
        public string Nome { get; set; }

        [DataMember]
        public string Cpf { get; set; }
    }
}
