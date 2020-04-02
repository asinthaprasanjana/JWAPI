using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.NewPurchaseOrder
{
  public  class NewPurchaseOrderResponse :BaseResponse
    {
        public IEnumerable<NewPurchaseOrderVM> newPurchaseOrderVM { get; set; }

    }

    public class StockPurchaseOrderSummeryResponse : BaseResponse
    {
        public IEnumerable<NewPurchaseOrderVM> newPurchaseOrderVM { get; set; }
    }

}
