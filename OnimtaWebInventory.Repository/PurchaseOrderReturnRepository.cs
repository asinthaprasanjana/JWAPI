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
    public class PurchaseOrderReturnRepository : DBContext, IPurchaseOrderReturnRepository
    {
        public async Task<PurchaseOrderReturnVM> AddPurchaseOrderReturnDetails(PurchaseOrderReturnVM purchaseOrderReturnVM)
        {
            PurchaseOrderReturnVM purchaseOrderReturnVm = new PurchaseOrderReturnVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(purchaseOrderReturnVM);
                purchaseOrderReturnVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderReturnVM>("stk.AddPurchaseOrderReturnDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderReturnVm;
        }

        public async Task<string> AddPurchaseOrderReturnDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {

            string PurchaseReturnId = "";

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@CompanyId",purchaseOrderMasterVM.CompanyId);
                dynamicParameters.Add("@SupplierId", purchaseOrderMasterVM.SupplierId);
                dynamicParameters.Add("@BillLocationId", int.Parse(purchaseOrderMasterVM.BillTo));
                dynamicParameters.Add("@ShipLocationId", int.Parse(purchaseOrderMasterVM.ShipTo));
                dynamicParameters.Add("@Email", purchaseOrderMasterVM.Email);
                dynamicParameters.Add("@ReturningTotal", purchaseOrderMasterVM.returningTotal);
                dynamicParameters.Add("@Remarks", purchaseOrderMasterVM.Remarks);
                dynamicParameters.Add("@UserId", purchaseOrderMasterVM.UserId);

                PurchaseReturnId = await dbConnection.QuerySingleOrDefaultAsync<string>("stk.AddPurchaseOrderReturnDetails",dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return PurchaseReturnId;
        }

        public async Task<PurchaseOrderItemVM> AddPurchaseOrderReturnItemDetails(PurchaseOrderItemVM purchaseOrderItemVM,string PurchaseReturnId)
        {

            PurchaseOrderItemVM purchaseOrderItemVm = new PurchaseOrderItemVM();

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@ItemId", purchaseOrderItemVM.ProductId);
                dynamicParameters.Add("@ReturningQuantity", purchaseOrderItemVM.ReturningQuantity);
                dynamicParameters.Add("@PurchaseOrderReturnId", PurchaseReturnId);
                dynamicParameters.Add("@ReturningPrice", purchaseOrderItemVM.ReturningPrice);
                dynamicParameters.Add("@Reason", purchaseOrderItemVM.Reason);
                dynamicParameters.Add("@UserId", purchaseOrderItemVM.UserId);
                dynamicParameters.Add("@CompanyId", purchaseOrderItemVM.CompanyId);

                purchaseOrderItemVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderItemVM>("stk.AddPurchaseOrderReturnItem", dynamicParameters, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchaseOrderItemVm;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllPurchaseOrderReturnDetails(int companyId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                purchaseOrderMasterVM = await dbConnection.QueryAsync<PurchaseOrderMasterVM>("stk.GetAllPurchaseOrderReturnDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderReturnItemDetailsById(int purchaseOrderReturnId)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderReturnId", purchaseOrderReturnId);
                purchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.GetPurchaseOrderReturnItemDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVM;
        }
    }
}