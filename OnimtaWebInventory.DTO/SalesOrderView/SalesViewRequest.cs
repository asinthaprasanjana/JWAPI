using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesView
{
   public class SalesViewRequest : BaseRequest
    {
        public SalesViewVM salesViewVM { get; set; }
    }
}
