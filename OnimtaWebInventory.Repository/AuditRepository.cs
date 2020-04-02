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
    public class AuditRepository : DBContext, IAuditRepository
    {
        public async Task<IEnumerable<AuditVM>> GetAllAuditDetails(int pageId)
        {
            IEnumerable<AuditVM> auditVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", pageId);
                auditVM = await dbConnection.QueryAsync<AuditVM>("[msd].[GetAllAuditDetails]", dynamicParameterlist, commandType:CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return auditVM;
        }

        public async Task<IEnumerable<AuditTypeDetailsVM>> GetAllAuditTypeDetails()
        {
            IEnumerable<AuditTypeDetailsVM> auditTypeDetailsVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                auditTypeDetailsVM = await dbConnection.QueryAsync<AuditTypeDetailsVM>("msd.GetAllAuditTypeDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return auditTypeDetailsVM;
        }

        public async Task<IEnumerable<AuditVM>> GetAuditDetailsById(string referenceNo1)
        {
            IEnumerable<AuditVM> auditVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ReferenceNo1", referenceNo1);
                auditVM = await dbConnection.QueryAsync<AuditVM>("[msd].[GetAuditDetailsById]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return auditVM;
        }

        public async  Task<IEnumerable<AuditVM>> SearchAuditTypeDetails(int userId, int auditTypeId, string auditName)
        {
            IEnumerable<AuditVM> auditVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                dynamicParameterlist.Add("@AuditTypeId", auditTypeId);
                dynamicParameterlist.Add("@AuditName", auditName);
                auditVM = await dbConnection.QueryAsync<AuditVM>("msd.SearchAuditTypeDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return auditVM;
        }
    }
}
