using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.Model;

namespace PWAS.DataAccess.Interfaces
{
    public interface IStatusRepository
    {
        IQueryable<Status> Statuses { get; }
        void AddStatus(Status newStatus);
        void DeleteStatus(int statusId);
        Status GetById(int statusId);
        void SubmitChanges();
    }
}
