using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Role
    {
        [ForeignKey("Pilot")]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public Pilot Pilot { get; set; }
    }
}
