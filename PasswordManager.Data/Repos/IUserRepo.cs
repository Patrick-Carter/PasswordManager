using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Repos
{
    public interface IUserRepo
    {
        public List<UserModel> ListOfUsers { get; }
        public UserModel CreateUser(string username, string password);
        public UserModel FindUser(UserModel user);
    }
}
