using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ApprovalResponse
{
   public  class ApprovalResponseResponse :BaseResponse
    {
        public IEnumerable<ApprovalResponseVM> approvalResponseVM;
    }
}
