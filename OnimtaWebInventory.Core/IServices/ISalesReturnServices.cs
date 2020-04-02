using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface ISalesReturnServices
    {
        Task<IEnumerable<SalesReturnVM>> GetAllSalesDetails(int orderId);
        Task<SalesReturnVM> GetSalesDetailsById(int orderId);
        Task<SalesReturnVM> AddNewSalesReturnDetails(SalesOrderMasterVM salesReturnVM);
        Task<SalesReturnVM> UpdateSalesReturnDetails(SalesReturnVM salesReturnVM);

        Task<PurchaseOrderMasterVM> AddSalesReturnDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> UpdateSalesReturn(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> GetSalesReturnDetailsById(int id);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetAllSalesReturnDetails(int branchId);
    }
}
