using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IPurchaseOrderRepository
    {
        Task<IEnumerable< PurchaseOrderSummeryVM>> GetPurchaseOrderSummeryDetails(int searchTypeId, int pageId);
        Task<PurchaseOrderSummeryVM> GetStockPurchaseOrderId(int companyId);
        Task<NewPurchaseOrderVM> AddPurschaseOrderSummeryDetails(NewPurchaseOrderVM  newPurchaseOrderVM);
        Task<PurchaseOrderItemVM> AddPurschaseOrderItemDetails(PurchaseOrderItemVM purchaseOrderItemVM);
        Task<PurchaseOrderMasterVM> GetPurchaseOrderDetailsById( string purchaseorderId, int companyId);
        Task<PurchaseOrderMasterVM> GetPurchaseOrderDraftDetailsById(string purchaseorderId, int companyId);
        Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderItemDetailsById(string purchaseorderId);
        Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderItemDraftDetailsById(string purchaseorderId);
        Task<NewPurchaseOrderVM> UpdatePurchaseOrderSummeryDetailsById(NewPurchaseOrderVM newPurchaseOrderVM);
        Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderDraftDetailsByUserId(int userId);
        Task<PurchaseOrderItemVM> UpdatePurchaseOrderItemDetailsByPurchaseOrderId( PurchaseOrderItemVM purchaseOrderItemVM);
        Task<PurchaseOrderItemVM> DeletePurchaseOrderItemDetailsByPurchaseOrderId(int purchaseOrderId);
        Task<PurchaseOrderFinalVM> UpdatePurchaseOrderById(PurchaseOrderFinalVM purchaseOrderFinalVM);
        Task<IEnumerable<PurchaseDraftSummeryVM>> GetPurchaseOrderDraftSummeryDetailsByUserId(int companyId, int userId);
        Task<NewPurchaseOrderVM> UpdateAllPurchaseOrderRecieved(int purchaseOrderId, int userId);
        Task<PurchaseOrderMasterVM> UpdatePurchaseOrderStatusByPurchaseNo(string purchaseNo,int userId);



    }
}
