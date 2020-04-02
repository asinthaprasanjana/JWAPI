using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderFinal
{
  public  class PurchaseOrderFinalRequest : BaseRequest
    {
        public PurchaseOrderFinalVM purchaseOrderFinalVM { get; set; }
    }
}
