﻿using Microsoft.EntityFrameworkCore;
using Paraglider.DAL;
using Paraglider.DAL.Models;
using Paraglider.sl.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paraglider.sl.Queries
{
    public class RoleList
    {
        private readonly ParagliderContext _config;

        public RoleList (ParagliderContext config)
        {
            _config = config;
        }
        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var Roles = _config.Roles.Select(p => new RoleDTO { Id = p.RoleId, RoleName = p.RoleName });
            foreach(var role in Roles)
            {
                Console.WriteLine(role.RoleName);
            }
            return Roles;
        }
        public IEnumerable<RoleDTO> GetAllAvalableRoles()
        {
            var Roles = _config.Roles.Where(r => r.IsActive == false)
                .Select(p => new RoleDTO
                    { 
                        Id = p.RoleId, 
                        RoleName = p.RoleName 
                    })
                .IgnoreQueryFilters();

            foreach (var role in Roles)
            {
                Console.WriteLine(role.RoleName);
            }
            return Roles;
        }
        public RoleDTO GetSpecificRole(int SearchedRoleId)
        {
            var Role = _config.Roles.Select(p => new RoleDTO 
                { 
                Id = p.RoleId, 
                RoleName = p.RoleName 
                }).Where(r => r.Id == SearchedRoleId)
                .First();

            return Role;
        }
    }
}
