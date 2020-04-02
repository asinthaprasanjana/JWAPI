using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderBill
{
  public  class PurchaseOrderBillResponse : BaseResponse
    {
       // public IEnumerable<PurchaseOrderBillVM>purchaseOrderBillVM { get; set; }
        public IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM { get; set; }
    }
}
