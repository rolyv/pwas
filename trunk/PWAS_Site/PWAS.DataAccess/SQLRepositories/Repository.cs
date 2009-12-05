using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.DataAccess.Interfaces;
using System.Data.Linq;
using PWAS.Model;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Data.Linq.Mapping;

namespace PWAS.DataAccess.SQLRepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Table<T> itemsTable;

        public Repository(string connectionString)
        {
            itemsTable = new PWASDataContext(connectionString).GetTable<T>();
        }

        #region IRepository<T> Members

        public IQueryable<T> Items
        {
            get { return itemsTable.AsQueryable<T>(); }
        }

        public void AddItem(T item)
        {
            itemsTable.InsertOnSubmit(item);
        }

        public void DeleteItem(int id)
        {
            DeleteItem(GetById(id));
        }

        public void DeleteItem(T item)
        {
            itemsTable.DeleteOnSubmit(item);
        }

        public T GetById(int id)
        {
            MetaModel modelMap = itemsTable.Context.Mapping;

            // get the data members for this type
            ReadOnlyCollection<MetaDataMember> dataMembers = modelMap.GetMetaType(typeof(T)).DataMembers;

            // find the primary key field name
            // by checking for IsPrimaryKey
            string pk = (dataMembers.Single<MetaDataMember>(m => m.IsPrimaryKey)).Name;

            // return a single object where the id argument
            // matches the primary key field value
            return itemsTable.SingleOrDefault(i => i.GetType().GetProperty(pk).GetValue(i, null).ToString() == id.ToString());
        }

        public void SubmitChanges()
        {
            itemsTable.Context.SubmitChanges();
        }

        #endregion
    }
}
