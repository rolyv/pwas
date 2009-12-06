using System;
using System.Linq;
using PWAS.Model;

namespace PWAS.DataAccess.Interfaces
{
    public interface IPrintRunRepository
    {
        IQueryable<PrintRun> PrintRuns { get; }
        void AddPrintRun(PrintRun printRun);
        void DeletePrintRun(int printRunId);
        PWAS.Model.PrintRun GetById(int printRunId);
        void SubmitChanges();
        void UpdatePrintRunStatus(int printRunId, int statusId);
    }
}
