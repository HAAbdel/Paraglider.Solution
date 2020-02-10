using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Paraglider.DAL.Models
{
    public class Driver
    {
        public Driver()
        {
            Weight = 0;
        }
        public Guid DriverId { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [ForeignKey("Role")]
        public Role RoleId { get; set; }
    }
}
