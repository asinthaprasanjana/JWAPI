using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Approval
{
  public  class ApprovalEventRequest : BaseRequest
    {   
        public ApprovalEventVM approvalEventVM { get; set; }

    }
}
