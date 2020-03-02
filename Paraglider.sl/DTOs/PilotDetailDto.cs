using Paraglider.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paraglider.sl.DTOs
{
    public class PilotDetailDto
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "the first name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "the name is required"  )]
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public  decimal Weight { get; set; }

        public Role Role 
        {
            get;
            set;
        }
        public decimal TotalHoursFlight { get; set; }
    }
}
