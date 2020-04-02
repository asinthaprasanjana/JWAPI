using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.GeneralSetting
{
   public  class GeneralSettingRequest :BaseRequest
    {
        public PaymentMethodVM paymentMethodVM { get; set; }

    }
}
