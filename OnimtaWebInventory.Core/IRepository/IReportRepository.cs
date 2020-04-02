using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
   public interface IReportRepository
    {
        Task<ReportVM> GetReportDetailsByReportID(int reportId, int companyId);
    }
}
