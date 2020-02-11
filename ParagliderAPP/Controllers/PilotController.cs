using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ParagliderAPP.Controllers
{
    public class PilotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}