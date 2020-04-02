using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderBilledEvents
{
   public class AllPurchaseOrderBilledEventsRequest : BaseRequest
    {
        public string BillIds { get; set; }
    }
}
