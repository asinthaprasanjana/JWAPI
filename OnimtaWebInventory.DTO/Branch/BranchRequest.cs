using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Branch
{
   public  class BranchRequest :BaseRequest
    {
        public BranchVM branchVM { get; set; }
    }
}
