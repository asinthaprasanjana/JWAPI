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
    public class PurchaseOrderBillRepository :DBContext, IPurchaseOrderBillRepository
    {
        public async Task<PurchaseOrderMasterVM> AddPurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVm)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseOrderNo", purchaseOrderMasterVm.PurchaseNo);
                dynamicParameterlist.Add("@SupplierBillNo", purchaseOrderMasterVm.BillNo);
                dynamicParameterlist.Add("@BillDate", purchaseOrderMasterVm.BillDate);
                dynamicParameterlist.Add("@Discount", purchaseOrderMasterVm.Discount);
                dynamicParameterlist.Add("@CreatedUserId", purchaseOrderMasterVm.UserId);
                dynamicParameterlist.Add("@TotalPrice", purchaseOrderMasterVm.NetTotal);
                dynamicParameterlist.Add("@CompanyId", purchaseOrderMasterVm.CompanyId);

                purchaseOrderMasterVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("csh.AddPurchaseOrderBillDetails", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderItemVM> AddPurchaseOrderBillEventDetails(PurchaseOrderItemVM  purchaseOrderItemVm , string DocumentNo)
        {
            PurchaseOrderItemVM purchaseOrderItemVM  = new PurchaseOrderItemVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@DocumentNo", DocumentNo);
                dynamicParameterlist.Add("@CreatedUserId", purchaseOrderItemVm.UserId);
                dynamicParameterlist.Add("@BilledPrice", purchaseOrderItemVm.ItemCost);
                dynamicParameterlist.Add("@BilledQuantity", purchaseOrderItemVm.RecievedQuantity);
                dynamicParameterlist.Add("@ProductId", purchaseOrderItemVm.ProductId);
                dynamicParameterlist.Add("@PurchaseOrderItemId", purchaseOrderItemVm.purchaseOrderItemId);
                dynamicParameterlist.Add("@PurchaseOrderNo", purchaseOrderItemVm.PurchaseNo);
                dynamicParameterlist.Add("@RecievedDocumentNo", purchaseOrderItemVm.DocumentNo);
                dynamicParameterlist.Add("@CompanyId", purchaseOrderItemVm.CompanyId);

                purchaseOrderItemVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderItemVM>("csh.AddNewPurchaseOrderBillEvent", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderItemVM;
        }

        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetAllBillEventDetailsByCompanyId(int companyId)
        {
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                purchaseOrderBilledEventsVM = await dbConnection.QueryAsync<PurchaseOrderBilledEventsVM>("stk.GetAllBillEventDetailsByCompanyId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderBilledEventsVM;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllPurchaseOrderBillDetails(int pageId)
        {
           IEnumerable<PurchaseOrderMasterVM>purchaseOrderMasterVM ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", pageId);
                purchaseOrderMasterVM = await dbConnection.QueryAsync<PurchaseOrderMasterVM>("stk.GetAllPurchaseOrderBillDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> GetPurchaseOrderBillDetailsByPurchaseNo(int purchaseNo)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            IEnumerable<PurchaseOrderItemVM> PurchaseOrderItemVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PurchaseNo", purchaseNo);
                PurchaseOrderItemVM = await dbConnection.QueryAsync<PurchaseOrderItemVM>("csh.GetPurchaseOrderBillDetailsByPurchaseNo", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                purchaseOrderMasterVM.purchaseOrderItemVM = PurchaseOrderItemVM;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVM;
        }

        public async  Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetPurchaseOrderBilledDetailsByBusinessPartnerId(string businessPartnerId)
        {
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@BusinessPartnerId", businessPartnerId);
                dynamicParameterlist.Add("@PageId", 0);

                purchaseOrderBilledEventsVM = await dbConnection.QueryAsync<PurchaseOrderBilledEventsVM>("stk.GetPurchaseOrderBilledDetailsByBusinessPartnerId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderBilledEventsVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdatePartiallyPurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(purchaseOrderMasterVM);
                purchaseOrderMasterVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("   ", dynamicParameterlist,  commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVm;
        }

        public async Task<PurchaseOrderMasterVM> UpdatePurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(purchaseOrderMasterVM);
                purchaseOrderMasterVm = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderMasterVM>("stk.UpdatePurchaseOrderBillDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderMasterVm;
        }
    }
}
