using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParagliderAPP.Models;

namespace ParagliderAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Pilot()
        {
            return RedirectToAction("Index", "Pilot");
        }
        public IActionResult Paraglider()
        {
            return RedirectToAction("Index", "Paraglider");
        }
        public IActionResult ParagliderModel()
        {
            return RedirectToAction("Index","ParagliderModel");
        }
        public IActionResult MemberShip()
        {
            return RedirectToAction("Index", "MemberShip");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
