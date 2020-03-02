using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Role
    {
        //Primary key
        public int RoleId { get; set; }
        //Soft delete
        [Required]
        public bool IsActive { get; set; }
        public string RoleName { get; set; }
        //Navigation properties
        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }
    }
}
