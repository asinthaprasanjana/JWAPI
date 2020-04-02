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
    public class QuotationRepository : DBContext, IQuotationRepository
    {
          public async Task<PurchaseOrderMasterVM> AddNewQuotationDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyID",purchaseOrderMasterVM.CompanyId);
                dynamicParameterlist.Add("@BusinessPartnerID", purchaseOrderMasterVM.BusinessPartnerId);
                dynamicParameterlist.Add("@BusinesspartnerName", purchaseOrderMasterVM.BusinessPartnerName);
                dynamicParameterlist.Add("@BranchID", purchaseOrderMasterVM.BranchId);
                dynamicParameterlist.Add("@CreatedUserId", purchaseOrderMasterVM.CreatedUserId);
                dynamicParameterlist.Add("@GrossTotal", purchaseOrderMasterVM.GrossTotal);
                purchaseOrderMasterVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.AddSalesQuotationSummery", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
           
                throw new Exception(ex.Message);
            }

            return purchaseOrderMasterVm;
        }

          public async Task<IEnumerable<PurchaseOrderItemVM>> AddSalesQuotationProducts(PurchaseOrderItemVM purchaseOrderItemVM)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVMs;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@QuotationID", purchaseOrderItemVM.QuotationId);
                dynamicParameterlist.Add("@ProductID", purchaseOrderItemVM.ProductId);
                dynamicParameterlist.Add("@Quantity", purchaseOrderItemVM.Quantity);
                dynamicParameterlist.Add("@UnitPrice", purchaseOrderItemVM.UnitPrice);
                dynamicParameterlist.Add("@TotalCost", purchaseOrderItemVM.TotalCost);
                purchaseOrderItemVMs = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.AddSalesQuotationProducts", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchaseOrderItemVMs;
        }

          public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllQuotationDetails(int branchId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchId", branchId);
                purchaseOrderMasterVM = await dbConnection.QueryAsync<PurchaseOrderMasterVM>("  ", dynamicParameterlist, commandType: CommandType.StoredProcedure);

             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

           public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllQuotationSummeryByBranchId(int branchId)
        {

            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BranchId", branchId);
                purchaseOrderMasterVM = await dbConnection.QueryAsync<PurchaseOrderMasterVM>("stk.GetAllSalesQuotaionSummaryByBranchId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

           public async Task<IEnumerable<PurchaseOrderItemVM>> GetAllSalesQuotaionProductByQuotationId(int quotationId)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@QuotationId", quotationId);
                purchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("stk.GetAllSalesQuotaionProductByQuotationId", dynamicParameterlist,commandType:CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return purchaseOrderItemVM;
        }

           public async Task<PurchaseOrderMasterVM> GetQuotationDetailsById(int id)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.GetSalesOrderQuatationDetailsById", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

           public async Task<PurchaseOrderMasterVM> UpdateQuotationDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(purchaseOrderMasterVM);
                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>(" ", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }
    }
}
