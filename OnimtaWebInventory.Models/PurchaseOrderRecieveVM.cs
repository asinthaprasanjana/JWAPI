using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class PurchaseOrderRecieveVM
    {
        public int BillId { get; set; }
        public int CompanyId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int PurchaseOrderItemId { get; set; }
        public int ProductId { get; set; }
        public float RecievedQuantity { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    } 
}
