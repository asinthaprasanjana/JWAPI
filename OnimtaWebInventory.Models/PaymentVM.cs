using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class PaymentVM
    {
        public int Id { get; set; }

        public int BillId { get; set; }

        public int BusinessPartnerId { get; set; }
        public string  ReferenceNo {get;set;}
        public string DocumentNo { get; set; }

        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Reference3 { get; set; }

        public int PaymentType { get; set; }

        public int TotalRecordCount { get; set; }



        public string BusinessPartnerName { get; set; }

        public string Reference4 { get; set; }

        public int PayementMethodTypeId { get; set; }

        public string UserName { get; set; }
     
        public double Balance { get; set; }
        public double TotalPaidAmount { get; set; }

        public int UserId { get; set; }

        public string Date { get; set; }


        public IEnumerable<PaymentItemVM> paymentItemVM { get; set; }

    }

    public class PaymentItemVM
    {
        public double PaidAmount { get; set; }
        public string PayementDocumentNo { get; set; }
        public int PayementMethodTypeId { get; set; }
        public string Reference1 { get; set; }

        public string PaymentType { get; set; }

        public string Reference2 { get; set; }
        public string Reference3 { get; set; }
        public string Reference4 { get; set; }
        public int UserId { get; set; }


    }
}
