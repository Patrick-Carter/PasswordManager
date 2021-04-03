using PasswordManager.Data.dbProcessors;
using PasswordManager.Data.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.BusinessRules.Managers
{
    public class UserManager : IUserManager
    {
        private UserModel currentUser;
        private IdbProcesser<UserModel> uow;

        public UserManager(IdbProcesser<UserModel> unitOfWork = null)
        {
            uow = unitOfWork ?? new UserdbProcessor();
        }

        public UserModel GetCurrentUser()
        {
            return currentUser;
        }

        public void LoginUser(string userName, string password)
        {
            var user = uow.userRepo.GetByName(userName);

            if (user == null || user.Password != password)
            {
                return;
            }

            if (password == user.Password)
            {
                currentUser = user;
            }
        }

        public void LogoutUser()
        {
            currentUser = null;
        }

        public void RemoveUser(string password)
        {
            if (password == currentUser.Password)
            {
                uow.RemoveFromDB(currentUser);
                currentUser = null;
            }
        }
    }
}
