using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.BillPayment
{
   public  class BillPaymentResponse : BaseResponse
    {
        public IEnumerable<BillPaymentVM> billPaymentVM { get; set; }
    }
}
