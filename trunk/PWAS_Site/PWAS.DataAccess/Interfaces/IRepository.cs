using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PWAS.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Items { get; }
        void AddItem(T item);
        void DeleteItem(int id);
        void DeleteItem(T item);
        T GetById(int id);
        void SubmitChanges();
    }
}
