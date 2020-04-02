using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class AdvancePaymentVM
    {
       public string AdvancePaymentId { get; set; }
       public int AdvancePaymentTypeId { get; set; }
       public int paymentMethodId { get; set; }
       public string PaymentMethodName { get; set; }
       public int BusinessPartnerId { get; set; }
       public string  BusinessPartnerName { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
       public string Nic { get; set; }
       public string name { get; set; }
       public string CompanyName { get; set; }
       public string CreatedDateTime { get; set; }
       public int CreatedUserId { get; set; }

    }

}
