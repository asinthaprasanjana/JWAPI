using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IPrintHistoryDetailsRepository
    {
        Task<IEnumerable<PrintHistoryDetailsVM>> GetAllPrintHistoryDetails(int pageId);
    }
}
