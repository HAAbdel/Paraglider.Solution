using Microsoft.EntityFrameworkCore;
using Paraglider.DAL;
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
            var Pilot = _config.Pilots.Select(p => new PilotDetailDto 
                { 
                Id = p.PilotId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                Weight = p.Weight,
                Role = p.Role 
                }).Where(p => p.Id == SearchId).First();

            if(Pilot.Role == null)
            {
                Pilot.Role = new Role() { RoleId = -1, RoleName = "Default role" };
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
        public PilotAndRoleMergeViewModel UpdatePilot(PilotAndRoleMergeViewModel pilotDetailDto)
        {
            RoleModificationManager(pilotDetailDto);

            //Récupérer le pilot de la base de données pour le modifier !
            Pilot pilotForUpdate = _config.Pilots.Where(p => p.PilotId == pilotDetailDto.PilotDetail.Id).First();
            pilotForUpdate.FirstName = pilotDetailDto.PilotDetail.FirstName;
            pilotForUpdate.LastName = pilotDetailDto.PilotDetail.LastName;
            pilotForUpdate.Email = pilotDetailDto.PilotDetail.Email;
            pilotForUpdate.Weight = pilotDetailDto.PilotDetail.Weight;
            pilotForUpdate.PhoneNumber = pilotDetailDto.PilotDetail.PhoneNumber;

            _config.SaveChanges();

            return pilotDetailDto;
        }

        private void RoleModificationManager(PilotAndRoleMergeViewModel pilotDetailDto)
        {
            //Get the PILOT role before the modification
            PilotDetailDto pilotBeforeModification = new DetailedPilot(_config).GetSpecific(pilotDetailDto.PilotDetail.Id);//A modifier car trop de requestes à la base de données
            
            //Determinate if the role has been modified
            if (pilotBeforeModification.Role.RoleId != pilotDetailDto.PilotDetail.Role.RoleId)
            {
                //If the PILOT had a role before
                //Define the previus pilotId to 0,the Pilot to null, the Avtice to false and Updating 
                if (pilotBeforeModification.Role.RoleId != -1)
                {
                    Role PreviusRole = _config.Roles.Where(r => r.RoleId == pilotBeforeModification.Role.RoleId).IgnoreQueryFilters().First();
                    PreviusRole.IsActive = false;
                    PreviusRole.PilotId = 0;
                    PreviusRole.Pilot = null;
                    _config.Roles.Update(PreviusRole);
                }
                //If the PILOT is going for the DEFAULT ROLE
                if (pilotDetailDto.PilotDetail.Role.RoleId == 0)
                {
                    pilotDetailDto.PilotDetail.Role = null;
                }
                //If the PILOT is getting the new role and this role is modified on the DB
                else
                {
                    Role NewRole = _config.Roles.Where(r => r.RoleId == pilotDetailDto.PilotDetail.Role.RoleId).IgnoreQueryFilters().First();
                    NewRole.IsActive = true;
                    NewRole.PilotId = pilotDetailDto.PilotDetail.Id;
                    NewRole.Pilot = _config.Pilots.Where(p => p.PilotId == pilotDetailDto.PilotDetail.Id).First();
                    _config.Roles.Update(NewRole);
                }
                //_config.SaveChanges(); //Ajouter si cette methode est utilisé autre part que dans cette classe
            }
        }
    }
}
