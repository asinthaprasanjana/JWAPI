using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.GeneralSetting
{
   public class GeneralSettingResponse :BaseResponse
    {
        public IEnumerable<PaymentMethodVM> paymentMethodVM { get; set; }
    }
}
