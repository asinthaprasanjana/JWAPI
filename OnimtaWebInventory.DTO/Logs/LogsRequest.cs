using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Logs
{
   public class LogsRequest :BaseRequest
    {
        public LogsVM logsVM { get; set; }
    }
}
