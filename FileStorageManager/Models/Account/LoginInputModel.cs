using System;
using System.ComponentModel.DataAnnotations;

namespace FileStorageManager.Models.Account
{
    public class LoginInputModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool RememberLogin { get; set; } = false;
        public string ReturnUrl { get; set; }

    }
}
