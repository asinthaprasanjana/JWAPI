using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.AuditTypeDetails
{
   public class AuditTypeDetailsRequest :BaseRequest
    {
       public AuditTypeDetailsVM auditTypeDetailsVM { get; set; }
    }
}
