using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Cancellation
{
   public class CancellationResponse :BaseResponse
    {
      public  IEnumerable <CancellationVM> cancellationVM { get; set; }
    }
}
