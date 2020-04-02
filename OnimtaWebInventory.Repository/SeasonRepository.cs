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
    public class SeasonRepository :DBContext, ISeasonRepository
    {
        public async Task<SeasonVM> AddNewSeasonDetails(SeasonVM seasonVM)
        {
            SeasonVM seasonVm = new SeasonVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(seasonVM);
                seasonVm = await dbConnection.QuerySingleOrDefaultAsync<SeasonVM>("stk.AddNewSeasonDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return seasonVm;

        }

        public async Task<IEnumerable<SeasonVM>>GetAllSeasonDetailsById(int id)
        {
            IEnumerable<SeasonVM> seasonVM;
            try
            {
                var dyanmicParameterlist = new DynamicParameters();
                dyanmicParameterlist.Add("@Id", id);
                seasonVM = await dbConnection.QueryAsync<SeasonVM>("stk.GetAllSeasonDetailsById", dyanmicParameterlist, commandType: CommandType.StoredProcedure);
                return seasonVM;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SeasonVM> UpdateSeasonDetails(SeasonVM seasonVM)
        {
            SeasonVM seasonVm = new SeasonVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(seasonVM);
                seasonVm = await dbConnection.QuerySingleOrDefaultAsync<SeasonVM>("stk.UpdateSeasonDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return seasonVm;
        }
    }
}
