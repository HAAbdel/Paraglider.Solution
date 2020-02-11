using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParagliderAPP.Models;



namespace ParagliderAPP.Controllers
{
    public class PilotController : Controller
    {
        private IPilotRepository _pilotRepository;

        public PilotController(IPilotRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }
        public ViewResult Index()
        {
            
           var model =_pilotRepository.GetAllPilot();
            return View(model);

        }

        public ActionResult ModalPopUp()
        {
            return View();
        }
    }
}