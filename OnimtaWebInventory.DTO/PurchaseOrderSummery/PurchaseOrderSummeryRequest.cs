using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.NewPurchaseOrder
{
  public  class PurchaseOrderSummeryRequest : BaseRequest
    {
        public PurchaseOrderSummeryVM purchaseOrderSummeryVM { get; set; }
    }
}
