using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Payment
{
   public  class PaymentResponse : BaseResponse
    {
        public IEnumerable<PaymentVM> paymentVM { get; set; }
    }
}
