using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace FileStorageManager.Models
{
    public class RegisterRequestViewModel
    {
        [Required]
        [Display(Name="FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name="FullName")]
        public string FullName { get; set; }

        [Required]
        [Display(Name="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Password")]
        public string Password { get; set; }
    }
}
