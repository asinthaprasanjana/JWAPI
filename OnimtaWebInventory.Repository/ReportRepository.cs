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
    public class ReportRepository : DBContext, IReportRepository
    {
        public async Task<ReportVM> GetReportDetailsByReportID(int reportId,int companyId)
        {
            ReportVM reportVM = new ReportVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id",reportId);
                dynamicParameterlist.Add("@CompanyId", companyId);
                reportVM = await dbConnection.QuerySingleOrDefaultAsync<ReportVM>("GetReportDetailsByReportID", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return reportVM;
        }
    }
}
