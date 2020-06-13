using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class PratoController : Controller
    {

        private readonly AppDbContext _context;

        public PratoController(AppDbContext context)
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
        public IActionResult QuentinhaMedia(Pedido pedido)
        {

            

            return View();
        }

    }
}
