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
                Role = p.Role,
                TotalHoursFlight = _config.Flights.Where(p => p.PilotId == SearchId).Select(fh => fh.FlightDuration).Sum()
            }).Where(p => p.Id == SearchId).First();

            if(Pilot.Role == null)
            {
                Pilot.Role = new Role() { RoleId = -1, RoleName = "Default role" };
            }
            return Pilot;
        }
        public PilotDetailDto CreateNewPilot(PilotDetailDto NewDtoPilot)//A CHANGER
        {
            if (NewDtoPilot.Role != null && NewDtoPilot.Role.RoleId == -1)
                NewDtoPilot.Role = null;

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

            _config.Pilots.Add(NewPilot);

            _config.SaveChanges();
            
            NewDtoPilot.Id = NewPilot.PilotId;
            if (NewDtoPilot.Role != null)
                RoleOneModification(NewDtoPilot.Role.RoleId,NewPilot);

            _config.SaveChanges();
            return NewDtoPilot;
        }
        public PilotAndRoleMergeViewModel UpdatePilot(PilotAndRoleMergeViewModel pilotDetailDto)
        {
            //Récupérer le pilot de la base de données pour le modifier !
            Pilot pilotFromDB = _config.Pilots.Where(p => p.PilotId == pilotDetailDto.PilotDetail.Id).First();
            pilotFromDB.FirstName = pilotDetailDto.PilotDetail.FirstName;
            pilotFromDB.LastName = pilotDetailDto.PilotDetail.LastName;
            pilotFromDB.Email = pilotDetailDto.PilotDetail.Email;
            pilotFromDB.Weight = pilotDetailDto.PilotDetail.Weight;
            pilotFromDB.PhoneNumber = pilotDetailDto.PilotDetail.PhoneNumber;

            pilotFromDB.Role = _config.Roles.Where(r => r.RoleId == pilotFromDB.Role.RoleId).IgnoreQueryFilters().First();
            pilotDetailDto.PilotDetail.Role = _config.Roles.Where(r => r.RoleId == pilotDetailDto.PilotDetail.Role.RoleId).IgnoreQueryFilters().First();

            RoleModificationManager(pilotDetailDto.PilotDetail, pilotFromDB);

            _config.SaveChanges();

            return pilotDetailDto;
        }

        private void RoleModificationManager(PilotDetailDto pPilotDetailDto,Pilot pPilotFromDb)
        {

            //Get the PILOT role before the modification
            //PilotDetailDto pilotBeforeModification = new DetailedPilot(_config).GetSpecific(pPilotDetailDto.Id);//A modifier car trop de requestes à la base de données
            //Determinate if the role has been modified

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

                    _config.SaveChanges();
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

                        _config.SaveChanges();
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

                    _config.SaveChanges();
                }
            }

            //if (pilotBeforeModification.Role.RoleId != pPilotDetailDto.Role.RoleId)
            //{
            //    //If the PILOT had a role before
            //    //Define the previus pilotId to 0,the Pilot to null, the Avtice to false and Updating 
            //    if (pilotBeforeModification.Role.RoleId != -1)
            //    {
            //        Role PreviusRole = _config.Roles.Where(r => r.RoleId == pilotBeforeModification.Role.RoleId).IgnoreQueryFilters().First();
            //        PreviusRole.IsActive = false;
            //        PreviusRole.PilotId = 0;
            //        PreviusRole.Pilot = null;
            //        _config.Roles.Update(PreviusRole);
            //    }
            //    //If the PILOT is going for the DEFAULT ROLE
            //    if (pPilotDetailDto.Role.RoleId == 0)
            //    {
            //        pPilotDetailDto.Role = null;
            //    }
            //    //If the PILOT is getting the new role and this role is modified on the DB
            //    else
            //    {
            //        Role NewRole = _config.Roles.Where(r => r.RoleId == pPilotDetailDto.Role.RoleId).IgnoreQueryFilters().First();
            //        NewRole.IsActive = true;
            //        NewRole.PilotId = pPilotDetailDto.Id;
            //        NewRole.Pilot = pPilotFromDb;
            //        _config.Roles.Update(NewRole);
            //    }
            //    //_config.SaveChanges(); //Ajouter si cette methode est utilisé autre part que dans cette classe
            //}
        }
        private void RoleOneModification(int RoleId,Pilot PilotToLinkToTheRole)
        {
            Role RoleToModify = _config.Roles.Where(r => r.RoleId == RoleId).IgnoreQueryFilters().First();
            RoleToModify.IsActive = true;
            RoleToModify.PilotId = PilotToLinkToTheRole.PilotId;
            RoleToModify.Pilot = PilotToLinkToTheRole;
            _config.Roles.Update(RoleToModify);
        }
    }
}
