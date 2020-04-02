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
    public class CurrencyRepository : DBContext, ICurrencyRepository
    {
        public async Task<CurrencyVM> AddNewCurrencyDetails(CurrencyVM currencyVM)
        {
            CurrencyVM currencyVm = new CurrencyVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", currencyVM.CompanyId);
                dynamicParameterlist.Add("@CurrencyId", currencyVM.CurrencyId);
                dynamicParameterlist.Add("@CurrencyName", currencyVM.CurrencyName);
                dynamicParameterlist.Add("@CreatedUserId", currencyVM.CreatedUserId);
                dynamicParameterlist.Add("@DisplayName", currencyVM.DisplayName);
                currencyVm = await dbConnection.QuerySingleOrDefaultAsync<CurrencyVM>("msd.AddNewCurrencyDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return currencyVM;
        }

        public async Task<IEnumerable<CurrencyVM>> GetCurrencyDetails(int companyId)
        {
            IEnumerable<CurrencyVM> currencyVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId",companyId);
                currencyVM = await dbConnection.QueryAsync<CurrencyVM>("msd.GetCurrencyDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return currencyVM;
        }
    }
}
