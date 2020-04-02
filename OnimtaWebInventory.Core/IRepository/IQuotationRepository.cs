using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IQuotationRepository
    {
        Task<PurchaseOrderMasterVM> AddNewQuotationDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> UpdateQuotationDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> GetQuotationDetailsById(int id);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetAllQuotationDetails(int branchId);
        Task<IEnumerable<PurchaseOrderItemVM>> AddSalesQuotationProducts(PurchaseOrderItemVM purchaseOrderItemVM);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetAllQuotationSummeryByBranchId(int branchId);
        Task<IEnumerable<PurchaseOrderItemVM>> GetAllSalesQuotaionProductByQuotationId(int quotationId);

    }
}
 