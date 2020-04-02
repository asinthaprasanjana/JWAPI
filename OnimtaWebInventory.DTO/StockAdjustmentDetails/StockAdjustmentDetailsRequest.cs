using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockAdjustmentDetails
{
    public class StockAdjustmentDetailsRequest: BaseRequest
    {
        public IEnumerable<StockAdjustmentDetailVM> StockAdjustmentDetailVM { get; set; }

    }
}
