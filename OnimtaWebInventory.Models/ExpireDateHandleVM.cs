using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class ExpireDateHandleVM
    {
       public int purchaseOrderItemId { get;set;}

        public int PurchaseId { get; set; }

        public int ProductId { get; set; }
        public int PackSizeId { get; set; }
        public Nullable  <DateTime> ExpireDate  { get; set; }
        public int Quantity { get; set; }

        public string SerialNo { get; set; }

        public int UserId { get; set; }


    }
}
