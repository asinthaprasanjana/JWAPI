using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface ILogsServices
    {
        Task<IEnumerable<LogsVM>> GetAllLogDetailsByPageId(int pageId);
        Task<IEnumerable<LogsVM>> GetLogsDetailsByLevel(string level);
    }
}
