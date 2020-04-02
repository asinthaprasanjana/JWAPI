using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.UserBranch
{
   public  class UserBranchResponse :BaseResponse
    {
        public IEnumerable<UserBranchVm> userBranchVm { get; set; }
        public UserBranchVm userBranch { get; set; }

        public IEnumerable<ModuleVM> Modules { get; set; }
    }
}
