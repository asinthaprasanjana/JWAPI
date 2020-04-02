using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
   public  interface IBranchRepository
    {
        Task<IEnumerable <BranchVM>> GetBranchDetailByCompanyId(int companyId);
        Task<BranchVM> AddNewBranchDetails(BranchVM branchVM);
        Task<BranchVM> UpdateBranchDetails(BranchVM branchVM);
        Task<IEnumerable<BranchVM>> GetBranchDetailsByUserId(int userId , int businessProcessId);
        Task<WareHouseVM> AddNewWareHouseDetails(WareHouseVM wareHouseVM);
        Task<WareHouseVM> UpdateWareHouseDetails(WareHouseVM wareHouseVM);
        Task<WareHouseVM> GetWareHouseDetailsByBranchId(int BranchId);
    }
}
