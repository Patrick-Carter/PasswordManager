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
            if (userRepo.FindUser(user) != null)
            {
                return;
            }

            userRepo.ListOfUsers.Add(user);
            using (StreamWriter file = new StreamWriter(@"D:\pmcsvfiles\users.txt", true))
            {
                file.WriteLine($"{user.Id},{user.UserName},{user.Password}");
            }
        }
    }
}
