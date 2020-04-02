using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IPurchaseOrderReportRepository
    {
        Task<IEnumerable<PurchaseOrderReportVM>> GetAllPurchaseOrderReportDetails();
        Task<IEnumerable<PurchaseOrderReportVM>> GetPurchaseOrderReportDetailsGroupByApprovalStatus(int companyId);
        Task<IEnumerable<PurchaseOrderReportVM>> GetTopSaleReportDetailsOrderByBranchId();
        Task<IEnumerable<PurchaseOrderReportVM>> GetTopPurchaseReportDetailsOrderByBranchId();
        Task<IEnumerable<ReportVM>> GetNetTotalOfSalesNPurchase(int companyId);
        Task<IEnumerable<ReportVM>> GetTopSalesNPurchaseBranches(int companyId);
        Task<IEnumerable<ReportVM>> GetTopSaleProducts(int companyId);

    }
}
