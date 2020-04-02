using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class PurchaseOrderItemVM
    {

        public int ProductId { get; set; }

        public string PurchaseNo { get; set; }

        public string DocumentNo { get; set; }

        public int Id { get; set; }
        public string RecievedDocumentNo { get; set; }

        public int purchaseOrderId { get; set; }
        public int purchaseOrderItemId { get; set; }
        public string ItemName { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public int ItemCost { get; set; }
        public float RecievedQuantity { get; set; }
        public float RecievingQuantity { get; set; }
        public int Discount { get; set; }
        public int ReturningQuantity { get; set; }
        public int ReturningPrice { get; set; }
        public int Tax { get; set; }
        public int UserId { get; set; }
        public string Reason { get; set; }
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public string PackSizeName { get; set; }
        public int PackSizeId { get; set; }
        public float TotalCost { get; set; }
        public string PaymentStatus { get; set; }

        public int ExpireDateHandle { get; set; }
        public float freeQuantity { get; set; }
        public string CreatedDateTime { get; set; }
        public string QuotationId { get; set; }
        public float UnitPrice { get; set; }

        public int RecieveTypeId { get; set; }

        public int BatchHandle { get; set; }

        public int SerialNoHandle { get; set; }

        public IEnumerable<BranchVM> BranchWiseQuantity { get; set; }

    }
}