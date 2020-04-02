using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IPrintHistoryDetailsServices
    {
        Task<IEnumerable<PrintHistoryDetailsVM>> GetAllPrintHistoryDetails(int pageId);
    }
}
