using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Salada
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
