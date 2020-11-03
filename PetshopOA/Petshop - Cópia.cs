using System;
using System.Collections.Generic;

namespace PetshopOA.Shared
{
    public class Petshop
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
