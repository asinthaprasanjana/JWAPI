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
    public class LogsRepository : DBContext, ILogsRepository
    {
        public async Task<IEnumerable<LogsVM>> GetAllLogDetailsByPageId(int pageId)
        {
            IEnumerable<LogsVM> logsVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", pageId);
                logsVM = await dbConnection.QueryAsync<LogsVM>("dbo.GetAllLogDetailsByPageId", dynamicParameterlist, commandType:CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return logsVM;
        }

        public async Task<IEnumerable<LogsVM>> GetLogsDetailsByLevel(string level)
        {
            IEnumerable<LogsVM> logsVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Level", level);
                logsVM = await dbConnection.QueryAsync<LogsVM>("dbo.GetLogsDetailsByLevel", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return logsVM;
        }
    }
}
