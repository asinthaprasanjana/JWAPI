using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.UserBranch
{
   public  class UserBranchRequest : BaseRequest
    {
        public UserBranchVm userBranchVm { get; set; }
        public IEnumerable<UserBranchVm> userBranchs { get; set; }

    }
}
