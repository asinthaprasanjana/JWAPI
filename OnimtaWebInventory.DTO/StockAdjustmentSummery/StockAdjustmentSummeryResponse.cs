using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockAdjustmentSummery
{
   public class StockAdjustmentSummeryResponse:BaseResponse
    {
        public IEnumerable<StockAdjustmentSummeryVM> stockAdjustmentSummeryVM { get; set; }
    }
}
