using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace PetshopOA.Shared
{
    public class PetshopDto
    {
        public string petshopId { get; set; }
        public string petshopNome { get; set; }

        public string petshopEndereco { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }

    }
}
