using PasswordManager.Data.Constants;
using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswordManager.Data.dbProcessors
{
    public class UserdbProcessor : IdbProcesser<UserModel>
    {

        public IRepo<UserModel> userRepo { get; }

        public UserdbProcessor(IRepo<UserModel> userRepo = null)
        {
            this.userRepo = userRepo ?? new UserRepo();
        }
        public void AddToDB(UserModel user)
        {
            if (ValidUser(user))
            {
                userRepo.ListOfItems.Add(user);
                SaveChanges();
            }
        }
        public void RemoveFromDB(UserModel user)
        {
            userRepo.ListOfItems.Remove(user);
            SaveChanges();
        }

        private void SaveChanges()
        {
            using (StreamWriter file = new StreamWriter(STRINGCONSTANTS.USER_DB, false))
            {
                foreach (var user in userRepo.ListOfItems)
                {
                    file.WriteLine($"{user.Id},{user.UserName},{user.Password}");
                }
            }
        }

        private bool ValidUser(UserModel user)
        {
            if (userRepo.GetByName(user.UserName) == null)
            {
                return true;
            }
            return false;
        }
    }
}
