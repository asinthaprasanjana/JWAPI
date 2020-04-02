using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderRequest
{
   public  class PurchaseOrderRequestRequest : BaseRequest
    {
        public PurchaseOrderRequestVM purchaseOrderRequestVM { get; set; }
        public PurchaseOrderMasterVM purchaseOrderMasterVM { get; set; }

        public class PurchaseOrderRequestItemsRequest : BaseRequest
        {
            public PurchaseOrderRequestItemsVM purchaseOrderRequestItemsVM { get; set; }
        }
    }
}
