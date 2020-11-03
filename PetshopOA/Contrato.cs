using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetshopOA.Shared
{
    public class Contrato
    {
        public int Id { get; set; }

        public int Numerocontrato { get; set; }

        
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
