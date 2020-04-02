using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderReturn
{
   public class PurchaseOrderReturnRequest : BaseRequest
    {
        public PurchaseOrderReturnVM purchaseOrderReturnVM { get; set; }
    }
}
