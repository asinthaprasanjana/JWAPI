using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Cancellation
{
   public class CancellationRequest :BaseRequest
    {
        public CancellationVM cancellationVM { get; set; }
    }
}
