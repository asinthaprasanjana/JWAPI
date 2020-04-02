using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class SalesReturnVM
    {
        public string SaleNo { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public int BillLocationId { get; set; }
        public int ShipLocationId { get; set; }
        public int CurrencyId { get; set; }
        public Decimal ReturningTotal { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LastModifiedUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

    }
}
