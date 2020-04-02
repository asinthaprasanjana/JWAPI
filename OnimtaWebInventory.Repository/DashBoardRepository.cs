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
    public class DashBoardRepository : DBContext, IDashBoardRepository
    {
        public async Task<IEnumerable<DashBoardVM>> GetAllDashBoardDetails(int TypeId)
        {
            IEnumerable<DashBoardVM> dashBoardVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@TypeId", TypeId);
                dashBoardVM = await dbConnection.QueryAsync<DashBoardVM>("GetAllDashBoardDetails", dynamicParameterlist, commandType:CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dashBoardVM;
        }

        public async Task<DashBoardVM> GetReportDetails(int reportTypeId, int branchId, DateTime fromDate, DateTime toDate)
        {
            DashBoardVM dashBoardVM = new DashBoardVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ReportTypeId", reportTypeId);
                dynamicParameterlist.Add("@BranchId", branchId);
                dynamicParameterlist.Add("@FromDate", fromDate);
                dynamicParameterlist.Add("@ToDate", toDate);
                dashBoardVM = await dbConnection.QuerySingleOrDefaultAsync<DashBoardVM>("rptstk.GetReportDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return dashBoardVM;
        }
    }
}
