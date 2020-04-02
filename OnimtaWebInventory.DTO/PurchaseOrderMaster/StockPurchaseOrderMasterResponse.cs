using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockPurchaseOrderMaster
{
  public class StockPurchaseOrderMasterResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM { get; set; }

    }
}
