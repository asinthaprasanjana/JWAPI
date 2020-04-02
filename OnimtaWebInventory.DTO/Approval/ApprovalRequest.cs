using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Approval
{
  public  class ApprovalRequest : BaseRequest
    {   
        public ApprovalVM approvalVM { get; set; }
    }
    public class ApprovalTaskRequest : BaseRequest
    {
        public ApprovalTaskVM approvalTaskVM { get; set; }
    }
}
