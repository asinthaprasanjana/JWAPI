using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.NewFolder
{
  public class StockPurchaseOrderResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM { get; set; }
        public IEnumerable<PurchaseOrderItemVM> purchaseOrderItem { get; set; }
    }

    //public class StockPurchaseOrderItemResponse : BaseResponse
    //{
    //    public IEnumerable<PurchaseOrderItemVM> purchaseOrderItem { get; set; }
    //}

}
