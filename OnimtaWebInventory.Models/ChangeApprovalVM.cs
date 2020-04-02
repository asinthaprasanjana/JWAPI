using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class ChangeApprovalVM
    {
        public int id { get; set; }
        public int CompanyId { get; set; }
        public int ApprovalTypeId { get; set; }
        public int isActive { get; set; }
        public string ApprovalName { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }


    }
    
}
