using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class SalesViewVM
    {
        public string SaleNo { get; set; }
        public int CustomerId { get; set; }
        public Decimal NetTotal { get; set; }
        public string Status { get; set; }
        public string Customer { get; set; }
        public string CreatedDateTime { get; set; }

    }
}
