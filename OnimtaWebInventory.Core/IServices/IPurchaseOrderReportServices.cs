using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IPurchaseOrderReportServices
    {
        Task<IEnumerable<PurchaseOrderReportVM>> GetAllPurchaseOrderReportDetails();
        Task<IEnumerable<PurchaseOrderReportVM>> GetPurchaseOrderReportDetailsGroupByApprovalStatus(int companyId);
        Task<IEnumerable<PurchaseOrderReportVM>> GetTopReportDetailsOrderByBranchId(int isSalesOrder);
        Task<IEnumerable<ReportVM>> GetNetTotalOfSalesNPurchase(int companyId);
        Task<IEnumerable<ReportVM>> GetTopSalesNPurchaseBranches(int companyId);
        Task<IEnumerable<ReportVM>> GetTopSaleProducts(int companyId);



    }
}
