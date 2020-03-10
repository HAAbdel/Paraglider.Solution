using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paraglider.DAL;
using Paraglider.sl.Queries;

namespace ParagliderAPP.Controllers
{
    public class ParagliderController : Controller
    {
        private readonly ParagliderContext _context;
        public ParagliderController(ParagliderContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            SimpleParaglider Sp = new SimpleParaglider(_context);
            var model = Sp.GetAllAvalableParagliders();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            DetailedParaglider Sp = new DetailedParaglider(_context);
            var model = Sp.GetSpecificParagliderWithSimpleModel(id);
            return View("Details", model);
        }

    }
}