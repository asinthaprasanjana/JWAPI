using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockPurchaseOrder
{
  public  class StockPurchaseOrderRequest :BaseRequest
    {
        public PurchaseOrderSummeryVM purchaseOrderSummeryVM { get; set; }
    }

    public class PurchaseOrderItemRequest : BaseRequest
    {
        public PurchaseOrderItemVM purchaseOrderItemVM { get; set; }
    }
}
