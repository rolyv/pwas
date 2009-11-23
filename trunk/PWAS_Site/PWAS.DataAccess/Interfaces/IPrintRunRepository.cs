using System;
namespace PWAS.DataAccess.Interfaces
{
    public interface IPrintRunRepository
    {
        void AddPrintRun(PWAS.Model.PrintRun printRun);
        void DeletePrintRun(int printRunId);
        PWAS.Model.PrintRun GetById(int printRunId);
        void SubmitChanges();
        void UpdatePrintRunInfo(PWAS.Model.PrintRun newPrintRun);
    }
}
