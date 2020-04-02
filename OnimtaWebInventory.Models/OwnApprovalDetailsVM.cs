using System;

namespace OnimtaWebInventory.Models
{
    public class OwnApprovalDetailsVM
    {
        public int Id { get; set; }
        public int ApprovalTaskId { get; set; }
        public int  ApprovalResponserId { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime  CreatedDateTime { get; set; }
        public int CompanyId { get; set; }

        public string  ApprovalName { get; set; }
        public string  UserName  { get; set; }
        public int  Status { get; set; }
    }
}