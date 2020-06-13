using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public float Preco { get; set; }
        public float Troco { get; set; }
        public bool Atendido { get; set; }
        public int Quantidade { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }

        public virtual ICollection<Carne> Carne { get; set; }
        public virtual ICollection<Guarnicao> Guarnicao { get; set; }
        public virtual ICollection<Salada> Salada { get; set; }

    }
}
