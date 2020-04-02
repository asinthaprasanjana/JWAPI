using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface ISalesReturnRepository
    {
        Task<IEnumerable<SalesReturnVM>> GetAllSalesDetails(int orderId);
        Task<SalesReturnVM> GetSalesDetailsById(int orderId);
        Task<SalesReturnVM> AddNewSalesReturnDetails(SalesReturnVM salesReturnVM);
        Task<string> AddNewSalesReturnDetails(SalesOrderMasterVM salesReturnVM);
        Task<SalesReturnVM> UpdateSalesReturnDetails(SalesReturnVM salesReturnVM);
        Task<SalesReturnVM> AddNewSalesReturnItemDetails(SalesOrderItemVM salesReturnMasterVM,string SalesOrderReturnId, string SalesOrderId,int companyId);

        Task<PurchaseOrderMasterVM> AddSalesReturnDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> UpdateSalesReturn(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> GetSalesReturnDetailsById(int id);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetAllSalesReturnDetails(int branchId);
    }
}
