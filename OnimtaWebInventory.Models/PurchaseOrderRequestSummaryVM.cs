using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class PurchaseOrderRequestSummaryVM
    {
        public string BranchName { get; set; }
        public int ProductId { get; set; }
        public string  ProductName { get; set; }
        public int Quantity { get; set; }



    }
}
