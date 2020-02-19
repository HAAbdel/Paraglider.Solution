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
        public IQueryable<RoleDto> GetAllRoles()
        {
            var Roles = _config.Roles.Select(p => new RoleDto { Id = p.RoleId, RoleName = p.RoleName });
            foreach(var role in Roles)
            {
                Console.WriteLine(role.RoleName);
            }
            return Roles;
        }
        public RoleDto GetSpecificRole(int SearchedRoleId)
        {
            var Role = _config.Roles.Select(p => new RoleDto { Id = p.RoleId, RoleName = p.RoleName }).Where(r => r.Id == SearchedRoleId).First();

            return Role;
        }
    }
}
