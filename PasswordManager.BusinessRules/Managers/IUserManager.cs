using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.BusinessRules.Managers
{
    public interface IUserManager
    {
        public void LoginUser(string userName, string password);

        public void LogoutUser();

        public UserModel GetCurrentUser();

    }
}
