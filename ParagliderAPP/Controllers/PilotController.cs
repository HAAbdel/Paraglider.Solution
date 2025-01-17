﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParagliderAPP.Models;
using Paraglider.sl;
using Paraglider.sl.Queries;
using Paraglider.DAL;
using Paraglider.sl.DTOs;
using Paraglider.DAL.Models;

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
            IEnumerable<PilotDto> model = null;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(name))
            {
                model = Sp.GetAllPilots();
            }
            else
            {
                model = Sp.GetPilotByName(name);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoleList Rl = new RoleList(_context);
            DetailedPilot Dp = new DetailedPilot(_context);
            PilotAndRoleMergeViewModel myModel = new PilotAndRoleMergeViewModel
            {
                PilotDetail = Dp.GetSpecific(id),
                Roles = Rl.GetAllAvalableRoles()
            };

            // ENVOYER LE VIEWMODEL A LA VUE 
            return View("Edit", myModel);
        }
        [HttpPost]
        public ActionResult Edit(PilotAndRoleMergeViewModel pilotForUpdate )
        {
            //If The role is Default Role so the new role for this pilot will be null
            if (pilotForUpdate.PilotDetail.Role.RoleId == -1)
                pilotForUpdate.PilotDetail.Role = null;

            if (!ModelState.IsValid)
            {
                pilotForUpdate.Roles = new RoleList(_context).GetAllAvalableRoles();
                return View(pilotForUpdate);
            }

            DetailedPilot Sp = new DetailedPilot(_context);
            PilotAndRoleMergeViewModel model = new PilotAndRoleMergeViewModel();

            try
            {
                model.PilotDetail = Sp.UpdatePilot(pilotForUpdate.PilotDetail);
            }
            catch(DbUpdateException exceptionCatched)
            {
                //If the SaveChange() as crashed !  
            }
            //Actualize the Roles
            model.Roles = new RoleList(_context).GetAllAvalableRoles();
            model.PilotDetail = new DetailedPilot(_context).GetSpecific(pilotForUpdate.PilotDetail.Id);

            //Send the model to the View
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            DetailedPilot Dp = new DetailedPilot(_context);
            var model = Dp.GetSpecific(id);
            return View("Details", model);
        }
        [HttpGet]
        public ActionResult Creation ()
        {
            var roles = new RoleList(_context).GetAllAvalableRoles();
            PilotAndRoleMergeViewModel model = new PilotAndRoleMergeViewModel()
            {
                Roles = roles
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Creation(PilotAndRoleMergeViewModel NewPilot)
        {
            if (NewPilot.PilotDetail.Role.RoleId == -1)
                NewPilot.PilotDetail.Role = null;

            PilotDetailDto pilotDtoToCreate = NewPilot.PilotDetail;
            new DetailedPilot(_context).CreateNewPilot(pilotDtoToCreate);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            PilotDetailDto pilotDetailedToRemove = new DetailedPilot(_context).GetSpecific(id);

            if (pilotDetailedToRemove.Role.RoleId == -1)
                pilotDetailedToRemove.Role = null;

            new DetailedPilot(_context).RemovingPilot(pilotDetailedToRemove);

            return RedirectToAction("Index");
        }
        public ActionResult Roles()
        {
            RoleList roleList = new RoleList(_context);
            var model = roleList.GetAllRoles();

            return View(model);
        }
    }
}