using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetshopOA.Shared
{
    public class ContratoDto
    {
        public int Id { get; set; }

        public int Numerocontrato { get; set; }        
        public string FuncionarioId { get; set; }
    }
}
