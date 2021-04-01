using PasswordManager.Data.Constants;
using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PasswordManager.Data.Repos
{
    public class UserRepo : IUserRepo
    {

        public List<UserModel> ListOfUsers { get; } = new List<UserModel>();

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
                ListOfUsers.Add(new UserModel(splitLine[0], splitLine[1], splitLine[2]));
            }
        }

        public UserModel CreateUser(string username, string password)
        {
            if (FindUser(username) == null)
            {
                UserModel user = new UserModel(username, password);
                return user;
            }
            return null;
        }

        public UserModel FindUser(string username)
        {
            return this.ListOfUsers.Where(q => q.UserName == username).FirstOrDefault();
        }
    }
}
