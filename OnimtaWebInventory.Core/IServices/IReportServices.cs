using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IReportServices
    {

        Task<ReportVM> GetReportDetailsByReportID(int reportId, int companyId);




    }
}
