using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopOA.Shared
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string AutorizacaoId { get; set; }
    }
}
