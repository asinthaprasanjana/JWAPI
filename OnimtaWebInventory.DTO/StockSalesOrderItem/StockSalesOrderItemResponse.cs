using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.StockSalesOrderItem
{
  public class StockSalesOrderItemResponse : BaseResponse
    {
        public IEnumerable < SalesOrderItemVM> salesOrderItemVM { get; set; }

    }
}
