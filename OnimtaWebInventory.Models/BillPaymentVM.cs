using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class BillPaymentVM
    {
        public int BillPaymentId { get; set; }
        public int BillId { get; set; }
        public string BusinessPartnerId { get; set; }
        public string BspDisplayName { get; set; }
        public decimal  TotalPrice {get;set;} 
        public string CreatedDateTime { get; set; }
    }
}
