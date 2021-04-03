using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Repos
{
    public interface IRepo<T>
    {
        public List<T> ListOfItems { get; }
        public T Create(string username, string password);
        public T GetByName(string name);
    }
}
