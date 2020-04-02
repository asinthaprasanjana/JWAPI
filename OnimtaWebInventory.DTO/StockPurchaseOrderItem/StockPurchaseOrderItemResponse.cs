using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockPurchaseOrderItem
{
  public class StockPurchaseOrderItemResponse : BaseResponse
    {
        public IEnumerable < PurchaseOrderItemVM> purchaseOrderItem { get; set; }

    }
}
