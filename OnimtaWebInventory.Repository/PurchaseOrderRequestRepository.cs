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
    public class PurchaseOrderRequestRepository :DBContext, IPurchaseOrderRequestRepository
    {
        public async Task<PurchaseOrderMasterVM> AddPurchaseOrderRequest(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Remarks", purchaseOrderMasterVM.Remarks);
                dynamicParameterlist.Add("@CreatedUserId", purchaseOrderMasterVM.CreatedUserId);

                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.AddPurchaseOrderRequest", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderItemVM> AddPurchaseOrderRequestItems(PurchaseOrderItemVM purchaseOrderItemVM , string purchaseNo)
        {
            PurchaseOrderItemVM purchaseOrderItemVm = new PurchaseOrderItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", purchaseOrderItemVM.CompanyId);
                dynamicParameterlist.Add("@PurchaseNo", purchaseNo);
                dynamicParameterlist.Add("@ProductId", purchaseOrderItemVM.ProductId);
                dynamicParameterlist.Add("@Quantity", purchaseOrderItemVM.Quantity);
                dynamicParameterlist.Add("@CreatedUserId", purchaseOrderItemVM.UserId);

                purchaseOrderItemVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderItemVM>("stk.AddPurchaseOrderRequestItems", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVm;
        }

        public async Task<IEnumerable<PurchaseOrderRequestVM>> GetAllPurchaseOrderRequestDetails(int pageId)
        {
           IEnumerable <PurchaseOrderRequestVM> purchaseOrderRequestVM ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId",pageId);
                purchaseOrderRequestVM = await dbConnection.QueryAsync<PurchaseOrderRequestVM>("stk.GetAllPurchaseOrderRequestDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderRequestVM;
        }

        public async Task<PurchaseOrderRequestVM> GetPurchaseOrderRequestDetails(int purchaseNo)
        {
            PurchaseOrderRequestVM purchaseOrderRequestVM = new PurchaseOrderRequestVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseNo", purchaseNo);
                purchaseOrderRequestVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderRequestVM>("stk.GetPurchaseOrderRequestDetails", dynamicParameterlist,commandType:CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderRequestVM;
        }

        public async Task<IEnumerable<PurchaseOrderRequestSummaryVM>> GetPurchaseOrderRequestItemsDetails()
        {
            IEnumerable<PurchaseOrderRequestSummaryVM> purchaseOrderRequestItemsVM;
            try
            {
                purchaseOrderRequestItemsVM = await dbConnection.QueryAsync<PurchaseOrderRequestSummaryVM>("stk.GetPurchaseOrderRequestItemsDetails",  commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderRequestItemsVM;
        }
    }
}
