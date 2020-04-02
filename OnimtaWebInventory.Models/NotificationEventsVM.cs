using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class NotificationEventsVM
    {
       public int Id { get; set; }
       public int CompanyId { get; set; }
       public  int UserId { get; set; }
       public  string ReferenceNo { get; set; }
       public  string Header { get; set; }
       public  string Message { get; set; }
       public  string  Url { get; set; }
      // public int  Is { get; set; }
       public int  Seen { get; set; }
       public int  IsActive { get; set; }
       public int Sender { get; set; }
       public DateTime CreatedDateTime { get; set; }
    }
}
