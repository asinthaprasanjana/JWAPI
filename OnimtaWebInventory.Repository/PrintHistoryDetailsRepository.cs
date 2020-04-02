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
    public class PrintHistoryDetailsRepository : DBContext, IPrintHistoryDetailsRepository
    {
        public async Task<IEnumerable<PrintHistoryDetailsVM>> GetAllPrintHistoryDetails(int pageId)
        {
            IEnumerable<PrintHistoryDetailsVM> printHistoryDetailsVM;

            try
            {
                var dynamicParamterlist = new DynamicParameters();
                dynamicParamterlist.Add("@PageId", pageId);
                printHistoryDetailsVM = await dbConnection.QueryAsync<PrintHistoryDetailsVM>("pnt.GetAllPrintHistoryDetails", dynamicParamterlist, commandType:CommandType.StoredProcedure);
                   
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return printHistoryDetailsVM;
        }
    }
}
