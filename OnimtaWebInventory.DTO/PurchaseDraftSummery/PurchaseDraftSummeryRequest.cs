using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseDraftSummery
{
  public  class PurchaseDraftSummeryRequest :BaseRequest
    {
        public PurchaseDraftSummeryVM purchaseDraftSummeryVM { get; set; }
    }
}
