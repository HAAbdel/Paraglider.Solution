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

            //Adding the new pilot without role (we add it later)
            _config.Pilots.Add(NewPilot);
            
            NewDtoPilot.Id = NewPilot.PilotId;
            if (NewDtoPilot.Role != null)
                AddRoleToPilot(NewDtoPilot.Role.RoleId,NewPilot);

            _config.SaveChanges();

            return NewDtoPilot;
        }
        public PilotAndRoleMergeViewModel UpdatePilot(PilotAndRoleMergeViewModel pilotDetailDto)
        {
            //GET the pilot from the database to modify it
            Pilot pilotFromDB = _config.Pilots.Where(p => p.PilotId == pilotDetailDto.PilotDetail.Id).First();
            pilotFromDB.FirstName = pilotDetailDto.PilotDetail.FirstName;
            pilotFromDB.LastName = pilotDetailDto.PilotDetail.LastName;
            pilotFromDB.Email = pilotDetailDto.PilotDetail.Email;
            pilotFromDB.Weight = pilotDetailDto.PilotDetail.Weight;
            pilotFromDB.PhoneNumber = pilotDetailDto.PilotDetail.PhoneNumber;

            //GET the previus pilot role if he had one
            if(pilotFromDB.RoleId != null)
                pilotFromDB.Role = _config.Roles.Where(r => r.RoleId == pilotFromDB.RoleId).IgnoreQueryFilters().First();
            //GET the new pilot role if he is asking for one
            if(pilotDetailDto.PilotDetail.Role != null)
                pilotDetailDto.PilotDetail.Role = _config.Roles.Where(r => r.RoleId == pilotDetailDto.PilotDetail.Role.RoleId).IgnoreQueryFilters().First();

            RoleModificationManager(pilotDetailDto.PilotDetail, pilotFromDB);

            _config.SaveChanges();

            return pilotDetailDto;
        }
        public void RemovingPilot(PilotDetailDto pilotDetailDto)
        {
            Pilot pilotFromDB = _config.Pilots.Where(p => p.PilotId == pilotDetailDto.Id).IgnoreQueryFilters().First();
            //GET the pilot role (if he had once)
            if(pilotDetailDto.Role != null)
            {
                RemoveRoleFromPilot(pilotDetailDto.Role.RoleId,pilotFromDB);
            }
            pilotFromDB.IsActive = false;
            pilotFromDB.Role = null;
            pilotFromDB.RoleId = null;

            _config.Pilots.Update(pilotFromDB);

            _config.SaveChanges();
        }

        private void RoleModificationManager(PilotDetailDto pPilotDetailDto,Pilot pPilotFromDb)
        {
            //If the pilot had NO role before
            if(pPilotFromDb.Role == null)
            {
                //If the pilot is going to have a new role
                if(pPilotDetailDto.Role != null)
                {
                    //Changing only the new role on the database
                    Role roleToSetActive = _config.Roles.Where(r => r.RoleId == pPilotDetailDto.Role.RoleId).IgnoreQueryFilters().First();
                    roleToSetActive.IsActive = true;
                    roleToSetActive.PilotId = pPilotFromDb.PilotId;
                    roleToSetActive.Pilot = pPilotFromDb;

                    _config.Roles.Update(roleToSetActive);

                    //_config.SaveChanges();
                }
                //If the pilot NO role and don't want one
            }
            else
            {
                //If the pilot is going to have a new role
                if (pPilotDetailDto.Role != null)
                {
                    if (pPilotDetailDto.Role.RoleId != pPilotFromDb.RoleId)
                    {
                        //Setting the role before to NOT ative and setting the new role to active and link the role to the pilot and the piot to the role
                        Role roleToSetActive = _config.Roles.Where(r => r.RoleId == pPilotDetailDto.Role.RoleId).IgnoreQueryFilters().First();
                        roleToSetActive.IsActive = true;
                        roleToSetActive.PilotId = pPilotFromDb.PilotId;
                        roleToSetActive.Pilot = pPilotFromDb;
                        _config.Roles.Update(roleToSetActive);

                        Role roleToSetInactive = pPilotFromDb.Role;
                        roleToSetInactive.IsActive = false;
                        roleToSetInactive.PilotId = 0;
                        roleToSetInactive.Pilot = null;

                        _config.Roles.Update(roleToSetInactive);

                        //_config.SaveChanges();
                    }
                    else
                    {
                        //If The pilot is keeping the same role as before
                    }
                }
                else
                {
                    //The pilot had a role and setting is to null
                    Role roleToSetInactive = pPilotFromDb.Role;
                    roleToSetInactive.IsActive = false;
                    roleToSetInactive.PilotId = 0;
                    roleToSetInactive.Pilot = null;

                    _config.Roles.Update(roleToSetInactive);

                    //_config.SaveChanges();
                }
            }
        }

        private void AddRoleToPilot(int pRoleId,Pilot pPilotToLinkToTheRole)
        {
            //Add the role to the new pilot 
            Role RoleToModify = _config.Roles.Where(r => r.RoleId == pRoleId).IgnoreQueryFilters().First();
            RoleToModify.IsActive = true;
            RoleToModify.PilotId = pPilotToLinkToTheRole.PilotId;
            RoleToModify.Pilot = pPilotToLinkToTheRole;

            _config.Roles.Update(RoleToModify);
        }
        private void RemoveRoleFromPilot(int pRoleId,Pilot pPilotToRemoveTheRoleFrom)
        {
            Role roleToRemove = pPilotToRemoveTheRoleFrom.Role;
            roleToRemove.IsActive = false;
            roleToRemove.PilotId = 0;
            roleToRemove.Pilot = null;

            _config.Roles.Update(roleToRemove);

        }
    }
}
