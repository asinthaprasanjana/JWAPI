using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockPurchaseOrderMaster
{
  public  class StockPurchaseOrderMasterRequest : BaseRequest
    {
        public PurchaseOrderMasterVM purchaseOrderMasterVM { get; set; }
    }
}
