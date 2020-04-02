using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderSummery
{
 

    public class PurchaseOrderSummeryResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM { get; set; }
    }

}
