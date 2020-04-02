using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Approval
{
    public class ApprovalResponse : BaseResponse
    {
        public IEnumerable<ApprovalVM> approvalVM { get; set; }
    }
    public class ApprovalTaskResponse : BaseResponse
    {
        public IEnumerable<ApprovalVM>  approvalVM { get; set; }
    }
}
