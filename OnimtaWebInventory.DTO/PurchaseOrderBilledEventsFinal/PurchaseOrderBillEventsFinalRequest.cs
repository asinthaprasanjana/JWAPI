using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderBilledEvent
{
   public class PurchaseOrderBilledEventsFinalRequest : BaseRequest
    {
        public PurchaseOrderBilledEventsFinalVM purchaseOrderBilledEventsFinalVM { get; set; }
    }
}
