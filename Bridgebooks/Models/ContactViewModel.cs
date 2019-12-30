using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bridgebooks.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Comments { get; set; }
    }
}