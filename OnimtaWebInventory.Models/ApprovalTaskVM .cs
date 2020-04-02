using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class ApprovalTaskVM
    {

        public int CompanyId { get; set; }
        public int ApprovalTypeId { get; set; }
        public int ApprovalSenderId { get; set; }
        public int ApprovalRecieversId { get; set; }
        public string ReferenceNo { get; set; }
        public int CreatedUserId { get; set; }
        
    }
}
