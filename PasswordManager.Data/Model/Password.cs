using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PasswordManager.Data.Model
{
    public class Password
    {
        [Required]
        public string Id { get; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Website { get; set; }
        [Required]
        public User User { get; }

        public Password(string name, string code, User user ,string website = null)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Code = code;
            this.Website = website;
            this.User = user;
        }
    }
}
