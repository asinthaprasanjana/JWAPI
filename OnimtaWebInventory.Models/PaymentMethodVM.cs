using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class PaymentMethodVM
    {
       public int PaymentMethodId { get; set; }
       public string PaymentMethodName { get; set; }
       public string StartDate { get; set; }
       public string EndDate { get; set; }
    }
}
