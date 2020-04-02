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
    public class CashierRepository : DBContext, ICashierRepository
    {
        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> getBillPaymentEventsByBusinessPartnerIdAndBillID(string BillIds)
        {
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM;
            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();
                dynamicParameterList.Add("@BillId",BillIds);
                purchaseOrderBilledEventsVM = await dbConnection.QueryAsync<PurchaseOrderBilledEventsVM>("csh.GetBilledEventsDetailsByBillId", dynamicParameterList, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderBilledEventsVM;
        }

        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> getAllBillPaymentDetails()
        {
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM;
            try
            {
                purchaseOrderBilledEventsVM = await dbConnection.QueryAsync<PurchaseOrderBilledEventsVM>("csh.GetAllBillPaymentDetails", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderBilledEventsVM;
        }
        public async Task<IEnumerable<BillPaymentVM>> getBillPaymentDetailsById(int billId)
        {
            IEnumerable<BillPaymentVM> billPaymentVM;
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("BillId", billId);
                billPaymentVM = await dbConnection.QueryAsync<BillPaymentVM>("csh.GetBillPaymentDetailsByBillId",dynamicParameters ,commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return billPaymentVM;
        }

        public async Task<PurchaseOrderBilledEventsVM> addNewBillPayment(PurchaseOrderBilledEventsVM purchaseOrderBilledEventsVM,int isBalanceToAdvance,decimal balanceAmount,int isAdvancePayments,decimal AdvancePaymentAmount)
        {
            PurchaseOrderBilledEventsVM purchaseOrderBilledEventsVm = new PurchaseOrderBilledEventsVM();
            try
            {
                DynamicParameters dynamicParameterList = new DynamicParameters();
                dynamicParameterList.Add("@BillId", purchaseOrderBilledEventsVM.BillId);
                dynamicParameterList.Add("@BusinessPartnerId", purchaseOrderBilledEventsVM.BusinessPartnerId);
                dynamicParameterList.Add("@TotalPrice", purchaseOrderBilledEventsVM.PayingAmount);
                dynamicParameterList.Add("@BillPaymentTypeId", purchaseOrderBilledEventsVM.BillPaymentTypeId);
                dynamicParameterList.Add("@CreatedUserId", purchaseOrderBilledEventsVM.CreatedUserId);
                dynamicParameterList.Add("@AdvancedPaymentAmount", AdvancePaymentAmount);
                dynamicParameterList.Add("@isAdvancePayments", isAdvancePayments);
                dynamicParameterList.Add("@isBalanceToAdvance", isBalanceToAdvance);
                dynamicParameterList.Add("@BalanceAmount", balanceAmount);
                dynamicParameterList.Add("@PaidAmount", purchaseOrderBilledEventsVM.PaidAmount);
                purchaseOrderBilledEventsVM = await dbConnection.QuerySingleOrDefaultAsync<PurchaseOrderBilledEventsVM>("csh.AddNewBillPayment", dynamicParameterList, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return purchaseOrderBilledEventsVm;
        }

        public async Task<AdvancePaymentVM> getTotalAdvacePaymentsByBusinessPartnerId(string businessPartnerId)
        {
            AdvancePaymentVM advancePaymentVM = new AdvancePaymentVM();
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@BspId", businessPartnerId);
                advancePaymentVM = await dbConnection.QuerySingleOrDefaultAsync<AdvancePaymentVM>("csh.GetAdvancePaymentDetailsByBspId", dynamicParameters,commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return advancePaymentVM;
        }
    }
}
