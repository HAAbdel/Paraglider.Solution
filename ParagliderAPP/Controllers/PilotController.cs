using System;
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
            var model = Sp.GetPilotByName(name);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            // FAIRE LE BINDING AU MODEL 
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
            DetailedPilot Sp = new DetailedPilot(_context);
            PilotDetailDto pilotBeforeModification = new DetailedPilot(_context).GetSpecific(pilotForUpdate.PilotDetail.Id);//A modifier car trop de requestes à la base de données
            //Si le pilot a changé de role
            if(pilotBeforeModification.Role.RoleId != pilotForUpdate.PilotDetail.Role.RoleId)
            {
                //Si le pilot avait un role avant
                if (pilotBeforeModification.Role.RoleId != -1)
                {
                    Role PreviusRole = _context.Roles.Where(r => r.RoleId == pilotBeforeModification.Role.RoleId).IgnoreQueryFilters().First();
                    PreviusRole.IsActive = false;
                    PreviusRole.PilotId = 0;
                    PreviusRole.Pilot = null;
                    _context.Roles.Update(PreviusRole);
                }
                //Si va vers le role par defaut
                if (pilotForUpdate.PilotDetail.Role.RoleId == 0)
                {
                    pilotForUpdate.PilotDetail.Role = null;
                }
                else
                {
                    Role NewRole = _context.Roles.Where(r => r.RoleId == pilotForUpdate.PilotDetail.Role.RoleId).IgnoreQueryFilters().First();
                    NewRole.IsActive = true;
                    NewRole.PilotId = pilotForUpdate.PilotDetail.Id;
                    NewRole.Pilot = _context.Pilots.Where(p => p.PilotId == pilotForUpdate.PilotDetail.Id).First();
                    _context.Roles.Update(NewRole);
                }
                _context.SaveChanges();
            }

            //--------------------------------------
            //Role tempRole = _context.Roles.Where(r => r.RoleId == pilotForUpdate.PilotDetail.Role.RoleId).IgnoreQueryFilters().First();
            //tempRole.IsActive = true;
            //_context.Roles.Update(tempRole);
            PilotAndRoleMergeViewModel model = Sp.UpdatePilot(pilotForUpdate);
            pilotForUpdate.Roles = new RoleList(_context).GetAllAvalableRoles();
            pilotForUpdate.PilotDetail = new DetailedPilot(_context).GetSpecific(pilotForUpdate.PilotDetail.Id);
            return View(model);
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