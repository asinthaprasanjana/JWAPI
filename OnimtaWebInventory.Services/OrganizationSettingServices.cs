using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class OrganizationSettingServices : IOrganizationSettingServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public OrganizationSettingServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyVM> AddNewCompany(CompanyVM companyVM)
        {
            CompanyVM companyVm = new CompanyVM();

         
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    companyVM = await  _unitOfWork.OrganizationSettingRepository.AddNewCompany(companyVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return companyVM;
        }

        public async Task<OrganizationBranchVM> AddOrganizationBranchName(OrganizationBranchVM organizationBranchVM)
        {
            OrganizationBranchVM organizationBranchvm = new OrganizationBranchVM();
            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    organizationBranchvm = await  _unitOfWork.OrganizationSettingRepository.AddOrganizationBranchName(organizationBranchVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return organizationBranchvm;
        }

        public async Task<OrganizationSettingVM> AddOrganizationName(OrganizationSettingVM organizationSettingVm)
        {
            OrganizationSettingVM organizationSettingvm = new OrganizationSettingVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    organizationSettingvm = await  _unitOfWork.OrganizationSettingRepository.AddOrganizationName(organizationSettingVm);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return organizationSettingvm;
        }

        public async Task<IEnumerable<CompanyVM>> GetCompanyDetails()
        {
            IEnumerable<CompanyVM> companyVM;

            try
            {
                companyVM = await _unitOfWork.OrganizationSettingRepository.GetCompanyDetails();

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return companyVM;
        }

        public async Task<OrganizationSettingVM> GetOrganizationSettingDetailaById(int id,int companyId)
        {
            OrganizationSettingVM organizationSettingVM = new OrganizationSettingVM();
            
            using (_unitOfWork)
            {


                try
                {
                organizationSettingVM = await  _unitOfWork.OrganizationSettingRepository.GetOrganizationSettingDetailaById(id, companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return organizationSettingVM;
        }

        public async Task<CompanyVM> UpdateCompanyDetails(CompanyVM companyVM)
        {
            CompanyVM companyVm = new CompanyVM();

            try
            {
                companyVM = await _unitOfWork.OrganizationSettingRepository.UpdateCompanyDetails(companyVM);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return companyVM;
        }
    }
}
