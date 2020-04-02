using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockTransferSummery
{
  public class StockTransferSummeryRequest : BaseRequest
    {
        public StockTransferSummeryVM stockTransferSummeryVM { get; set; }
    }
}
