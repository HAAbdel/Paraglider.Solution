using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paraglider.DAL;
using Paraglider.sl.Queries;

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
            MemberShipList MSL = new MemberShipList(_context);
            var model = MSL.GetAllAvalable();
            return View(model);
        }
    }
}