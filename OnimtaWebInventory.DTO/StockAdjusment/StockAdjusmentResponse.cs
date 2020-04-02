using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockAdjusment
{
   public class stockAdjustmentSummeryVM : BaseResponse
    {
        public IEnumerable<StockAdjustmentDetailVM> stockAdjustmentItemVm { get; set; }
    }
}
