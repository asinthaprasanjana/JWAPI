using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ApplicationUserBranch
{
   public  class ApplicationUserBranchResponse : BaseResponse
    {
        public IEnumerable<ApplicationUserBranchVM> applicationUserBranchVM { get; set; }
    }
}
