using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockTransactionType
{
   public  class StockTransactionTypeResponse : BaseResponse
    {
        public IEnumerable<StockTransactionTypeVm> stockTransactionTypeVm { get; set; }
    }
}
