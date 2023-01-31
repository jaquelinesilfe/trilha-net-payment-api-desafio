using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio_api_payment.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Quantidade { get; set; }

        public int VendaId { get; set; }
    }
}