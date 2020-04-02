using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderBill
{
   public class PurchaseOrderRecieveRequest : BaseRequest
    {
        public PurchaseOrderRecieveVM PurchaseOrderRecieveVM { get; set; } 
    }
    public class PurchaseOrderMasterRequest : BaseRequest
    {
        public PurchaseOrderMasterVM purchaseOrderMasterVM { get; set; }
    }
}
