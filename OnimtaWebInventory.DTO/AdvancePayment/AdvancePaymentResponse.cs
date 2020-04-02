
using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System.Collections.Generic;

namespace OnimtaWebInventory.DTO.AdvancePayment
{
   public class AdvancePaymentResponse : BaseResponse
    {
        public IEnumerable<AdvancePaymentVM> advancePaymentVM { get; set; }
        public AdvancePaymentVM advancePaymentVm { get; set; }

    }
}
