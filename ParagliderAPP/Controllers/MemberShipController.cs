using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paraglider.DAL;

namespace ParagliderAPP.Controllers
{
    public class MemberShipController : Controller
    {
        private readonly ParagliderContext _context;
        public MemberShipController(ParagliderContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}