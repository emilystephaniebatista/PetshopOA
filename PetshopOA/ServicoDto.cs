using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopOA.Shared
{
    public class ServicoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string FuncionarioId { get; set; }        
        public string ClienteId { get; set; }

    }
}
