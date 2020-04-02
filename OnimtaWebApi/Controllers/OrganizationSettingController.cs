using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.OrganizationSetting;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{

    [Route("api/[controller]/[action]")]
   // [Authorize]
    public class OrganizationSettingController : Controller
    {
        private IOrganizationSettingServices _organizationSettingServices;
        private ILogger<OrganizationSettingController> _logger;
     

        public OrganizationSettingController(IOrganizationSettingServices OrganizationSettingServices, ILogger<OrganizationSettingController> logger)
        {
            _organizationSettingServices = OrganizationSettingServices;
            _logger = logger;
        }

        [HttpGet("{id},{companyId}")]
        public async Task<OrganizationSettingResponse> GetOrganizationSettingDetailaById(int id,int companyId)
        {
            OrganizationSettingResponse organizationSettingResponse = new OrganizationSettingResponse();
            IEnumerable<OrganizationSettingVM> organizationSettingVM;

            try
            {
                organizationSettingVM = new List<OrganizationSettingVM>()
                { 
                        await _organizationSettingServices.GetOrganizationSettingDetailaById(id,companyId)
                 };

                organizationSettingResponse.organizationSettingVM = organizationSettingVM;
                organizationSettingResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
              _logger.LogError(exc.Message );
                organizationSettingResponse.IsSuccess = false;
                organizationSettingResponse.Message = exc.Message;
            }
            return organizationSettingResponse;
        }

        [HttpPost]
        public async Task<OrganizationSettingResponse> AddOrganizationName([FromBody]OrganizationSettingRequest organizationSettingRequest)
        {
            OrganizationSettingResponse organizationSettingResponse = new OrganizationSettingResponse();
           IEnumerable< OrganizationSettingVM> organizationSettingvm;
            try
            {
                organizationSettingvm =  new List<OrganizationSettingVM>{
                    await _organizationSettingServices.AddOrganizationName(organizationSettingRequest.organizationSettingVM)
                };
                organizationSettingResponse.organizationSettingVM = organizationSettingvm;
                organizationSettingResponse.IsSuccess = true;
                _logger.LogInformation(organizationSettingRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                organizationSettingResponse.IsSuccess = false;
                organizationSettingResponse.Message = exc.Message;
            }
            return organizationSettingResponse;
        }
        [HttpPost]
        public async Task<OrganizationBranchResponse> AddOrganizationBranchName([FromBody]OrganizationBranchRequest organizationBranchRequest)
        {
            OrganizationBranchResponse organizationBranchResponse = new OrganizationBranchResponse();
           IEnumerable< OrganizationBranchVM >organizationBranchvm;
            try
            {
                organizationBranchvm = new List<OrganizationBranchVM>{
                    await _organizationSettingServices .AddOrganizationBranchName(organizationBranchRequest.organizationBranchvm) };
                organizationBranchResponse.organizationBranchvm = organizationBranchvm;
                organizationBranchResponse.IsSuccess = true;
                _logger.LogInformation(organizationBranchRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                organizationBranchResponse.IsSuccess = false;
                organizationBranchResponse.Message = exc.Message;
            }
            return organizationBranchResponse;
        }

        [HttpPost]
        public async Task<CompanyResponse> AddNewCompany([FromBody]CompanyRequest companyRequest)
        {
            CompanyResponse companyResponse = new CompanyResponse();
            IEnumerable<CompanyVM> companyVM;
            try
            {
                companyVM = new List<CompanyVM>
                {
                    await _organizationSettingServices.AddNewCompany(companyRequest.companyVM)
                 };
                companyResponse.companyVM = companyVM;
                companyResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                companyResponse.IsSuccess = false;
                companyResponse.Message = ex.Message;
            }
            return companyResponse;
        }

        [HttpPut]
        public async Task<CompanyResponse> UpdateCompanyDetails([FromBody]CompanyRequest companyRequest)
        {
            CompanyResponse companyResponse = new CompanyResponse();
            IEnumerable<CompanyVM> companyVM;

            try
            {
                companyVM = new List<CompanyVM>
                {
                    await _organizationSettingServices.UpdateCompanyDetails(companyRequest.companyVM)
                };
                companyResponse.companyVM = companyVM;
                companyResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                companyResponse.IsSuccess = false;
                companyResponse.Message = ex.Message;
            }

            return companyResponse;
        }

        [HttpGet]
        public async Task<CompanyResponse> GetCompanyDetails()
        {
            CompanyResponse companyResponse = new CompanyResponse();
            IEnumerable<CompanyVM> companyVM;

            try
            {
                companyVM = await _organizationSettingServices.GetCompanyDetails();
                companyResponse.companyVM = companyVM;
                companyResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                companyResponse.IsSuccess = false;
                companyResponse.Message = ex.Message;
            }

            return companyResponse;
        }
    }
}