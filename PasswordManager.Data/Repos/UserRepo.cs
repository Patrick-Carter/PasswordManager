using PasswordManager.Data.Constants;
using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordManager.Data.Repos
{
    public class UserRepo : IRepo<UserModel>
    {

        public List<UserModel> ListOfItems { get; } = new List<UserModel>();

        public UserRepo()
        {
            if (!File.Exists(STRINGCONSTANTS.USER_DB)) 
            {
                var file = File.Create(STRINGCONSTANTS.USER_DB);
                file.Close();
            }
            
            string[] allUsers = File.ReadAllLines(STRINGCONSTANTS.USER_DB);

            foreach (var user in allUsers)
            {
                string[] splitLine = user.Split(",");
                ListOfItems.Add(new UserModel(splitLine[0], splitLine[1], splitLine[2]));
            }
        }

        public UserModel GetByName(string searchTerm)
        {
            return this.ListOfItems.Where(q => q.UserName == searchTerm).FirstOrDefault();
        }

        public UserModel Create(UserModel model)
        {
            if (GetByName(model.UserName) == null)
            {
                ListOfItems.Add(model);
                SaveChanges();
                return model;
            }
            return null;
        }

        public void Remove(UserModel model)
        {
            ListOfItems.Remove(model);
            SaveChanges();
        }

        private void SaveChanges()
        {
            using (StreamWriter file = new StreamWriter(STRINGCONSTANTS.USER_DB, false))
            {
                foreach (var user in ListOfItems)
                {
                    file.WriteLine($"{user.Id},{user.UserName},{user.Password}");
                }
            }
        }

        public void Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
