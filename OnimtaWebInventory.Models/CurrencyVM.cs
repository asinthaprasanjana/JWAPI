using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class CurrencyVM
    {
      public int ID { get; set; }
      public int CurrencyId { get; set; }
      public string CurrencyName { get; set; }
      public int CreatedUserId { get; set; }
      public int CompanyId { get; set; }
      public DateTime CreatedDateTime { get; set; }
      public string DisplayName { get; set; }
    }
}
