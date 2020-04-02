using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderBill
{
  public  class PurchaseOrderRecieveResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderRecieveVM> PurchaseOrderRecieveVM { get; set; }
    }

    public class PurchaseOrderMasterResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM { get; set; }
    }
}
