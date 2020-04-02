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
    public class StockRepository :DBContext, IStockRepository
    {
      

        public StockRepository( )
        {
           
        }
        public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTransactionDetails(int companyId)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                stockTransferSummeryVM = await dbConnection.QueryAsync<StockTransferSummeryVM>("stk.GetStockTransactionDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }
        public async  Task<StockVM> GetStockDetailsById(int Id,int companyId)
        {
            StockVM stockVM = new StockVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id",Id);
                dynamicParameterlist.Add("@ComapnyId", companyId);
                stockVM = await dbConnection.QuerySingleOrDefaultAsync<StockVM>("stk.GetStockDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
             
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockVM;
        }
        public async Task<StockVM> GetStockTransactionDetailsById(int stockTransactionId,int companyId)
        {
            StockVM stockVM = new StockVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@StockTransactionId", stockTransactionId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                stockVM = await dbConnection.QuerySingleOrDefaultAsync<StockVM>("stk.GetStockTransactionDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockVM;
        }
       public async Task<IEnumerable<StockVM>> GetItemsBySupplierId(int supplierId,int companyId, string itemName)
        {
            IEnumerable<StockVM> stockVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@SupplierId", supplierId);
                dynamicParameterlist.Add("@ItemName", itemName);
                stockVM = await dbConnection.QueryAsync<StockVM>("stk.GetSupplierItemsBySupplierId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                return stockVM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<IEnumerable<StockVM>> getSupplierItem(int businessPartnerId)
        {
            IEnumerable<StockVM> stockVm;
            try
            {
                var dynamicParam = new DynamicParameters();
                dynamicParam.Add("@BusinessPartnerId", businessPartnerId);
                stockVm = await dbConnection.QueryAsync<StockVM>("stk.GetSupplierItem", dynamicParam, commandType: CommandType.StoredProcedure);
                return stockVm;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StockTransactionTypeVm> GetIdByStockTransactionTypeId(int transactionTypeId ,string referenceNo ,int userId)
        {
            StockTransactionTypeVm stockTransactionTypeVm = new StockTransactionTypeVm();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@TransactionTypeId", transactionTypeId);
                dynamicParameterlist.Add("@ReferenceNo", referenceNo);
                dynamicParameterlist.Add("@UserId", userId);

                stockTransactionTypeVm = await dbConnection.QuerySingleOrDefaultAsync<StockTransactionTypeVm>("stk.GetIdByStockTransactionTypeId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransactionTypeVm;
        }
    }
}


