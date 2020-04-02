using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class FunctionApprovalTypeVm
    {
        public int Id { get; set; }
        public int ApprovalTypeId { get; set; }
        public int IsActive { get; set; }
        public string ApprovalName { get; set; }
        public string ApprovalOfficersId { get; set; }
        public List<ApprovalOfficerVM> ApprovalOffcerVM { get; set; }

    }
}
