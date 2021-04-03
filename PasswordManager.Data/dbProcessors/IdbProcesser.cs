using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.dbProcessors
{
    public interface IdbProcesser<T> where T : class
    {
        public IRepo<UserModel> userRepo { get; }
        public void AddToDB(T model);
        public void RemoveFromDB(T model);
    }
}
