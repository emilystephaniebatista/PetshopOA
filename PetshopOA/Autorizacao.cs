using System;
using System.Collections.Generic;
using System.Text;

namespace PetshopOA.Shared
{
    public class Autorizacao
    {
        public int Id { get; set; }
        public int CadastrarAnimal { get; set; }
        public int EditarAnimal { get; set; }
        public int ExcluirAnimal { get; set; }
        public int VerAnimal { get; set; }
        public int CadastrarPetshop { get; set; }
        public int CadastrarServico { get; set; }
        public int CadastrarContraatos { get; set; }
        public int CadastrarFuncionario { get; set; }

    }
}
