using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IDashBoardRepository
    {
        Task <IEnumerable<DashBoardVM>> GetAllDashBoardDetails( int TypeId);
        Task<DashBoardVM> GetReportDetails(int reportTypeId ,int branchId, DateTime fromDate , DateTime toDate);
    }
}
