using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.BillPayment
{
   public  class BillPaymentRequest : BaseRequest
    {
        public BillPaymentVM billPaymentVM { get; set; }

    }
}
