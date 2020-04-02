using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IOrganizationSettingRepository
    {
        Task<OrganizationSettingVM> GetOrganizationSettingDetailaById(int id, int companyId);
        Task<OrganizationSettingVM> AddOrganizationName(OrganizationSettingVM organizationSettingVm);
        Task<OrganizationBranchVM> AddOrganizationBranchName(OrganizationBranchVM organizationBranchVM);
        Task<CompanyVM> AddNewCompany(CompanyVM companyVM);
        Task<CompanyVM> UpdateCompanyDetails(CompanyVM companyVM);
        Task<IEnumerable<CompanyVM>> GetCompanyDetails();

    }
}
