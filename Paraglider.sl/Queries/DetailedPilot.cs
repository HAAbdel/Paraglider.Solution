﻿using Paraglider.DAL;
using Paraglider.DAL.Models;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    public class DetailedPilot
    {
        private readonly ParagliderContext _config;

        public DetailedPilot(ParagliderContext config)
        {
            _config = config;
        }
        public PilotDetailDto GetSpecific(int SearchId)
        {
            var Pilot = _config.Pilots.Select(p => new PilotDetailDto { Id = p.PilotId, FirstName = p.FirstName, LastName = p.LastName, PhoneNumber = p.PhoneNumber, Email = p.Email, Weight = p.Weight, Role = p.Role })
                .Where(p => p.Id == SearchId).First();
            if(Pilot.Role ==null)
            {
                Pilot.Role = new Role() { RoleId = -1, RoleName = "None" };
            }
            return Pilot;
        }
        public bool SetNewPilot(PilotDetailDto NewDtoPilot)
        {
            _config.Pilots.Add(new Pilot()
            {
                FirstName = NewDtoPilot.FirstName,
                LastName = NewDtoPilot.LastName,
                Email = NewDtoPilot.Email,
                PhoneNumber = NewDtoPilot.PhoneNumber,
                IsActive = true,
                Weight = NewDtoPilot.Weight,
                RoleId = null
            });
            _config.SaveChanges();
            
            return true;
        }
    }
}