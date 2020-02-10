using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.DAL.Models
{
    public enum RolesList // public a changer par la suite
    {
       Administrator,
       CEO,
       Manager,
       CoManager
    }
    public class Role
    {
        [Required]
        public Guid RoleId { get; set; }
        [Required]
        public RolesList RoleName { get; set; }
    }
}
