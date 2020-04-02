using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderReturn
{
   public class PurchaseOrderReturnResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderReturnVM> purchaseOrderReturnVM { get; set; }
    }
}
