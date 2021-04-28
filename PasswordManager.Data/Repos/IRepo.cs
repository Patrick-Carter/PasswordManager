using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Repos
{
    public interface IRepo<T>
    {
        public List<T> ListOfItems { get; }
        public T Create(T model);
        public void Update(T model);
        public T GetByName(string name);
        public void Remove(T model);
    }
}
