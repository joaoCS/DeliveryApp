using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class PratoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuentinhaMedia()
        {
            return View();
        }

    }
}
