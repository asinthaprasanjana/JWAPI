using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockAdjusment
{
  public  class StockAdjusmentRequest: BaseRequest
    {
        public StockAdjustmentDetailVM stockAdjustmentItemVm { get; set; }
    }
}
