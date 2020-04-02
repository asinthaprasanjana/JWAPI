using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderBill
{
   public class PurchaseOrderBillRequest : BaseRequest
    {
        public PurchaseOrderBillVM purchaseOrderBillVM { get; set; }
    }
}
