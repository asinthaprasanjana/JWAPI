using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class PurchaseOrderBilledEventsVM
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int RecievingId { get; set; }
        public int BillId { get; set; }
        public int BillPaymentTypeId { get; set; }
        public int isAdvancePayments { get; set;}
        public int isBalanceToAdvance { get; set; }
        public int PurchaseOrderNo { get; set; }
        public string BSPDisplayName { get; set; }
        public string BusinessPartnerId { get; set; }

        public string DocumentNo { get; set; }

        public string PaymentStatus { get; set; }


        public string BillIds { get; set; }
        public int noOfProducts { get; set; }
        public int PurchaseOrderItemId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public decimal BillTotal { get; set; }
        public decimal PayingAmount { get; set; }
        public decimal AdvancePaymentAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int BilledQuantity { get; set; }
        public decimal BilledPrice { get; set; }
        public int CreatedUserId { get; set; }
        public string CreatedDateTime { get; set; }

        public string UserName { get; set; }


    }

}
