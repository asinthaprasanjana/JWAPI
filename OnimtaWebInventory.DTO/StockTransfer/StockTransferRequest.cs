using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockTransfer
{
   public  class StockTransferRequest : BaseRequest
    {
        public StockTransferSummeryVM stockTransferSummeryVM { get; set; }
        public StockTransferItemVM stockTransferItemVm { get; set; }
    }
}
