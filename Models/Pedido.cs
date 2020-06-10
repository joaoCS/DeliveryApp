using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int PratoId { get; set; }
        public virtual Prato Prato{ get; set; }
        public float Preco { get; set; }

        public float Troco { get; set; }
        public int Quantidade { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }

    }
}
