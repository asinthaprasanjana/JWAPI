using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class PurchaseOrderRequestItemsVM
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string PurchaseNo { get; set; }
        public int ItemId { get; set; }
        public float Quantity { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LastModifiedUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}