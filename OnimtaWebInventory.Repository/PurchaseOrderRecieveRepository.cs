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
    public class PurchaseOrderRecieveRepository : DBContext, IPurchaseOrderRecieveRepository
    {
     
        public async Task<PurchaseOrderMasterVM> GetPurchaseOrderRecievedDetailsByPurchaseNo(string PurchaseOrderNo, int recieveTypeId , int isHistory)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            IEnumerable<PurchaseOrderItemVM> PurchaseOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderID", PurchaseOrderNo);
                dynamicParameterlist.Add("@RecievedTypeId", recieveTypeId);
                dynamicParameterlist.Add("@IsHistory", isHistory);


                PurchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.GetPurchaseOrderRecievedDetailsByPurhcaseOrderId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                purchaseOrderMasterVM.purchaseOrderItemVM = PurchaseOrderItemVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task< IEnumerable< PurchaseOrderSummeryVM>> GetPurchaseOrderRecievedDetailsByCompanyId(int companyId , int isPendingBill ,int pageId)
        {
            IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM;
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@CompanyId", companyId);
                dynamicParamterlist.Add("@isPendingBill", isPendingBill);
                dynamicParamterlist.Add("@RecievedTypeId", 0);
                dynamicParamterlist.Add("@PageId", pageId);

                purchaseOrderSummeryVM = await dbConnection.QueryAsync<PurchaseOrderSummeryVM>("stk.GetPurchaseOrderRecievedDetailsByCompanyId", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderSummeryVM;
        }

        public async Task< IEnumerable< PurchaseOrderItemVM>> GetPurchaseOrderRecieveDetailsByDocumentNo(string documentNo)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@DocumentNo", documentNo);
                purchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.GetPurchaseOrderRecieveDetailsByDocumentNo", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdateAllPurchaseOrderRecieve(string PurchaseOrderNo, int recieveTypeId,int userId,int recieveId,int isRecieving)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM  = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseNo", PurchaseOrderNo);
                dynamicParameterlist.Add("@IsFullyRecieving", isRecieving);
                dynamicParameterlist.Add("@IsFullyBilling", 0);
                dynamicParameterlist.Add("@RecieveTypeId", recieveTypeId);
                dynamicParameterlist.Add("@RecievedId", recieveId);
                dynamicParameterlist.Add("@UserId", userId);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.UpdateFullyPurchaseOrderRecieveAndBill", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

      
        public async Task<PurchaseOrderMasterVM> UpdatePartiallyPurchaseOrderRecieve(PurchaseOrderItemVM  purchaseOrderItemVM, string PurchaseNo, int isBilling )
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            try
            {
               
                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@PurchaseNo", PurchaseNo);
                    dynamicParameterlist.Add("@PurchaseOrderItemId", purchaseOrderItemVM.purchaseOrderItemId);
                    dynamicParameterlist.Add("@RecievedQuantity", purchaseOrderItemVM.RecievedQuantity);
                    dynamicParameterlist.Add("@ReturningQuantity", purchaseOrderItemVM.ReturningQuantity);
                    dynamicParameterlist.Add("@FreeQuantity", purchaseOrderItemVM.freeQuantity);
                    dynamicParameterlist.Add("@IsBilling", isBilling);
                    dynamicParameterlist.Add("@UserId", purchaseOrderItemVM.UserId);
                    dynamicParameterlist.Add("@RecievedTypeId", purchaseOrderItemVM.RecieveTypeId);

                    purchaseOrderMasterVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.UpdatePartiallyPurchaseOrderRecieve", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);
                
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVm;
        }

        public async Task<ExpireDateHandleVM> AddProductExpireDateDetails(ExpireDateHandleVM expireDateHandleVM)
        {
            ExpireDateHandleVM expireDateHandleVm  = new ExpireDateHandleVM();
            try
            {

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderItemId", expireDateHandleVM.purchaseOrderItemId);              
                dynamicParameterlist.Add("@Quantity", expireDateHandleVM.Quantity);
                dynamicParameterlist.Add("@SerialNo", expireDateHandleVM.SerialNo);
                dynamicParameterlist.Add("@ExpireDate", expireDateHandleVM.ExpireDate);
                dynamicParameterlist.Add("@UserId", expireDateHandleVM.UserId);


                expireDateHandleVm = await dbConnection.QuerySingleOrDefaultAsync<ExpireDateHandleVM>("stk.AddProductExpireDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return expireDateHandleVm;
        }
    }
}
