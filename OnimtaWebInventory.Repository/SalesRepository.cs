using Dapper;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DBConnect;
using System.Threading.Tasks;
using System.Data;

namespace OnimtaWebInventory.Repository
{
    public class SalesRepository : DBContext,ISalesRepository
    {
        public async Task<SalesSummaryVM> GetSalesSummeryDetails(int companyId)
        {
            SalesSummaryVM salesSummaryVM = new SalesSummaryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId",companyId);
                salesSummaryVM = await dbConnection.QuerySingleOrDefaultAsync<SalesSummaryVM>("stk.GetSalesOrderId", dynamicParameterlist,commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return salesSummaryVM;
        }

        public async Task<SalesOrderMasterVM> GetSalesOrderDetailsById(string salesOrderId, int companyId)
        {
            SalesOrderMasterVM salesOrderMasterVM = new SalesOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SaleNo", salesOrderId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                salesOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<SalesOrderMasterVM>("stk.GetSalesOrderDetailsBySalesOrderId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderMasterVM;
        }
        public async Task<IEnumerable<SalesOrderMasterVM>> GetSalesOrderDetailsBySaleOrderIds(string saleNos)
        {
            IEnumerable<SalesOrderMasterVM> salesOrderMasterVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SaleNos", saleNos);
                salesOrderMasterVM = await dbConnection.QueryAsync<SalesOrderMasterVM>("stk.GetSalesOrderDetailsBySaleNos", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderMasterVM;
        }

        public async Task<IEnumerable<SalesOrderItemVM>> GetSalesOrderItemDetailsBySaleOrderIds(string saleNos)
        {
            IEnumerable<SalesOrderItemVM> salesOrderitemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SaleNos", saleNos);
                salesOrderitemVM = await dbConnection.QueryAsync<SalesOrderItemVM>("stk.GetSalesOrderItemsBySalesOrderIDs", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderitemVM;
        }
        public async Task<IEnumerable<SalesOrderMasterVM>> GetSalesOrderDetailsByBusinessPartnerId(string businessPartnerId, int companyId)
        {
            IEnumerable<SalesOrderMasterVM> salesOrderMasterVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BusinessPartnerId", businessPartnerId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                salesOrderMasterVM = await dbConnection.QueryAsync<SalesOrderMasterVM>("stk.GetSalesOrderDetailsByBusinessPartnerId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderMasterVM;
        }

        public async Task<SalesOrderMasterVM> GetSalesOrderDraftDetailsById(string salesOrderId, int companyId)
        {
            SalesOrderMasterVM salesOrderMasterVM = new SalesOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SaleNo", salesOrderId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                salesOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<SalesOrderMasterVM>("stk.GetSalesOrderDraftDetailsBySalesOrderId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderMasterVM;
        }

        public async Task<IEnumerable<SalesOrderItemVM>> GetSalesOrderItemDetailsById(string salesOrderId)
        {
            IEnumerable<SalesOrderItemVM> salesOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SaleNo", salesOrderId);
                salesOrderItemVM = await dbConnection.QueryAsync<SalesOrderItemVM>("stk.GetSalesOrderItemsBySalesOrderID", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderItemVM;
        }

        public async Task<IEnumerable<SalesOrderItemVM>> GetSalesOrderItemDraftDetailsById(string salesOrderId)
        {
            IEnumerable<SalesOrderItemVM> salesOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SaleNo", salesOrderId);
                salesOrderItemVM = await dbConnection.QueryAsync<SalesOrderItemVM>("stk.GetSalesOrderDraftItemsBySalesOrderID", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderItemVM;
        }

        public async Task<IEnumerable<SalesViewVM>> GetSalesViewDetails(int companyId)
        {
            IEnumerable<SalesViewVM> salesViewVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                salesViewVM = await dbConnection.QueryAsync<SalesViewVM>("stk.GetSalesOrderDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return salesViewVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SalesSummaryVM> AddSalesSummeryDetails(SalesSummaryVM salesSummaryVM)
        {
            SalesSummaryVM newSalesSummaryVM = new SalesSummaryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(salesSummaryVM);
                newSalesSummaryVM = await dbConnection.QuerySingleOrDefaultAsync<SalesSummaryVM>(" stk.AddSalesOrderSummeryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return newSalesSummaryVM;
        }

        public async Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderDraftSummaryDetailsByUserId(int companyId, int userId)
        {
            IEnumerable<SalesDraftSummaryVM> salesDraftSummaryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                dynamicParameterlist.Add("@UserId", userId);
                salesDraftSummaryVM = await dbConnection.QueryAsync<SalesDraftSummaryVM>(" stk.GetSalesOrderDraftSummaryDetailsByUserId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return salesDraftSummaryVM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderDraftSummaryDetailsByCompanyId(int companyId)
        {
            IEnumerable<SalesDraftSummaryVM> salesDraftSummaryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                salesDraftSummaryVM = await dbConnection.QueryAsync<SalesDraftSummaryVM>(" stk.GetSalesOrderDraftSummaryDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return salesDraftSummaryVM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderSummaryDetailsByCompanyId(int isApproved)
        {
            IEnumerable<SalesDraftSummaryVM> salesSummaryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@IsApproved", isApproved);
                dynamicParameterlist.Add("@IsInvoiced", 0);

                salesSummaryVM = await dbConnection.QueryAsync<SalesDraftSummaryVM>(" stk.GetSalesOrderSummaryDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return salesSummaryVM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SalesOrderItemVM> AddSalesOrderItemDetails(SalesOrderItemVM salesOrderItemVM)
        {
            SalesOrderItemVM salesOrderItemVm = new SalesOrderItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("ItemId", salesOrderItemVM.ItemId);
                dynamicParameterlist.Add("ItemName", salesOrderItemVM.ItemName);
                dynamicParameterlist.Add("Quantity", salesOrderItemVM.Quantity);
                dynamicParameterlist.Add("salesOrderId", salesOrderItemVM.salesOrderId);
                dynamicParameterlist.Add("salesOrderItemId", salesOrderItemVM.salesOrderItemId);
                dynamicParameterlist.Add("ItemCost", salesOrderItemVM.ItemCost);
                dynamicParameterlist.Add("Discount", salesOrderItemVM.Discount);
                dynamicParameterlist.Add("Tax", salesOrderItemVM.Tax);
                dynamicParameterlist.Add("TotalCost", salesOrderItemVM.TotalCost);
                dynamicParameterlist.Add("UserId", salesOrderItemVM.UserId);
                dynamicParameterlist.Add("CompanyId", salesOrderItemVM.CompanyId);
                salesOrderItemVm = await dbConnection.QuerySingleOrDefaultAsync<SalesOrderItemVM>(" stk.AddSalesOrderItem", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderItemVm;
        }


        public async Task<SalesOrderItemVM> DeleteSalesOrderItemDetailsBySalesOrderId(int salesOrderId)
        {
            SalesOrderItemVM salesOrderItemVM = new SalesOrderItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SalesOrderItemId", salesOrderId);
                salesOrderItemVM = await dbConnection.QueryFirstOrDefaultAsync<SalesOrderItemVM>(" stk.DeleteSalesOrderItemDetailsBySalesOrderId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderItemVM;
        }

        public async Task<SalesOrderFinalVM> UpdateSalesOrderById(SalesOrderFinalVM salesOrderFinalVM)
        {
            SalesOrderFinalVM salesOrderFinalVm = new SalesOrderFinalVM();
            try
            { 
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SaleNo", salesOrderFinalVM.SaleNo);
                dynamicParameterlist.Add("@GrossTotal", salesOrderFinalVM.GrossTotal);
                dynamicParameterlist.Add("@Discount", salesOrderFinalVM.Discount);
                dynamicParameterlist.Add("@NetTotal", salesOrderFinalVM.NetTotal);
                dynamicParameterlist.Add("@Tax", salesOrderFinalVM.Tax);
                dynamicParameterlist.Add("@UserId", salesOrderFinalVM.UserId);

                salesOrderFinalVm = await dbConnection.QuerySingleOrDefaultAsync<SalesOrderFinalVM>(" stk.UpdateSalesOrderById", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesOrderFinalVm;
        }
    }
}
