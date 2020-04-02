using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseDraftSummery
{
  public  class PurchaseDraftSummeryResponse : BaseResponse
    {

        public IEnumerable<PurchaseDraftSummeryVM> PurchaseDraftSummeryVM { get; set; }
    }
}
