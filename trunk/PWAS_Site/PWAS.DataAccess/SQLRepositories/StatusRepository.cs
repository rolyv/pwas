using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.DataAccess.Interfaces;
using PWAS.Model;
using System.Data.Linq;

namespace PWAS.DataAccess.SQLRepositories
{
    public class StatusRepository : IStatusRepository
    {
        private Table<Status> statusTable;

        public StatusRepository(string connectionString)
        {
            statusTable = new PWASDataContext(connectionString).Status;
        }

        #region IStatusRepository Members

        public IQueryable<PWAS.Model.Status> Statuses
        {
            get { return statusTable; }
        }

        public void AddStatus(PWAS.Model.Status newStatus)
        {
            statusTable.InsertOnSubmit(newStatus);
        }

        public void DeleteStatus(int statusId)
        {
            statusTable.DeleteOnSubmit(GetById(statusId));
        }

        public PWAS.Model.Status GetById(int statusId)
        {
            return statusTable.FirstOrDefault(s => s.statusId == statusId);
        }

        public void SubmitChanges()
        {
            statusTable.Context.SubmitChanges();
        }

        #endregion
    }
}
