using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopOA.Shared
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public string Numeroidentificacao { get; set; }


        public int PetshopId { get; set; }
        public Petshop Petshop { get; set; }
    }
}
