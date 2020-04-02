using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ApprovalResponse
{
   public class ApprovalResponseRequest :BaseRequest
    {
        public ApprovalResponseVM approvalResponseVM { get; set; }
    }
}
