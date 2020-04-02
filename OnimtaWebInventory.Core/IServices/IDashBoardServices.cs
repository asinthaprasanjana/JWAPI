using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
   public interface IDashBoardServices
    {
        Task<IEnumerable<DashBoardVM>> GetAllDashBoardDetails(int TypeId);
        Task<DashBoardVM> GetReportDetails(int reportTypeId, int branchId, DateTime fromDate, DateTime toDate);

    }
}
