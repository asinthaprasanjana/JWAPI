using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesSummary
{
   public class SalesSummaryRequest : BaseRequest
    {
        public SalesSummaryVM salesSummaryVM { get; set; }
    }
}
