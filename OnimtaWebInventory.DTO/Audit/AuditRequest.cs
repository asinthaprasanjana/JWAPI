using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Audit
{
   public  class AuditRequest :BaseRequest
    {
        public AuditVM auditVM { get; set; }
    }
}
