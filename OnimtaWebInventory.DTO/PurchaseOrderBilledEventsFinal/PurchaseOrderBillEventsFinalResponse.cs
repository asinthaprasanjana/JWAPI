using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderBilledEventsFinal
{
  public  class PurchaseOrderBilledEventsFinalResponse : BaseResponse
    {
       // public IEnumerable<PurchaseOrderBillVM>purchaseOrderBillVM { get; set; }
        public PurchaseOrderBilledEventsVM purchaseOrderBilledEventsVM { get; set; }
    }
}
