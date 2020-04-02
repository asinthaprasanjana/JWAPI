using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesDraftSummary
{
  public  class SalesDraftSummaryRequest :BaseRequest
    {
        public SalesDraftSummaryVM salesDraftSummaryVM { get; set; }
    }
}
