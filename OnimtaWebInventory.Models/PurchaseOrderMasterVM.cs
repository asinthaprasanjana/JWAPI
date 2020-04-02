using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class PurchaseOrderMasterVM
    {
        public int    Id { get; set; }
        public string Vendor { get; set; }
        public string PurchaseNo { get; set; }

        public string DocumentNo { get; set; }


        public int QcAvailable { get; set; }
        public int    SupplierId { get; set; }
        public string Status { get; set; }
        public int Recieved { get; set; }
        public string Billed { get; set; }

        public string Paid { get; set; }

        public int    CreatedUserId { get; set; }

        public int IsCancelled { get; set; }

        public string CreatedDateTime { get; set; }
        public string Email { get; set; }
        public int    CompanyId { get; set; }
        public string BillTo { get; set; }
        public string ShipTo { get; set; }
        public int    CurrencyId { get; set; }
        public int ApprovalStatus { get; set; }
        public float  NetTotal { get; set; }
        public decimal returningTotal { get; set; }
        public float  GrossTotal { get; set; }
        public float  Tax { get; set; }
        public float  Discount { get; set; }
        public string CurryncyName { get; set; }
        public DateTime PayementDue { get; set; }
        public DateTime StockDue { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int IsBilling { get; set; }
        public int BranchId { get; set; }
        public string Remarks { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public string BranchName { get; set; }

        public string BusinessPartnerName { get; set; }
        public string businessPartnerEmail { get; set; }
        public string BusinessPartnerId { get; set; }

        public int TempRecieved { get; set; }

        public int RecieveTypeId { get; set; }

        public DateTime startDate { get; set; }
        public IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM { get; set; }

        public IEnumerable<ExpireDateHandleVM> ExpireDateHandleVM { get; set; }

        public string QuotationId { get; set; }

        public int RecievedTypeId { get; set; }

        public int IsPartiallyAndFullyRecieving { get; set; }
    }
}
