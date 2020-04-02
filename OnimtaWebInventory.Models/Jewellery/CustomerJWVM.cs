using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models.Jewellery
{
   public class CustomerJw
    {
      public int      Id { get; set; }
      public string   CustomerNumber { get; set; }
      public string   SalesManNumber { get; set; }
      public string   Title { get; set; }
     // public string   Type { get; set; }
      public string   Name { get; set; }
      public string   Address { get; set; }
      public string   Contact { get; set; }
      public string   Country { get; set; }
      public Boolean  Isdeleted { get; set; }
      public int      CreatedUserId { get; set; }
      public DateTime CreatedDateTime { get; set; }
      public int      LastModifiedUserId { get; set; }
      public DateTime LastModifiedDateTime { get; set; }
      public int      TotalCount { get; set; }

    }
}
