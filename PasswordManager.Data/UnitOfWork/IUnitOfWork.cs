using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepo userRepo { get; }
        public void AddUserToDB(UserModel user);
        public void RemoveUserFromDB(UserModel user);
    }
}
