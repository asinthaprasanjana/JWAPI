using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
   public interface ISalesServices
    {
        Task<SalesSummaryVM> GetSalesSummeryDetails(int companyId);
        Task<SalesSummaryVM> AddSalesSummeryDetails(SalesSummaryVM salesSummaryVM);
        Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderDraftSummaryDetailsByUserId(int companyId, int userId);
        Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderDraftSummaryDetailsByCompanyId(int companyId);
        Task<SalesOrderItemVM> AddSalesOrderItemDetails(SalesOrderItemVM salesOrderItemVM);
        Task<SalesOrderItemVM> DeleteSalesOrderItemDetailsBySalesOrderId(int salesOrderId);
        Task<SalesOrderFinalVM> UpdateSalesOrderById(SalesOrderFinalVM salesOrderFinalVM);
        Task<IEnumerable<SalesViewVM>> GetSalesViewDetails(int companyId);
        Task<SalesOrderMasterVM> GetSalesOrderDetailsById(string salesOrderId, int companyId, bool isDraft);
        Task<IEnumerable<SalesOrderMasterVM>> GetSalesOrderDetailsByBusinessPartnerId(string businessPartnerId, int companyId);
        Task<IEnumerable<SalesOrderMasterVM>> GetSalesOrderDetailsBySaleOrderIds(string saleNos);
        Task<IEnumerable<SalesOrderItemVM>> GetSalesOrderItemDetailsBySaleOrderIds(string saleNos);
        Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderSummaryDetailsByCompanyId(int isApproved);

    }
}
