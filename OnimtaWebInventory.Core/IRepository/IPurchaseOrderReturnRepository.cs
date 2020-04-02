using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IPurchaseOrderReturnRepository
    {
        Task<string> AddPurchaseOrderReturnDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderItemVM> AddPurchaseOrderReturnItemDetails(PurchaseOrderItemVM purchaseOrderItemVM,string purchaseReturnId);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetAllPurchaseOrderReturnDetails(int companyId);
        Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderReturnItemDetailsById(int purchaseOrderReturnId);
    }
}
