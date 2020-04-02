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
    public class TaxRepository : DBContext,ITaxRepository
    {
        public async Task<TaxVM> AddTaxDetails(TaxVM taxVM)
        {
            TaxVM taxVm = new TaxVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@TaxName", taxVM.TaxName);
                dynamicParameterlist.Add("@TaxGroup", taxVM.IsTaxGroup);
                dynamicParameterlist.Add("@TaxId", taxVM.TaxId);
                dynamicParameterlist.Add("@CompoundTax", taxVM.IsCompoundTax);
                dynamicParameterlist.Add("@Percentage", taxVM.Percentage);
                taxVM = await dbConnection.QuerySingleOrDefaultAsync<TaxVM>("[msd].[AddTaxDetails]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return taxVm;
        }

        public async Task<IEnumerable<TaxVM>> GetTaxDetails()
        {
            IEnumerable<TaxVM> taxVm;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
               
                taxVm = await dbConnection.QueryAsync<TaxVM>("[msd].[GetTaxDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return taxVm;
        }

        public async Task<TaxVM> GetTaxDetailsByTaxNumber(int taxNo,int companyId)
        {
            TaxVM taxVM = new TaxVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", taxNo);
                dynamicParameterlist.Add("@CompanyId", companyId);
                taxVM = await dbConnection.QuerySingleOrDefaultAsync<TaxVM>("[msd].[GetTaxDetailsByTaxNumber]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return taxVM;
        }

        public async Task<TaxVM> UpdateTaxDetails(TaxVM taxVM)
        {
            TaxVM taxVm = new TaxVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", taxVM.Id);
                dynamicParameterlist.Add("@TaxName", taxVM.TaxName);
                dynamicParameterlist.Add("@TaxGroup", taxVM.IsTaxGroup);
                dynamicParameterlist.Add("@TaxId", taxVM.TaxId);
                dynamicParameterlist.Add("@CompoundTax", taxVM.IsCompoundTax);
                dynamicParameterlist.Add("@Percentage", taxVM.Percentage);

                taxVM = await dbConnection.QuerySingleOrDefaultAsync<TaxVM>("[msd].[UpdateTaxDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return taxVm;
        }
    }
}