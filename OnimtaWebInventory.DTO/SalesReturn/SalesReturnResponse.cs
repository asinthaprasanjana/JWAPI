using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesReturn
{
   public class SalesReturnResponse : BaseResponse
    {
        public IEnumerable<SalesReturnVM> salesReturnVM { get; set; }
    }
}
