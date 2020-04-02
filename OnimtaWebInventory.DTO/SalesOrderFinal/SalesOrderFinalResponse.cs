using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesOrderFinal
{
   public  class SalesOrderFinalResponse : BaseResponse
    {
        public IEnumerable<SalesOrderFinalVM> purchaseOrderFinalVM { get; set; }
    }
}
