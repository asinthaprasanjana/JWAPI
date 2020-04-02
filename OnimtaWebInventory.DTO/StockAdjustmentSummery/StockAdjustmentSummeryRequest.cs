using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockAdjustmentSummery
{
   public class StockAdjustmentSummeryRequest : BaseRequest
    {
        public StockAdjustmentSummeryVM stockAdjustmentSummeryVM { get; set; }

    }
}
