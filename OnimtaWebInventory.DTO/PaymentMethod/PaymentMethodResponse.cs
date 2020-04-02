using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PaymentMethod
{
   public class PaymentMethodResponse: BaseResponse
    {
        public IEnumerable<PaymentMethodVM> paymentMethodVM { get; set; }

    }
}
