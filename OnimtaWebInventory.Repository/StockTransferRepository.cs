using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class StockTransferRepository : DBContext, IStockTransferRepository
    {

        public StockTransferRepository( )
        {
          
        }
        public async Task<StockTransferItemVM> AddStockTransferItemDraft(StockTransferItemVM stockTransferItemVM)
        {
            StockTransferItemVM stockTransferItemVm = new StockTransferItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyID", 1);
                dynamicParameterlist.Add("@TransferId", stockTransferItemVM.TransferId);
                dynamicParameterlist.Add("@SourceLocationId", stockTransferItemVM.SourceLocationId);
                dynamicParameterlist.Add("@DestinationLocationId", stockTransferItemVM.DestinationLocationId);
                dynamicParameterlist.Add("@Product", stockTransferItemVM.Product);
                dynamicParameterlist.Add("@Quantity", stockTransferItemVM.Quantity);
                dynamicParameterlist.Add("@PackSize", stockTransferItemVM.PackSize);
                dynamicParameterlist.Add("@PriceLevel", stockTransferItemVM.PriceLevel);
                dynamicParameterlist.Add("@Price", stockTransferItemVM.Price);
                dynamicParameterlist.Add("@Total", stockTransferItemVM.Total);
                dynamicParameterlist.Add("@CreatedUserId", stockTransferItemVM.CreatedUserId);

                stockTransferItemVM = await dbConnection.QueryFirstOrDefaultAsync<StockTransferItemVM>("stk.AddStockTransferItemDraft", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferItemVM;
        }

        public async Task<StockTransferSummeryVM> updateStockTransferDetails(int transferId)
        {
            StockTransferSummeryVM stockTransferSummeryVm = new StockTransferSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@transferId", transferId);
                stockTransferSummeryVm = await dbConnection.QueryFirstOrDefaultAsync<StockTransferSummeryVM>("stk.UpdateStockTransferDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVm;
        }

        public async Task<StockTransferSummeryVM> AddStockTransferSummeryDraftDetails(StockTransferSummeryVM stockTransferSummeryVM)
        {

            StockTransferSummeryVM stockTransferSummeryVm = new StockTransferSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", stockTransferSummeryVM.CompanyId);
                dynamicParameterlist.Add("@SourceLocationId", stockTransferSummeryVM.SourceLocationId);
                dynamicParameterlist.Add("@DestinationLocationId", stockTransferSummeryVM.DestinationLocationId);
                dynamicParameterlist.Add("@CreatedUserId", stockTransferSummeryVM.CreatedUserId);
                stockTransferSummeryVM = await dbConnection.QueryFirstOrDefaultAsync<StockTransferSummeryVM>("stk.AddStockTransferSummeryDetailsDraft", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }

        public async Task<StockTransferItemVM> DeleteStockTransferItemById(int Id)
        {

            StockTransferItemVM stockTransferItemVM = new StockTransferItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id",Id);
                stockTransferItemVM = await dbConnection.QueryFirstOrDefaultAsync<StockTransferItemVM>("stk.DeleteStockTransferItemDraftById", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferItemVM;
        }

        public async Task<StockTransferSummeryVM> GetStockTransferDetailsById( int transferId,int companyId)
        {
            StockTransferSummeryVM stockTransferSummeryVM = new StockTransferSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@StockTransferId", transferId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                stockTransferSummeryVM = await dbConnection.QueryFirstOrDefaultAsync<StockTransferSummeryVM>("[stk].[GetStockTransferDetailsById]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTransferId(int companyId)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId",companyId);
                stockTransferSummeryVM = await dbConnection.QueryAsync<StockTransferSummeryVM>("stk.GetStockTranferSummeryDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
              }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable< StockTransferSummeryVM>> GetStockTransferSummaryDetails(int companyId)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                stockTransferSummeryVM = await dbConnection.QueryAsync<StockTransferSummeryVM>("stk.GetStockTranferSummeryDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }

        //public async Task<IEnumerable<StockTransferItemVM>> updateStockTransferItem(int transferId, int transferIdDraft)
        //{
        //    IEnumerable<StockTransferItemVM> stockTransferItemVM;
        //    try
        //    {
        //        var dynamicParameterlist = new DynamicParameters();
        //        dynamicParameterlist.Add("@TransferId", transferId);
        //        dynamicParameterlist.Add("@TransferIdDraft", transferIdDraft);
        //        stockTransferItemVM = await dbConnection.QueryAsync<StockTransferItemVM>("[dbo].[stk.UpdateStockTransferItem]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return stockTransferItemVM;
        //}

        public async Task<IEnumerable<StockTransferSummeryVM>> GetAllTransferSummeryDraft()
        {

            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                stockTransferSummeryVM = await dbConnection.QueryAsync<StockTransferSummeryVM>("stk.GetAllStockTransferSummeryDraft", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockTransferItemVM>> GetStockTransferItemDraftByTransferId(string TransferId)
        {
            IEnumerable<StockTransferItemVM> stockTransferItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@TransferId", TransferId);
                stockTransferItemVM = await dbConnection.QueryAsync<StockTransferItemVM>("stk.GetStockTransferItemDraftByTransferId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                for(int i = 0; i< stockTransferItemVM.Count(); i++)
                {
                    var productId = new DynamicParameters();
                    productId.Add("@ProductId", stockTransferItemVM.ElementAt(i).Product);
                    stockTransferItemVM.ElementAt(i).ProductObj = await dbConnection.QueryFirstOrDefaultAsync<StockVM>("stk.GetProductAsStockByProductId", productId, commandType: CommandType.StoredProcedure);

                    var packSizeId = new DynamicParameters();
                    packSizeId.Add("@PackSizeId", stockTransferItemVM.ElementAt(i).PackSize);
                    stockTransferItemVM.ElementAt(i).PackSizeObj = await dbConnection.QueryFirstOrDefaultAsync<PackSizeVM>("msd.GetPackSizeDetailsById", packSizeId, commandType: CommandType.StoredProcedure);

                   var PriceLevelId = new DynamicParameters();
                   PriceLevelId.Add("@PriceLevelId", stockTransferItemVM.ElementAt(i).PriceLevel);
                   stockTransferItemVM.ElementAt(i).PriceLevelObj = await dbConnection.QueryFirstOrDefaultAsync<PriceLevelVM>("msd.GetProductPriceLevelById", PriceLevelId, commandType: CommandType.StoredProcedure);
                }
            
}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return stockTransferItemVM;
        }

   

      public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetailsByDestinationId(int BranchId)
        {

            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchId", BranchId);
            
                stockTransferSummeryVM = await dbConnection.QueryAsync<StockTransferSummeryVM>("stk.GetStockTranferSummeryDetailsByDestinationId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockTransferItemVM>> GetStockTransferItemByTransferId(string TransferId)
        {
            IEnumerable<StockTransferItemVM> stockTransferItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@TransferId", TransferId);
                stockTransferItemVM = await dbConnection.QueryAsync<StockTransferItemVM>("stk.GetStockTransferItemByTransferId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return stockTransferItemVM;
        }

        public async Task<StockTransferSummeryVM> UpdateStockTransferSummeryDetailsByTransferId(StockTransferSummeryVM stockTransferSummeryVM)
        {

            StockTransferSummeryVM stockTransferSummeryVm = new StockTransferSummeryVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@TransferId", stockTransferSummeryVM.TransferId);
                dynamicParameterlist.Add("@ReceivedUserId", stockTransferSummeryVM.ReceivedUserId);
                dynamicParameterlist.Add("@Remarks", stockTransferSummeryVM.Remarks);
                dynamicParameterlist.Add("@StockTransferStatus", stockTransferSummeryVM.Status);
                stockTransferSummeryVM = await dbConnection.QueryFirstOrDefaultAsync<StockTransferSummeryVM>("stk.UpdateStockTransferSummeryDetailsbyTransferId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetailsBySourceId(int BranchId)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchId", BranchId);

                stockTransferSummeryVM = await dbConnection.QueryAsync<StockTransferSummeryVM>("stk.GetStockTranferSummeryDetailsBySourceId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetails(int pageNumber, int rows)
        {
            IEnumerable<StockTransferSummeryVM> stockTransfers;
            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();
                dynamicParameterList.Add("PageNumber", pageNumber);
                dynamicParameterList.Add("Rows", rows);

                stockTransfers = await dbConnection.QueryAsync<StockTransferSummeryVM>("stk.GetAllStockTransferSummary", dynamicParameterList, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return stockTransfers;
        }
    }
    
}


