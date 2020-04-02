using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesSummary
{
   public class SalesSummaryResponse : BaseResponse
    {
        public IEnumerable<SalesSummaryVM> salesSummaryVMs { get; set; }
        public SalesSummaryVM salesSummaryVM { get; set; }
    }
}
