using PasswordManager.Data.Constants;
using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswordManager.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        public IUserRepo userRepo { get; }

        public UnitOfWork(IUserRepo userRepo = null)
        {
            this.userRepo = userRepo ?? new UserRepo();
        }
        public void AddUserToDB(UserModel user)
        {
            if (ValidUser(user))
            {
                userRepo.ListOfUsers.Add(user);
                using (StreamWriter file = new StreamWriter(STRINGCONSTANTS.USER_DB, true))
                {
                    file.WriteLine($"{user.Id},{user.UserName},{user.Password}");
                }
            }
        }

        private bool ValidUser(UserModel user)
        {
            if (userRepo.FindUser(user.UserName) == null)
            {
                return true;
            }
            return false;
        }
    }
}
