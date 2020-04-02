using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class PurchaseOrderSummeryVM
    {
        public int Id { get; set; }

        public string DocumentNo { get; set; }
        public int RecievedId { get; set; }
        public int Count { get; set; }
        public string Vendor { get; set; }
        public string IssueStatus { get; set; }
        public string PurchaseNo { get; set; }

        public string ApprovalStatus { get; set; }
        public int SupplierId { get; set; }
        public string Status { get; set; }
        public string Recieved { get; set; }
        public string Billed { get; set; }
        public int CreatedUserId { get; set; }
        public string CreatedDateTime { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public string BillTo { get; set; }
        public string Paid { get; set; }
        public string ShipTo { get; set; }
        public int CurrencyId { get; set; }
        public float NetTotal { get; set; }
        public float GrossTotal { get; set; }
        public float Tax { get; set; }
        public float Discount { get; set; }
        public string CurryncyName { get; set; }

        public string BusinessPartnerName { get; set; }

        public DateTime PayementDue { get; set; }
        public string UserName { get; set; }

        public string Date { get; set; }


    }
}
