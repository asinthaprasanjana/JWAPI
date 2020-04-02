using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderFinal
{
   public  class PurchaseOrderFinalResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderFinalVM> purchaseOrderFinalVM { get; set; }
    }
}
