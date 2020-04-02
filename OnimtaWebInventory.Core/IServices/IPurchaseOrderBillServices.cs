using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
  public  interface IPurchaseOrderBillServices
    {
        Task<PurchaseOrderMasterVM> AddPurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> UpdatePurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> UpdatePartiallyPurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> GetPurchaseOrderBillDetailsByPurchaseNo(int purchaseNo);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetAllPurchaseOrderBillDetails(int pageId);
        Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetAllBillEventDetailsByCompanyId(int companyId);
        Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetPurchaseOrderBilledDetailsByBusinessPartnerId(string businessPartnerId);

    }
}
