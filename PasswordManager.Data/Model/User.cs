using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Model
{
    public class User
    {
        [Required]
        public string Id { get; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public User(string username, string password)
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserName = username;
            this.Password = password;
        }
    }
}
