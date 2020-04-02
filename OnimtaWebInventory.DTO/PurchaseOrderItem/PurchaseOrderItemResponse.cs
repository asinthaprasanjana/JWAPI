using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderItem
{
   public class PurchaseOrderItemResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM { get; set; }
    }
}
