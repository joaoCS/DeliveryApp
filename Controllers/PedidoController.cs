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

        public IActionResult QuentinhaGrande()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FazerPedido(List<string> carne, List<string> guarnicao, List<string> salada, Pedido pedido)
        {
            if(pedido.Nome == "Quentinha Media")
                pedido.Preco = 7 * pedido.Quantidade;
            else if (pedido.Nome == "Quentinha Grande")
                pedido.Preco = 10 * pedido.Quantidade;

            _context.Pedidos.Add(pedido);

            _context.SaveChanges();


            foreach (var c in carne)
            {
                Carne _carne = new Carne() { Nome = c, PedidoId = pedido.Id };

                _context.Carnes.Add(_carne);
            }


            _context.SaveChanges();

            foreach (var g in guarnicao)
            {
                Guarnicao _guarnicao = new Guarnicao() { Nome = g, PedidoId = pedido.Id };

                _context.Guarnicoes.Add(_guarnicao);
            }

            _context.SaveChanges();

            foreach (var s in salada)
            {
                Salada _salada = new Salada() { Nome = s, PedidoId = pedido.Id };

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

        public IActionResult Detalhes(int id)
        {
            Pedido p = _context.Pedidos.Find(id);


            List<Carne> carnes = _context.Carnes.Where(c => c.PedidoId == p.Id).ToList();

            List<Guarnicao> guarnicoes = _context.Guarnicoes.Where(g => g.PedidoId == p.Id).ToList();

            List<Salada> saladas = _context.Saladas.Where(s => s.PedidoId == p.Id).ToList();

            p.Carne = carnes;
            p.Guarnicao = guarnicoes;
            p.Salada = saladas;

            return View(p);
        }

        public IActionResult MarcarAtendido(int id)
        {
            Pedido pedido = _context.Pedidos.Find(id);

            pedido.Atendido = true;

            _context.Update(pedido);
            _context.SaveChanges();

            return RedirectToAction("Detalhes", "Pedido", new { id = id });
        }
    }
}
