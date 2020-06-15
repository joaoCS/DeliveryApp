using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class PedidoController : Controller
    {

        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuentinhaMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult QuentinhaMedia(List<string> carne, List<string> guarnicao, List<string> salada, string nome, string troco, string quantidade, string estado, string cidade, string endereco, string numero)
        {
            Pedido p = new Pedido()
            {
                Atendido = false,
                Cidade = cidade,
                Endereco = endereco,
                Estado = estado,
                Nome = nome,
                Numero = numero,
                Quantidade = Convert.ToInt32(quantidade),
                Preco = Convert.ToInt32(quantidade) * 7,
                Troco = float.Parse(troco, CultureInfo.InvariantCulture.NumberFormat),
            };

            _context.Pedidos.Add(p);

            _context.SaveChanges();


            foreach (var c in carne)
            {
                Carne _carne = new Carne() { Nome = c, PedidoId = p.Id };

                _context.Carnes.Add(_carne);
            }


            _context.SaveChanges();

            foreach (var g in guarnicao)
            {
                Guarnicao _guarnicao = new Guarnicao() { Nome = g, PedidoId = p.Id };

                _context.Guarnicoes.Add(_guarnicao);
            }

            _context.SaveChanges();

            foreach (var s in salada)
            {
                Salada _salada = new Salada() { Nome = s, PedidoId = p.Id };

                _context.Saladas.Add(_salada);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Pedido");
        }

        public IActionResult ListaPedidos()
        {
            List<Pedido> pedidos = _context.Pedidos.ToList();


            return View(pedidos);
        }

    }
}
