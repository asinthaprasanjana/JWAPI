using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.NewPurchaseOrder
{
  public  class NewPurchaseOrderRequest  : BaseRequest
    {
        public NewPurchaseOrderVM newPurchaseOrderVM { get; set; }
    }
}
