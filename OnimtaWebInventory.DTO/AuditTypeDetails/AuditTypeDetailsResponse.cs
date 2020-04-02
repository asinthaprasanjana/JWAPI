using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.AuditTypeDetails
{
   public class AuditTypeDetailsResponse: BaseResponse
    {
        public IEnumerable<AuditTypeDetailsVM> auditTypeDetailsVM { get; set; }
    }
}
