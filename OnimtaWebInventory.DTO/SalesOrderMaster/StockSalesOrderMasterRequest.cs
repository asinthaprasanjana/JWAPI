using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockSalesOrderMaster
{
  public  class StockSalesOrderMasterRequest : BaseRequest
    {
        public SalesOrderMasterVM salesOrderMasterVM { get; set; }
    }
}
