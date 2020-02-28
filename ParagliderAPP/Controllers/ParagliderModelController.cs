using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paraglider.DAL;
using Paraglider.sl.Queries;
namespace ParagliderAPP.Controllers
{
    public class ParagliderModelController : Controller
    {
        private readonly ParagliderContext _context;
        public ParagliderModelController(ParagliderContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var SPM = new SimpleParagliderModel(_context);
            var model = SPM.GetAllAvalabelParagliderModels();
            return View(model);
        }
    }
}