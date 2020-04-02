using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesOrderFinal
{
  public  class SalesOrderFinalRequest : BaseRequest
    {
        public SalesOrderFinalVM salesOrderFinalVM { get; set; }
    }
}
