using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Audit
{
  public class AuditResponse :BaseResponse
    {
        public IEnumerable<AuditVM> auditVM { get; set; }
    }
}
