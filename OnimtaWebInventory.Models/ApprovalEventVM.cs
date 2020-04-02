using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class ApprovalEventVM
    {

        public string ReferenceNo { get; set; }
        public string ApprovalTaskId { get; set; }
        public int UserId { get; set; }
        public int ApprovalTypeId { get; set; }
        public string ApprovalTypeName { get; set; }
        public string SenderName { get; set; }
        public int Status { get; set; }
        public int CreatedUserId { get; set; }
        public string CreatedDateTime { get; set; }
        public string StatusType { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
