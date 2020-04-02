using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Dispatch
{
   public  class DispatchRequest:BaseRequest
    {
        public DispatchVM dispatchVM { get; set; }
    }
}
