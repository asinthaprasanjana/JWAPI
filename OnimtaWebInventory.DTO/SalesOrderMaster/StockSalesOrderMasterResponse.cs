using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockSalesOrderMaster
{
  public class StockSalesOrderMasterResponse : BaseResponse
    {
        public IEnumerable<SalesOrderMasterVM> salesOrderMasterVM { get; set; }
        public IEnumerable<SalesOrderMasterVM> salesOrderMasterVMs { get; set; }

    }
}
