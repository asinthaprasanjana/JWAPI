using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IPurchaseOrderReturnServices
    {
        Task<PurchaseOrderMasterVM> AddPurchaseOrderReturnDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetAllPurchaseOrderReturnDetails(int companyId);
        Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderReturnItemDetailsById(int purchaseOrderReturnId);
    }
}
