using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
   public interface IAuditRepository
    {
        Task<IEnumerable<AuditVM>> GetAllAuditDetails(int pageId);
        Task<IEnumerable<AuditVM>> GetAuditDetailsById(string referenceNo1);
        Task<IEnumerable<AuditTypeDetailsVM>> GetAllAuditTypeDetails();
        Task<IEnumerable<AuditVM>> SearchAuditTypeDetails(int userId, int auditTypeId, string auditName);

    }
}
