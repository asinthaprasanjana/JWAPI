using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Dispatch
{
   public class DispatchResponse : BaseResponse
    {
        public IEnumerable<DispatchVM> dispatchVM { get; set; }
    }
}
