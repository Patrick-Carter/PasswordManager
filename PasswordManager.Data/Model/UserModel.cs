using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PasswordManager.Data.Model
{
    public class UserModel
    {
        [Required]
        public string Id { get; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        private IEnumerable<PasswordModel> ListOfPassword;

        public UserModel(string username, string password)
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserName = username;
            this.Password = password;
            this.ListOfPassword = new List<PasswordModel>();
        }

        public UserModel(string id, string username, string password)
        {
            this.Id = id;
            this.UserName = username;
            this.Password = password;
            this.ListOfPassword = new List<PasswordModel>();
        }

        public List<PasswordModel> GetListOfPasswordAsList()
        {
            return ListOfPassword.ToList();
        }

        public void SetListOfPassword(IEnumerable<PasswordModel> listOfPassword)
        {
            ListOfPassword = listOfPassword;
        }
    }
}
