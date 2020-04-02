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
    public class GeneralSettingRepository :DBContext,IGeneralSettingRepository
    {
        public async Task<PaymentMethodVM> AddNewPaymentDetails(PaymentMethodVM paymentMethodVM)
        {
            PaymentMethodVM paymentMethodVm = new PaymentMethodVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PaymentMethodName", paymentMethodVM.PaymentMethodName);
                dynamicParameterlist.Add("@StartDate", paymentMethodVM.StartDate);
                dynamicParameterlist.Add("@EndDate", paymentMethodVM.EndDate);
                paymentMethodVM = await dbConnection.QuerySingleOrDefaultAsync<PaymentMethodVM>("csh.AddNewPaymentDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paymentMethodVM;
        }

        public async Task<IEnumerable<PaymentMethodVM>> GetAllPaymentDetails()
        {
            IEnumerable<PaymentMethodVM> paymentMethodVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                paymentMethodVM = await dbConnection.QueryAsync<PaymentMethodVM>("csh.GetAllPaymentMethodDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paymentMethodVM;
        }

        public async Task<PaymentMethodVM> UpdatePaymentDetails(PaymentMethodVM paymentMethodVM)
        {
            PaymentMethodVM paymentMethodVm = new PaymentMethodVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(paymentMethodVM);
                paymentMethodVM = await dbConnection.QuerySingleOrDefaultAsync<PaymentMethodVM>("csh.UpdatePaymentDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paymentMethodVM;
        }
    }
}
