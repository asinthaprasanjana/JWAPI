using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderRequest
{
    public class PurchaseOrderRequestResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderRequestVM> purchaseOrderRequestVM { get; set; }
        public IEnumerable<PurchaseOrderRequestSummaryVM> purchaseOrderRequestSummaryVMs { get; set; } 
        public IEnumerable<PurchaseOrderRequestItemsVM> purchaseOrderRequestItemsVM { get; set; }
        public IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM { get; set; }
    }
}
