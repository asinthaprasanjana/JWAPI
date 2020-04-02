using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
  public   interface IBranchServices
    {
        Task<IEnumerable< BranchVM>> GetBranchDetailByCompanyId(int companyId);
        Task<BranchVM> AddNewBranchDetails(BranchVM branchVM);
        Task<BranchVM> UpdateBranchDetails(BranchVM branchVM);
        Task<IEnumerable<BranchVM>> GetBranchDetailsByUserId(int userId, int businessProcessId);

    }
}
