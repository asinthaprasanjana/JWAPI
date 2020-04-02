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
    public class AdvanceSearchRepository :DBContext, IAdvanceSearchRepository
    {
        public async Task<IEnumerable<AdvanceSearchVM>> GetAdvanceSearchDetails(int advanceSearchType)
        {
            IEnumerable<AdvanceSearchVM> advanceSearchVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@AdvanceSearchType", advanceSearchType);
                advanceSearchVM = await dbConnection.QueryAsync<AdvanceSearchVM>("msd.GetAdvanceSearchDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return advanceSearchVM;
        }

        public async Task<IEnumerable<BusinessPartnerVM>> GetBusinessPartnerDetails(BusinessPartnerVM businessPartnerVM)
        {
            IEnumerable<BusinessPartnerVM> businessPartnerVm ;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                 dynamicParameterlist.Add("@BusinessPartnerId", businessPartnerVM.BusinessPartnerId);
                businessPartnerVm = await dbConnection.QueryAsync<BusinessPartnerVM>("bsp.GetBusinessPartnerDetailsByAdvanceSearch", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return businessPartnerVm;
        }
    }
}