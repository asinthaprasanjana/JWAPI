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
    public class PaymentRepository :DBContext, IPaymentRepository
    {
        public async Task<PaymentVM> AddNewPaymentDetails(PaymentVM paymentVM)
        {
            PaymentVM paymentVm = new PaymentVM();
            try
            {

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PayementDocumentNo", paymentVM.DocumentNo);
                dynamicParameterlist.Add("@PaidAmount", paymentVM.TotalPaidAmount);
                dynamicParameterlist.Add("@BillId", paymentVM.BillId);
                dynamicParameterlist.Add("@PayementMethodTypeId", paymentVM.PayementMethodTypeId);
                dynamicParameterlist.Add("@PayementType", paymentVM.PaymentType);
                dynamicParameterlist.Add("@Reference1", paymentVM.Reference1);
                dynamicParameterlist.Add("@Reference2", paymentVM.Reference2);
                dynamicParameterlist.Add("@Reference3", paymentVM.Reference3);
                dynamicParameterlist.Add("@Reference4", paymentVM.Reference4);
                dynamicParameterlist.Add("@CreatedUserId", paymentVM.UserId);
                paymentVM = await dbConnection.QuerySingleOrDefaultAsync<PaymentVM>("csh.AddNewPaymentitemDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
         
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return paymentVM;
        } 

        public async Task<PaymentVM> AddNewPaymentSummeryDetails(PaymentVM paymentVM)
        {
            PaymentVM paymentVm  = new PaymentVM();
            try
            {

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ReferenceNo", paymentVM.ReferenceNo);
                dynamicParameterlist.Add("@TotalPaidAmount", paymentVM.TotalPaidAmount);
                dynamicParameterlist.Add("@BusinessPartnerId", paymentVM.BusinessPartnerId);
                dynamicParameterlist.Add("@PayementType", paymentVM.PaymentType);
                dynamicParameterlist.Add("@CreatedUserId", paymentVM.UserId);
                paymentVm = await dbConnection.QuerySingleOrDefaultAsync<PaymentVM>("csh.AddNewPaymentSummeryDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return paymentVm;
        }

        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetBusinessPartnerPayableDetails(int pageId, int businessPartnerTypeId, int businessPartnerId)
        {
           IEnumerable<PurchaseOrderBilledEventsVM> paymentVm;
            try
            {

                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", pageId);
                dynamicParameterlist.Add("@BusinessPartnerTypeId", businessPartnerTypeId);
                dynamicParameterlist.Add("@BusinessPartnerId", businessPartnerId);
                paymentVm = await dbConnection.QueryAsync<PurchaseOrderBilledEventsVM>("csh.GetBusinessPartnerPayableDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return paymentVm;
        }

        public async Task<PaymentVM> GetPaymentDetailsByPaymentId(int id)
        {
            PaymentVM paymentVM = new PaymentVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@Id", id);
                paymentVM = await dbConnection.QuerySingleOrDefaultAsync<PaymentVM>("  ", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paymentVM;
        }

        public async Task<IEnumerable<PaymentVM>> GetPaymentHistoryDetails(int pageId,  int businessPartnerId, int businessPartnerTypeId)
        {
            IEnumerable<PaymentVM> paymentVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", pageId);
                dynamicParameterlist.Add("@BusinessPartnerId", businessPartnerId);
                dynamicParameterlist.Add("@BusinessPartnerTypeId", businessPartnerTypeId);

                paymentVM = await dbConnection.QueryAsync<PaymentVM>("csh.GetPaymentHistoryDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paymentVM;
         }

        public async Task<IEnumerable<PaymentItemVM>> GetPaymentHistoryDetailsByDocumentNo(string documentNo)
        {
            IEnumerable<PaymentItemVM> paymentItemVM;

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@DocumentNo", documentNo);
                paymentItemVM = await dbConnection.QueryAsync<PaymentItemVM>("csh.GetPaymentHistoryDetailsByDocumentNo", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paymentItemVM;
        }

        public async Task<IEnumerable<PaymentVM>> GetPymentDetailsByCompanyId(int pageId , int BusinessPartnerTypeId)
        {
            IEnumerable<PaymentVM> paymentVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", pageId);
                dynamicParameterlist.Add("@BusinessPartnerTypeId", BusinessPartnerTypeId);
                paymentVM = await dbConnection.QueryAsync<PaymentVM>("csh.GetAllPaymentDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return paymentVM;
        }

        public async Task<IEnumerable<PaymentItemVM>> GetPymentItemDetailsByDocumentNo(string documentNo)
        {
            IEnumerable<PaymentItemVM> paymentItemVMs ;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@DocumentNo", documentNo);
                paymentItemVMs = await dbConnection.QueryAsync<PaymentItemVM>("csh.GetAllPaymentItemDetailsByDocumentNo", dynamicParameterlist, commandType: CommandType.StoredProcedure);
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return paymentItemVMs;
        }
    }
}
