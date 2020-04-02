using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderBilledEvents
{
  public  class PurchaseOrderBilledEventsResponse : BaseResponse
    {
       // public IEnumerable<PurchaseOrderBillVM>purchaseOrderBillVM { get; set; }
        public IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM { get; set; }
    }
}
