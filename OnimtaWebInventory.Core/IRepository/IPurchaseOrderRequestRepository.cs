using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IPurchaseOrderRequestRepository
    {
        Task<PurchaseOrderMasterVM> AddPurchaseOrderRequest(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderRequestVM> GetPurchaseOrderRequestDetails(int purchaseNo);
        Task<IEnumerable<PurchaseOrderRequestVM>> GetAllPurchaseOrderRequestDetails(int pageId);
        Task<PurchaseOrderItemVM> AddPurchaseOrderRequestItems(PurchaseOrderItemVM  purchaseOrderItemVM,string purchaseNo);
        Task<IEnumerable<PurchaseOrderRequestSummaryVM>> GetPurchaseOrderRequestItemsDetails();
    }
}
