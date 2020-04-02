using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PrintHistoryDetails
{
   public class PrintHistoryDetailsResponse :BaseResponse
    {
        public IEnumerable<PrintHistoryDetailsVM> printHistoryDetailsVM { get; set; }
    }
}
