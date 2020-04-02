using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseDraftSummery
{
  public  class SalesDraftSummaryResponse : BaseResponse
    {

        public IEnumerable<SalesDraftSummaryVM> SalesDraftSummaryVM { get; set; }
    }
}
