using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IDispatchRepository
    {
        Task<DispatchVM> AddNewDispatchDetails(DispatchVM dispatchVM);
        Task<DispatchVM> GetDispatchDetailsById(int id);
        Task<IEnumerable<DispatchVM>> GetAllDispatchDetails(int dispatchTypeId);
        Task<IEnumerable<PurchaseOrderItemVM>> GetGatePassItemsDetails(string DocumentNumber);
    }
}
