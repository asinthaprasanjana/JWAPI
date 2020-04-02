using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesView
{
   public class SalesViewResponse : BaseResponse
    {
        public IEnumerable<SalesViewVM> salesViewVM { get; set; }
    }
}
