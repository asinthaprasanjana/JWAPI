using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockAdjustmentDetails
{
    public class StockAdjustmentDetailsResponse: BaseResponse
    {
        public IEnumerable<StockAdjustmentDetailVM> StockAdjustmentDetailVM { get; set; }
        public int AvailableStock { get; set; }
    }
}
