using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockTransfer
{
   public  class StockTransferSummeryResponse : BaseResponse
    {
        public IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM { get; set; }
    }
}

