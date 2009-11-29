﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWAS.Model;
using System.Data.Linq;

namespace PWAS.DataAccess.SQLRepositories
{
    public class PrintRunRepository : PWAS.DataAccess.Interfaces.IPrintRunRepository
    {
        private Table<PrintRun> printRunTable;

        public PrintRunRepository(string connectionString)
        {
            printRunTable = new PWASDataContext(connectionString).PrintRuns;
        }

        public void AddPrintRun(PrintRun printRun)
        {
            printRunTable.InsertOnSubmit(printRun);
        }

        public PrintRun GetById(int printRunId)
        {
            return printRunTable.Single(p => p.runID == printRunId);
        }

        public void DeletePrintRun(int printRunId)
        {
            printRunTable.DeleteOnSubmit(GetById(printRunId));
        }

        public void UpdatePrintRunInfo(PrintRun newPrintRun)
        {
            PrintRun printRunOriginal = printRunTable.Single(p => p.runID == newPrintRun.runID);
            printRunTable.Attach(newPrintRun, printRunOriginal);
        }

        public void SubmitChanges()
        {
            printRunTable.Context.SubmitChanges();
        }

        public IQueryable<PrintRun> PrintRuns
        {
            get { return printRunTable; }
        }
    }
}
