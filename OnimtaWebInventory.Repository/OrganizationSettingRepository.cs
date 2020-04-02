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
    public class OrganizationSettingRepository : DBContext, IOrganizationSettingRepository
    {
        public async Task<CompanyVM> AddNewCompany(CompanyVM companyVM)
        {
            CompanyVM companyVm = new CompanyVM();

            try
            {
                var dynamicparamterlist = new DynamicParameters();
                dynamicparamterlist.AddDynamicParams(companyVM);
                companyVM = await dbConnection.QuerySingleOrDefaultAsync<CompanyVM>("msd.AddNewCompany", dynamicparamterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return companyVM;
        }

        public async Task<OrganizationBranchVM> AddOrganizationBranchName(OrganizationBranchVM organizationBranchVM)
        {
            OrganizationBranchVM organizationBranchvm = new OrganizationBranchVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", organizationBranchVM.Name);
                organizationBranchVM = await dbConnection.QuerySingleOrDefaultAsync<OrganizationBranchVM>("AddOrganizationBranchName", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return organizationBranchVM;
        }

        public async Task<OrganizationSettingVM> AddOrganizationName(OrganizationSettingVM organizationSettingVm)
        {
            OrganizationSettingVM organizationSettingVM = new OrganizationSettingVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", organizationSettingVM.Name);
                organizationSettingVM = await dbConnection.QuerySingleOrDefaultAsync<OrganizationSettingVM>("AddOrganizationName", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return organizationSettingVM;
        }

        public async Task<IEnumerable<CompanyVM>> GetCompanyDetails()
        {
            IEnumerable<CompanyVM> companyVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                companyVM = await dbConnection.QueryAsync<CompanyVM>("msd.GetCompanyDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return companyVM;
        }

        public async Task<OrganizationSettingVM> GetOrganizationSettingDetailaById(int id, int companyId)
        {
            OrganizationSettingVM organizationSettingVM = new OrganizationSettingVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id",id);
                dynamicParameterlist.Add("@CompanyId", companyId);
                organizationSettingVM = await dbConnection.QuerySingleOrDefaultAsync<OrganizationSettingVM>("GetOrganizationSettingDetailaById", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return organizationSettingVM;
        }

        public async Task<CompanyVM> UpdateCompanyDetails(CompanyVM companyVM)
        {
            CompanyVM companyVm = new CompanyVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(companyVM);
                companyVM = await dbConnection.QuerySingleOrDefaultAsync<CompanyVM>("msd.UpdateCompanyDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return companyVM;
        }
    }
}
