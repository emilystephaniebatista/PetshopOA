using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopOA.Shared
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Numeroidentificacao { get; set; }

        public Contrato Contrato { get; set; }
    }
}


