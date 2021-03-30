using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PasswordManager.Data.Repos
{
    public interface IRepo<T> where T : class
    {
        public void GetById(string id);
        public void Find(Expression<Func<T, bool>>);
        public void UpdateById(string id);

        public void Add(T item);
    }
}
