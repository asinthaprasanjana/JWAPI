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
    public class AdvancePaymentRepository :DBContext, IAdvancePaymentRepository
    {
        public async Task<AdvancePaymentVM> AddNewAdvancePayment(AdvancePaymentVM advancePaymentVM)
        {
            AdvancePaymentVM advancePaymentVm = new AdvancePaymentVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@AdvancePaymentTypeId", advancePaymentVM.AdvancePaymentTypeId);
                dynamicParameterlist.Add("@PaymentMethodId", advancePaymentVM.paymentMethodId);
                dynamicParameterlist.Add("@BusinessPartnerId", advancePaymentVM.BusinessPartnerId);
                dynamicParameterlist.Add("@TotalPrice", advancePaymentVM.TotalPrice);
                dynamicParameterlist.Add("@CreatedUserId", advancePaymentVM.CreatedUserId);
                advancePaymentVM = await dbConnection.QuerySingleOrDefaultAsync<AdvancePaymentVM>("[csh].[AddNewAdvancePayment]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return advancePaymentVM;
        }

        public async Task<AdvancePaymentVM> GetAdvancePaymentDetailsById(string AdvancePaymentId)
        {
            AdvancePaymentVM advancePaymentVM = new AdvancePaymentVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@AdvancePaymentId", AdvancePaymentId);
                advancePaymentVM = await dbConnection.QuerySingleOrDefaultAsync<AdvancePaymentVM>("csh.GetAdvancePaymentDetailsById", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return advancePaymentVM;   
        }

        public async Task<AdvancePaymentVM> GetAdvancePaymentDetailsByBspId(string BusinessPartnerId)
        {
            AdvancePaymentVM advancePaymentVM = new AdvancePaymentVM();
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@BspId", BusinessPartnerId);
                advancePaymentVM = await dbConnection.QuerySingleOrDefaultAsync<AdvancePaymentVM>("msd.GetAdvancePaymentDetailsByBspId", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return advancePaymentVM;
        }

        public async Task<IEnumerable<AdvancePaymentVM>> GetAllAdvancePaymentDetailsByBspId(string BusinessPartnerId)
        {
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@BspId", BusinessPartnerId);
                advancePaymentVM = await dbConnection.QueryAsync<AdvancePaymentVM>("csh.GetAllAdvancePaymentDetailsByBspId", dynamicParamterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return advancePaymentVM;
        }

        public async Task<IEnumerable<AdvancePaymentVM>> GetAllAdvancePaymentDetails()
        {
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                advancePaymentVM = await dbConnection.QueryAsync<AdvancePaymentVM>("csh.GetAllAdvancePaymentDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return advancePaymentVM;
        }
    }
}
