using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class ApprovalResponseVM
    {


       public string ApprovalTaskId { get; set; }
       public int UserId { get; set; }
       public int IsApproved { get; set; }
       public int ApprovalOwnerUserId { get; set; }
       public string ReferenceNo { get; set; }
       public int NotificationTypeId { get; set; }
       public string UserComment { get; set; }

    }
}
