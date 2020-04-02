using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class SalesReturnRepository :DBContext, ISalesReturnRepository
    {
        public async Task<string> AddNewSalesReturnDetails( SalesOrderMasterVM salesReturnVM)
        {
            SalesReturnVM salesReturnVm = new SalesReturnVM();
            string salesReturnId="";
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("SaleNo",salesReturnVM.SaleNo);
                dynamicParameterlist.Add("CompanyId", salesReturnVM.CompanyId);
                dynamicParameterlist.Add("CustomerId", salesReturnVM.CustomerId);
                dynamicParameterlist.Add("BillLocationId", salesReturnVM.BillLocationId);
                dynamicParameterlist.Add("ShipLocationId", salesReturnVM.ShipLocationId);
                dynamicParameterlist.Add("CurrencyId", salesReturnVM.CurrencyId);
                dynamicParameterlist.Add("Email", salesReturnVM.Email);
                dynamicParameterlist.Add("ReturningTotal", salesReturnVM.ReturningTotal);
                dynamicParameterlist.Add("Remarks", salesReturnVM.Remarks);
                dynamicParameterlist.Add("UserId", salesReturnVM.CreatedUserId);
                dynamicParameterlist.Add("LastModifiedUserId", salesReturnVM.LastModifiedUserId);

                salesReturnId = await dbConnection.QuerySingleOrDefaultAsync<string>("stk.AddSalesOrderReturnDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesReturnId;
        }

        public async Task<SalesReturnVM> AddNewSalesReturnItemDetails(SalesOrderItemVM salesOrderItemVM,string SalesOrderReturnId, string SalesOrderId, int companyId)
        {
            SalesReturnVM salesReturnVm = new SalesReturnVM();
            try
            {
                  
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("SalesOrderId", SalesOrderId);
                dynamicParameterlist.Add("CompanyId", companyId);
                dynamicParameterlist.Add("SalesOrderReturnId", SalesOrderReturnId);
                dynamicParameterlist.Add("ReturningQuantity", salesOrderItemVM.ReturningQuantity);
                dynamicParameterlist.Add("ReturningPrice", salesOrderItemVM.ReturningPrice);
                dynamicParameterlist.Add("UserId", salesOrderItemVM.UserId);
                dynamicParameterlist.Add("ItemId", salesOrderItemVM.ItemId);

                salesReturnVm = await dbConnection.QuerySingleOrDefaultAsync<SalesReturnVM>("stk.AddSalesOrderReturnItem", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesReturnVm;
        }

        public Task<SalesReturnVM> AddNewSalesReturnDetails(SalesReturnVM salesReturnVM)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SalesReturnVM>> GetAllSalesDetails(int orderId)
        {
            IEnumerable<SalesReturnVM> salesReturnVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@OrderId", orderId);
                salesReturnVM = await dbConnection.QueryAsync<SalesReturnVM>("stk.GetAllSalesDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesReturnVM;
        }

        public async Task<SalesReturnVM> GetSalesDetailsById(int orderId)
        {
            SalesReturnVM salesReturnVM = new SalesReturnVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@OrderId", orderId);
                salesReturnVM = await dbConnection.QuerySingleOrDefaultAsync<SalesReturnVM>("stk.GetSalesDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesReturnVM;
        }

        public async Task<SalesReturnVM> UpdateSalesReturnDetails(SalesReturnVM salesReturnVM)
        {
            SalesReturnVM salesReturnVm = new SalesReturnVM();
            try
            {
                var dynamicParamterist = new DynamicParameters();
                dynamicParamterist.AddDynamicParams(salesReturnVM);
                salesReturnVm = await dbConnection.QuerySingleOrDefaultAsync<SalesReturnVM>("stk.UpdateSalesReturnDetails", dynamicParamterist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return salesReturnVm;
        }

        public async Task<PurchaseOrderMasterVM> AddSalesReturnDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.AddDynamicParams(purchaseOrderMasterVM);
                purchaseOrderMasterVM = await dbConnection.QueryFirstOrDefaultAsync<PurchaseOrderMasterVM>(" ", dynamicParamterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdateSalesReturn(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(purchaseOrderMasterVM);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("  ", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> GetSalesReturnDetailsById(int id)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@Id", id);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>(" ", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllSalesReturnDetails(int branchId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM ;

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@BranchId", branchId);
                purchaseOrderMasterVM = await dbConnection.QueryAsync<PurchaseOrderMasterVM>("  ", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }
    }
}
