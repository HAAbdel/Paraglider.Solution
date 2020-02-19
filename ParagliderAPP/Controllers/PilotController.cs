﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParagliderAPP.Models;
using Paraglider.sl;
using Paraglider.sl.Queries;
using Paraglider.DAL;

namespace ParagliderAPP.Controllers
{
    public class PilotController : Controller
    {
        private readonly ParagliderContext _context;
        public PilotController(ParagliderContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            SimplePilot Sp = new SimplePilot(_context);
            var model = Sp.GetAllPilots();
            return View(model);
        }
        [HttpPost]
        public ViewResult Index(string name)
        {
            SimplePilot Sp = new SimplePilot(_context);
            var model = Sp.GetPilotByName(name);
            return View(model);
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            DetailedPilot Dp = new DetailedPilot(_context);
            var model = Dp.GetSpecific(id);
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Update(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            DetailedPilot Dp = new DetailedPilot(_context);
            var model = Dp.GetSpecific(id);
            return View("Details", model);
        }


    }
      
}