using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderItem
{
   public class PurchaseOrderItemRequest : BaseRequest
    {
        public PurchaseOrderItemVM purchaseOrderItemVM { get; set; }
    }
}
