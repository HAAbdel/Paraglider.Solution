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
            var PilotDetailDto = _config.Pilots.Select(p => new PilotDetailDto
            {
                Id = p.PilotId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                Weight = p.Weight,
                Role = p.Role,
                TotalHoursFlight = _config.Flights.Where(p => p.PilotId == SearchId).Select(fh => fh.FlightDuration).Sum()
            }).Where(p => p.Id == SearchId).First();

            //If the usedad had no role,  set it  to Default role before  send it to the view
            if(PilotDetailDto.Role == null)
            {
                PilotDetailDto.Role = new Role() { RoleId = -1, RoleName = "Default role" };
            }

            return PilotDetailDto;
        }
        public PilotDetailDto CreateNewPilot(PilotDetailDto NewDtoPilot)//A CHANGER
        {
            //If the role is defaut (-1) set it to null before send it to the DataBase
            if (NewDtoPilot.Role != null && NewDtoPilot.Role.RoleId == -1)
                NewDtoPilot.Role = null;

            //Creating a real pilot to add it to the database
            Pilot NewPilot = new Pilot()
            {
                FirstName = NewDtoPilot.FirstName,
                LastName = NewDtoPilot.LastName,
                Email = NewDtoPilot.Email,
                PhoneNumber = NewDtoPilot.PhoneNumber,
                IsActive = true,
                Weight = NewDtoPilot.Weight,
                Role = null
            };

            //Adding the new pilot to get an id from the db
            _config.Pilots.Add(NewPilot);
            
            _config.SaveChanges();

            NewDtoPilot.Id = NewPilot.PilotId;

            if (NewDtoPilot.Role != null)
            {
                Role roleToAddToThePilot = _config.Roles.Where(r => r.RoleId == NewDtoPilot.Role.RoleId).IgnoreQueryFilters().First();
                AddRoleToPilot(roleToAddToThePilot, NewPilot);
            }

            _config.SaveChanges();

            return NewDtoPilot;
        }
        public PilotDetailDto UpdatePilot(PilotDetailDto pilotDetailDto)
        {
            //GET the pilot from the database to modify it
            //Pilot pilotFromDB = _config.Pilots.Where(p => p.PilotId == pilotDetailDto.Id).First();
            Pilot pilotFromDB = new Pilot();
            pilotFromDB.PilotId = pilotDetailDto.Id;
            pilotFromDB.IsActive = true;
            pilotFromDB.FirstName = pilotDetailDto.FirstName;
            pilotFromDB.LastName = pilotDetailDto.LastName;
            pilotFromDB.Email = pilotDetailDto.Email;
            pilotFromDB.Weight = pilotDetailDto.Weight;
            pilotFromDB.PhoneNumber = pilotDetailDto.PhoneNumber;
            pilotFromDB.Role = _config.Roles.Where(r => r.PilotId == pilotFromDB.PilotId).IgnoreQueryFilters().FirstOrDefault();
            if(pilotFromDB.Role != null)
                pilotFromDB.RoleId = pilotFromDB.Role.RoleId;

            //GET the previus pilot role if he had one
            if (pilotFromDB.RoleId != null)
                pilotFromDB.Role = _config.Roles.Where(r => r.RoleId == pilotFromDB.RoleId).IgnoreQueryFilters().First();
            //GET the new pilot role if he is asking for one
            if(pilotDetailDto.Role != null)
                pilotDetailDto.Role = _config.Roles.Where(r => r.RoleId == pilotDetailDto.Role.RoleId).IgnoreQueryFilters().First();

            RoleModificationManager(pilotDetailDto.Role, pilotFromDB);

            _config.SaveChanges();

            return pilotDetailDto;
        }
        public void RemovingPilot(PilotDetailDto pilotDetailDto)
        {
            Pilot pilotFromDB = _config.Pilots.Where(p => p.PilotId == pilotDetailDto.Id).IgnoreQueryFilters().First();
            //GET the pilot role (if he had once)
            if(pilotDetailDto.Role != null)
            {
                RemoveRoleFromPilot(pilotFromDB.Role);
            }
            pilotFromDB.IsActive = false;
            pilotFromDB.Role = null;
            pilotFromDB.RoleId = null;

            _config.Pilots.Update(pilotFromDB);

            _config.SaveChanges();
        }

        private void RoleModificationManager(Role pRoleToSetActive,Pilot pPilotFromDb)
        {
            //If the pilot had NO role before
            if(pPilotFromDb.Role == null)
            {
                //If the pilot is going to have a new role
                if(pRoleToSetActive != null)
                {
                    //Changing only the new role on the database
                    AddRoleToPilot(pRoleToSetActive, pPilotFromDb);
                }
                //If the pilot NO role and don't want one
            }
            else
            {
                //If the pilot is going to have a new role
                if (pRoleToSetActive != null)
                {
                    if (pRoleToSetActive.RoleId != pPilotFromDb.RoleId)
                    {
                        //Setting the role before to NOT ative and setting the new role to active and link the role to the pilot and the piot to the role
                        AddRoleToPilot(pRoleToSetActive, pPilotFromDb);

                        RemoveRoleFromPilot(pPilotFromDb.Role);
                    }
                    else
                    {
                        //If The pilot is keeping the same role as before
                    }
                }
                else
                {
                    //The pilot had a role and setting it to null
                    RemoveRoleFromPilot(pPilotFromDb.Role);
                }
            }
        }
        private void RemoveRoleFromPilot(Role pRoleToRemove)
        {
            pRoleToRemove.IsActive = false;
            pRoleToRemove.PilotId = 0;
            pRoleToRemove.Pilot = null;

            _config.Roles.Update(pRoleToRemove);
        }
        private void AddRoleToPilot(Role pRoleToAdd,Pilot pPilotToAddTheRole)
        {
            pRoleToAdd.IsActive = true;
            pRoleToAdd.PilotId = pPilotToAddTheRole.PilotId;
            pRoleToAdd.Pilot = pPilotToAddTheRole;//A VÉRIFIER SI UTILSE !!!
            _config.Roles.Update(pRoleToAdd);
        }
    }
}
