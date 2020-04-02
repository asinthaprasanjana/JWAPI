using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface ILogsRepository
    {
        Task<IEnumerable<LogsVM>> GetAllLogDetailsByPageId(int pageId);
        Task<IEnumerable<LogsVM>> GetLogsDetailsByLevel(string level);
    }
}
