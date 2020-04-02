using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface ISalesRepository
    {
        Task<SalesSummaryVM> GetSalesSummeryDetails(int companyId);
        Task<SalesSummaryVM> AddSalesSummeryDetails(SalesSummaryVM salesSummaryVM);
        Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderDraftSummaryDetailsByUserId(int userId, int companyId);
        Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderDraftSummaryDetailsByCompanyId(int companyId);
        Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderSummaryDetailsByCompanyId(int companyId);
        Task<SalesOrderItemVM> AddSalesOrderItemDetails(SalesOrderItemVM salesOrderItemVM);
        Task<SalesOrderItemVM> DeleteSalesOrderItemDetailsBySalesOrderId(int salesOrderId);
        Task<SalesOrderFinalVM> UpdateSalesOrderById(SalesOrderFinalVM salesOrderFinalVM);
        Task<SalesOrderMasterVM> GetSalesOrderDetailsById(string salesorderId, int companyId);
        Task<IEnumerable<SalesOrderMasterVM>> GetSalesOrderDetailsByBusinessPartnerId(string businessPartnerId, int companyId);
        Task<IEnumerable<SalesOrderMasterVM>> GetSalesOrderDetailsBySaleOrderIds(string saleNos);
        Task<IEnumerable<SalesOrderItemVM>> GetSalesOrderItemDetailsBySaleOrderIds(string saleNos);
        Task<IEnumerable<SalesViewVM>> GetSalesViewDetails(int companyId);
        Task<IEnumerable<SalesOrderItemVM>> GetSalesOrderItemDetailsById(string salesOrderId);
        Task<SalesOrderMasterVM> GetSalesOrderDraftDetailsById(string salesOrderId, int companyId);
        Task<IEnumerable<SalesOrderItemVM>> GetSalesOrderItemDraftDetailsById(string salesOrderId);


    }
}
