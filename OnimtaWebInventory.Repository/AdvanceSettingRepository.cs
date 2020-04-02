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
    public class AdvanceSettingRepository : DBContext, IAdavanceSettingRepository
    {
        public async Task<AdvanceSettingVM> AddAdvaneSettingDetails(AdvanceSettingVM advanceSettingVM)
        {
            AdvanceSettingVM advanceSettingVm = new AdvanceSettingVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(advanceSettingVM);
                advanceSettingVM = await dbConnection.QuerySingleOrDefaultAsync<AdvanceSettingVM>("msd.AddAdvaneSettingDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return advanceSettingVM;
        }

        public async Task<IEnumerable<AdvanceSettingVM>> GetAllAdvaneSettingDetails()
        {
            IEnumerable<AdvanceSettingVM> advanceSettingVM ;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                advanceSettingVM = await dbConnection.QueryAsync<AdvanceSettingVM>("msd.GetAllAdvaneSettingDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return advanceSettingVM;
        }

        public async Task<AdvanceSettingVM> UpdateAdvaneSettingDetails(AdvanceSettingVM advanceSettingVM)
        {
            AdvanceSettingVM advanceSettingVm = new AdvanceSettingVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(advanceSettingVM);
                advanceSettingVM = await dbConnection.QuerySingleOrDefaultAsync<AdvanceSettingVM>("msd.UpdateAdvaneSettingDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return advanceSettingVM;
        }
    }
}
