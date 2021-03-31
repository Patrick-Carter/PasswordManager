using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using PasswordManager.Data.Tests.Repos.Mocks;
using PasswordManager.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Tests.UnitOfWork.Mocks
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        public IUserRepo userRepo { get; }

        public UnitOfWorkMock(IUserRepo userRepo = null)
        {
            this.userRepo = userRepo ?? new UserRepoMock();
        }
        public void AddUserToDB(UserModel user)
        {
            if (userRepo.FindUser(user.UserName) != null)
            {
                return;
            }

            userRepo.ListOfUsers.Add(user);
        }
    }
}
