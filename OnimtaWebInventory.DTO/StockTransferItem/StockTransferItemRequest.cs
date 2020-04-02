using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockTransferItem
{
  public  class StockTransferItemRequest : BaseRequest
    {
        public StockTransferItemVM stockTransferItemVM { get; set; }
    }
}
