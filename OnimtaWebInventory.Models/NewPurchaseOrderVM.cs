using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class NewPurchaseOrderVM
    {
        public int Id { get; set; }
        public string PurchaseNo { get; set; }
        public int BillTo { get; set; }
        public int ShipTo { get; set; }
        public int BranchId { get; set; }
        public int CurrencyId { get; set; }
        public int TotalsAre { get; set; }
        public int CreditPeriod { get; set; }
        public int SupplierId { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public int CreatedUserId { get; set; }
        public string Paid { get; set; }
        public DateTime PayementDue { get; set; }
        public DateTime StockDue { get; set; }
        public int CompanyId { get; set; }
        public int Status { get; set; }
        public bool Recieved { get; set; }
        public bool Billed { get; set; }
        public int LastModifiedUserId { get; set; }
    }
}
