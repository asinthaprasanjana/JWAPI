using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockTransferItem
{
   public class StockTransferItemResponse:BaseResponse
    {
        public IEnumerable<StockTransferItemVM> stockTransferItemVm { get; set; }

    }
}
