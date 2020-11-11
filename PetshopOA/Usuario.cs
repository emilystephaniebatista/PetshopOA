using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopOA.Shared
{
    public class Usuario
    {
        public int Id { get; set; }
        
        public string Email { get; set; }

        public string Senha { get; set; }

        public int AutorizacaoId { get; set; }
        public Autorizacao Autorizacao { get; set; }
    }
}
