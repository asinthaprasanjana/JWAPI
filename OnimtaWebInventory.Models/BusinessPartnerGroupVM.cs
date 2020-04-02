using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class BusinessPartnerGroupVM
    {
      public int Id { get; set; } 
      public string  GroupCode{ get; set; }
      public string  GroupName { get; set; }
      public int BusinessPartnerTypeId { get; set; }
      public string BusinessPartnerTypeName { get; set; }
      public int  CreatedUserId { get; set; }
      public string CreatedDateTime { get; set; }
    }
}
