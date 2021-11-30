using System;
using NetChatApp.Areas.Identity.Data;

namespace FileStorageManager.Models
{
    public class RegisterResponseModel
    {
        public string firstName;
        public string lastName;
        public string fullName;
        public string email;
        public string password;

        public RegisterResponseModel(AppUser appUser)
        {
            firstName = appUser.FirstName;
            lastName = appUser.LastName;
            fullName = appUser.FullName;
            email = appUser.Email;
            password = appUser.PasswordHash;
        }
    }
}
