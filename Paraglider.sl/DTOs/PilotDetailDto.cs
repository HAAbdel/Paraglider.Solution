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
       
        [Required(ErrorMessage = "Please enter the user's first name.")]
        [StringLength(50)]
        [Display(Name = "FirstName :")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Please enter the user's last name.")]
        [StringLength(50)]
        [Display(Name = "LastName :")]
        public string LastName { get; set; }
       
        [Phone]
        public string PhoneNumber { get; set; }
       
        
        [EmailAddress(ErrorMessage = "The Email Address is not valid")]
        [Required(ErrorMessage = "Please enter an email address.")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [Required (ErrorMessage = "Please enter the user's weight.")]
        [Display(Name = "Weight : ")]
        public  decimal Weight { get; set; }
        public Role Role 
        {
            get;
            set;
        }
    }
}
