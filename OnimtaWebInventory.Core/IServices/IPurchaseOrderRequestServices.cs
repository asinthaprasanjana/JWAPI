using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IPurchaseOrderRequestServices
    {
        Task<PurchaseOrderMasterVM> AddPurchaseOrderRequest(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderRequestVM> GetPurchaseOrderRequestDetails(int purchaseNo);
        Task<IEnumerable<PurchaseOrderRequestVM>> GetAllPurchaseOrderRequestDetails(int pageId);
        Task<IEnumerable<PurchaseOrderRequestSummaryVM>> GetPurchaseOrderRequestItemsDetails();
    }
}
