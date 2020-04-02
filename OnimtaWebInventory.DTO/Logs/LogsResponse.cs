using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Logs
{
   public class LogsResponse :BaseResponse
    {
        public IEnumerable<LogsVM> logsVM { get; set; }
    }
}
