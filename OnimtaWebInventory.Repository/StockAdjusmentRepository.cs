using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class StockAdjusmentRepository : DBContext, IStockAdjusmentRepository
    {
       

        public StockAdjusmentRepository()
        {
         
        }
        public async Task<IEnumerable<StockAdjustmentSummeryVM>> GetStockAdjusmentSummeryByCompanyId(int companyId)
        {
           IEnumerable<StockAdjustmentSummeryVM> stockAdjustmentSummeryVM ;
            try
             {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                stockAdjustmentSummeryVM = await dbConnection.QueryAsync<StockAdjustmentSummeryVM>("stk.GetStockAdjusmentSummeryByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return stockAdjustmentSummeryVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockAdjustmentSummeryVM;
        }

        public async Task<StockAdjustmentSummeryVM> AddStockAdjusmentSummeryDetails(StockAdjustmentSummeryVM stockAdjustmentSummeryVM)
        {
            StockAdjustmentSummeryVM stockAdjustmentSummeryVm = new StockAdjustmentSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", stockAdjustmentSummeryVM.CompanyID);
                dynamicParameterlist.Add("@BranchId", stockAdjustmentSummeryVM.BranchId);
                dynamicParameterlist.Add("@CreatedUserId", stockAdjustmentSummeryVM.CreatedUserId);
                stockAdjustmentSummeryVm = await dbConnection.QuerySingleOrDefaultAsync<StockAdjustmentSummeryVM>("stk.AddStockAdjustmentSummery", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockAdjustmentSummeryVm;
        }

        public async Task<StockAdjustmentSummeryVM> GetStockAdjusmentId(int companyId)
        {
            StockAdjustmentSummeryVM stockAdjustmentSummeryVM = new StockAdjustmentSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId",companyId);
                stockAdjustmentSummeryVM = await dbConnection.QuerySingleOrDefaultAsync<StockAdjustmentSummeryVM>("GetStockAdjusmentId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockAdjustmentSummeryVM;
        }

        public async Task<StockAdjustmentSummeryVM> GetStockAdjusmentDetailsById( int companyId)
        {
            StockAdjustmentSummeryVM stockAdjustmentSummeryVM = new StockAdjustmentSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyID", companyId);
                stockAdjustmentSummeryVM = await dbConnection.QuerySingleOrDefaultAsync<StockAdjustmentSummeryVM>("stk.GetStockAdjustmentID", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockAdjustmentSummeryVM;
        }

        public async Task<StockAdjustmentDetailVM> AddstockAdjusmentDetails(StockAdjustmentDetailVM StockAdjustmentDetailVM)
        {
            IEnumerable<StockAdjustmentDetailVM> StockAdjustmentDetailVm;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@StockAdjustmentId", StockAdjustmentDetailVM.StockAdjustmentId);
                dynamicParameterlist.Add("@ProductId", StockAdjustmentDetailVM.ProductId);
                dynamicParameterlist.Add("@SupplierCode", StockAdjustmentDetailVM.SupplierCode);
                dynamicParameterlist.Add("@NewQuantity", StockAdjustmentDetailVM.NewQuantity);
                dynamicParameterlist.Add("@Variance", StockAdjustmentDetailVM.variance);
                dynamicParameterlist.Add("@Comment", StockAdjustmentDetailVM.Comment);
                dynamicParameterlist.Add("@PackSizeId", StockAdjustmentDetailVM.PackSizeId);
                dynamicParameterlist.Add("@AvailableStock", StockAdjustmentDetailVM.AvailableStock);
                dynamicParameterlist.Add("@BranchId", StockAdjustmentDetailVM.BranchId);
                dynamicParameterlist.Add("@CreatedUserId", StockAdjustmentDetailVM.CreatedUserId);
                StockAdjustmentDetailVm = await dbConnection.QueryAsync<StockAdjustmentDetailVM>("stk.AddStockAdjustmentDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
                return StockAdjustmentDetailVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return StockAdjustmentDetailVM;
        }

        public Task<StockAdjustmentDetailVM> AddstockAdjusmentItemDetails(StockAdjustmentDetailVM stockAdjustmentItemVM)
        {
            throw new NotImplementedException();
        }

     

        public async Task<IEnumerable<StockAdjustmentDetailVM>> GetProductStockCountByBranchId(int BranchId,int ProductId)
        {
            int availbleStock;
            IEnumerable<StockAdjustmentDetailVM> StockAdjustmentDetailVm;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchId", BranchId);
                dynamicParameterlist.Add("@ProductId", ProductId);
                StockAdjustmentDetailVm = await dbConnection.QueryAsync<StockAdjustmentDetailVM>("stk.GetProductStockCountByBranchId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return StockAdjustmentDetailVm;
        }

        public async Task<IEnumerable<StockAdjustmentDetailVM>> GetStockAdjusmentDetailsByAdjusmentId(string StockAdjustmentId)
        {
            IEnumerable<StockAdjustmentDetailVM> StockAdjustmentDetailVm;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@StockAdjustmentId", StockAdjustmentId);
                StockAdjustmentDetailVm = await dbConnection.QueryAsync<StockAdjustmentDetailVM>("stk.GetStockAdjustmentDetailByAdjusmentId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return StockAdjustmentDetailVm;
        }

        public async Task<IEnumerable<StockAdjustmentSummeryVM>> GetStockAdjusmentSummeryByBranchId(int BranchId)
        {
            IEnumerable<StockAdjustmentSummeryVM> stockAdjustmentSummeryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchId", BranchId);
                stockAdjustmentSummeryVM = await dbConnection.QueryAsync<StockAdjustmentSummeryVM>("stk.GetStockAdjusmentSummeryByBranchId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return stockAdjustmentSummeryVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockAdjustmentSummeryVM;
        }

        public async Task<StockAdjustmentSummeryVM> GetStockAdjusmentSummeryByAdjusmentId(string stockAdjustmentId)
        {
            StockAdjustmentSummeryVM stockAdjustmentSummeryVM = new StockAdjustmentSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@StockAdjustmentId", stockAdjustmentId);
                stockAdjustmentSummeryVM = await dbConnection.QueryFirstOrDefaultAsync<StockAdjustmentSummeryVM>("stk.GetStockAdjusmentSummeryByAdjusmentId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);

            }

            return stockAdjustmentSummeryVM;
        }
    }
    }
    



