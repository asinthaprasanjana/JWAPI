using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class ApprovalVM
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int ApprovalId { get; set; }
        public string ApprovalTaskId { get; set; }
        public string ApprovalName { get; set; }
        public string ReferenceNo { get; set; }
        public int ComapanyId { get; set; }
        public int ApprovalTypeId { get; set; }
        public int IsActive { get; set; }
        public int CreatedUserId { get; set; }
        public string ApprovalOfficersId { get; set; }
        public IEnumerable<ApplicationUserVM> ApplicationUserVM { get; set; }

    }
}
