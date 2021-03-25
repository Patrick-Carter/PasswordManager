using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PasswordManager.Data.Model
{
    public class PasswordModel
    {
        [Required]
        public string Id { get; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Website { get; set; }
        [Required]
        public UserModel User { get; }

        public PasswordModel(string name, string code, UserModel user ,string website = null)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = name;
            this.Code = code;
            this.Website = website;
            this.User = user;
        }
    }
}
