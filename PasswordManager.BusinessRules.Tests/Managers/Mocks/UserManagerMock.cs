using PasswordManager.BusinessRules.Managers;
using PasswordManager.Data.Model;
using PasswordManager.Data.Tests.UnitOfWork.Mocks;
using PasswordManager.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.BusinessRules.Tests.Managers.Mocks
{
    public class UserManagerMock : IUserManager
    {
        private UserModel currentUser;
        private IUnitOfWork uow;

        public UserManagerMock(IUnitOfWork unitOfWork = null)
        {
            uow = unitOfWork ?? new UnitOfWorkMock();
        }

        public UserModel GetCurrentUser()
        {
            return currentUser;
        }

        public void LoginUser(string userName, string password)
        {
            var user = uow.userRepo.FindUser(userName);

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
    }
}
