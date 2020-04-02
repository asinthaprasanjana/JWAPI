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
    public class RequisitionRepository :DBContext, IRequisitionRepository
    {
        public async Task<RequisitionVM> AddRequisitionDetails(RequisitionVM requisitionVM)
        {
            RequisitionVM requisitionVm = new RequisitionVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(requisitionVM);
                requisitionVm = await dbConnection.QuerySingleOrDefaultAsync<RequisitionVM>("msd.AddRequisitionDetails", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return requisitionVm;
        }
    }
}
