using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.FunctionApprovalTypeResponse
{
     public  class FunctionApprovalTypeResponse : BaseResponse
    {
       public  IEnumerable<FunctionApprovalTypeVm> functionApprovalTypeVm { get; set; }
    }
}
