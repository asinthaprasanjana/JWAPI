using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Stock
{
   public class StockResponse : BaseResponse
    {
        public IEnumerable<StockVM> stockVM { get; set; }
    }
}
