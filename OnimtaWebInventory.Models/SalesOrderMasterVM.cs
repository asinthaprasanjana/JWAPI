using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class SalesOrderMasterVM
    {
        public string SaleNo { get; set; }
        public string DisplayName { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public int CreditPeriod { get; set; }
        public int BillLocationId { get; set; }
        public int ShipLocationId { get; set; }
        public string PayementDue { get; set; }
        public int CurrencyId { get; set; }
        public Decimal GrossTotal { get; set; }
        public Decimal Tax { get; set; }
        public Decimal Discount { get; set; }
        public Decimal NetTotal { get; set; }
        public Decimal ReturningTotal { get; set; }
        public int Status { get; set; }
        public int Invoiced { get; set; }
        public string Email { get; set; }
        public string CurryncyName { get; set; }
        public string BillTo { get; set; }
        public string ShipTo { get; set; }
        public string Remarks { get; set; }
        public int CreatedUserId { get; set; }
        public int ApprovalStatus { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LastModifiedUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public IEnumerable<SalesOrderItemVM> salesOrderItemVM { get; set; }

    }
}
