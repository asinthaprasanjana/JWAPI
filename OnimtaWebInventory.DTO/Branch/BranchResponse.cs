using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Branch
{
  public   class BranchResponse :BaseResponse
    {
        public IEnumerable<BranchVM> branchVM { get; set; }

    }
}
