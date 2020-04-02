using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.BusinessPartner;
using OnimtaWebInventory.DTO.BusinessPartnerGroup;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    
    [Route("api/[controller]/[action]")]
    public class BusinessPartnerController : Controller
    {
       
        private ILogger<BusinessPartnerController> _logger;
        private IBusinessPartnerServices _BusinessPartnerServices;

        public BusinessPartnerController(IBusinessPartnerServices businessPartnerServices , ILogger<BusinessPartnerController> logger)
        {
            _BusinessPartnerServices = businessPartnerServices;
            _logger = logger;

        }
        
        [HttpGet("{companyId},{businessPartnerTypeId},{pageId},{isActive}")]
        public async Task<BusinessPartnerResponse> GetBusinessPartnerDetails( int companyId, int businessPartnerTypeId, int pageId,int isActive)
        {
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            IEnumerable<BusinessPartnerVM> businessPartnerVM;
            try
            {
                businessPartnerVM = await _BusinessPartnerServices.GetBusinessPartnerDetails( businessPartnerTypeId,companyId,pageId,isActive);             
                businessPartnerResponse.businessPartnerVM = businessPartnerVM;
                businessPartnerResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message );
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = exc.Message;
            }
            return businessPartnerResponse;
        }
        [HttpPost]
        public async Task<BusinessPartnerResponse> AddBusinessPartner([FromBody] BusinessPartnerRequest newBusinessPartnerRequest)
        {
           IEnumerable <BusinessPartnerVM >businessPartnerVm ;
            BusinessPartnerResponse businesPartnerResponse = new BusinessPartnerResponse();
            try
            {
               businessPartnerVm  = new List<BusinessPartnerVM>{
                     await _BusinessPartnerServices.AddBusinessPartner(newBusinessPartnerRequest.businessPartnerVM)
                    };
                businesPartnerResponse.businessPartnerVM = businessPartnerVm;
                businesPartnerResponse.IsSuccess = true;
                _logger.LogInformation(newBusinessPartnerRequest.ToString());

            }
            catch (Exception exc)
            {
                businesPartnerResponse.IsSuccess = false;
                businesPartnerResponse.Message = exc.Message;
            }
            return businesPartnerResponse;
        }

        [HttpGet("{businessPartnerId}")]
        public async Task<BusinessPartnerResponse> GetBusinessPartnerDetailsByBusinessPartnerId(int businessPartnerId)
        {
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            IEnumerable<BusinessPartnerVM> businessPartnerVM;
            try
            {
                businessPartnerVM = new List<BusinessPartnerVM>
                {
                     await _BusinessPartnerServices.GetBusinessPartnerDetailsByBspId(businessPartnerId)
                };
                businessPartnerResponse.businessPartnerVM = businessPartnerVM;
                businessPartnerResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = exc.Message;
            }
            return businessPartnerResponse;
        }

        [HttpGet]
        public async Task<BusinessPartnerResponse> GetBusinessPartnerBankDetails()
        {
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            IEnumerable<BankVM> bankVM;
            try
            {
                bankVM = await _BusinessPartnerServices.GetBusinessPartnerBanks();
                businessPartnerResponse.bankVM = bankVM;
                businessPartnerResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = exc.Message;
            }
            return businessPartnerResponse;
        }
        [HttpDelete("{businessPartnerId}")]
        public async Task<BusinessPartnerResponse> DeleteBusinessPartner(int businessPartnerId)
        {
            IEnumerable<BusinessPartnerVM> businessPartnerVm;
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            try
            {
                businessPartnerVm = new List<BusinessPartnerVM>
                   {
                       await _BusinessPartnerServices.DeleteBusinessPartner(businessPartnerId)
                   };
                businessPartnerResponse.businessPartnerVM = businessPartnerVm;
                businessPartnerResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = ex.Message;
            }
            return businessPartnerResponse;
        }
        [HttpPut]
        public async Task<BusinessPartnerResponse> UpdateBusinessPartner([FromBody]BusinessPartnerRequest newBusinessPartnerRequest)
        {
            IEnumerable<BusinessPartnerVM> businessPartnerVm;
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            try
            {
                businessPartnerVm = new List<BusinessPartnerVM>
                {
                   await _BusinessPartnerServices.UpdateBusinessPartner(newBusinessPartnerRequest.businessPartnerVM)
                 };
                businessPartnerResponse.businessPartnerVM = businessPartnerVm;
                businessPartnerResponse.IsSuccess = true;
                _logger.LogInformation(newBusinessPartnerRequest.ToString());

            }
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = ex.Message;
            }
            return businessPartnerResponse;
        }

        

        [HttpGet("{name},{businessPartnerTypeId}")]
        public async Task<BusinessPartnerResponse> GetBusinessPartnerDetailsByBSPName(string name, int businessPartnerTypeId)
        {
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            IEnumerable<BusinessPartnerVM> businessPartnerVM;
            try
            {
                businessPartnerVM = await _BusinessPartnerServices.GetBusinessPartnerDetailsByBSPName(name, businessPartnerTypeId);
                businessPartnerResponse.businessPartnerVM = businessPartnerVM;
                businessPartnerResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = ex.Message;
            }
            return businessPartnerResponse;
        }

        [HttpPost]
        public async Task<BusinessPartnerGroupResponse> AddBusinessPartnerGroupDetails([FromBody]BusinessPartnerGroupRequest businessPartnerGroupRequest)
        {
            BusinessPartnerGroupResponse businessPartnerGroupResponse = new BusinessPartnerGroupResponse();
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                businessPartnerGroupVM = new List<BusinessPartnerGroupVM>
                {
                    await _BusinessPartnerServices.AddBusinessPartnerGroupDetails(businessPartnerGroupRequest.businessPartnerGroupVM)
                };
                businessPartnerGroupResponse.businessPartnerGroupVM = businessPartnerGroupVM;
                businessPartnerGroupResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerGroupResponse.IsSuccess = false;
                businessPartnerGroupResponse.Message = ex.Message;
            }

            return businessPartnerGroupResponse;
        }

        [HttpPut]
        public async Task<BusinessPartnerGroupResponse> UpdateBusinessPartnerGroupDetails([FromBody]BusinessPartnerGroupRequest businessPartnerGroupRequest)
        {
            BusinessPartnerGroupResponse businessPartnerGroupResponse = new BusinessPartnerGroupResponse();
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                businessPartnerGroupVM = new List<BusinessPartnerGroupVM>
                {
                    await _BusinessPartnerServices.UpdateBusinessPartnerGroupDetails(businessPartnerGroupRequest.businessPartnerGroupVM)
                };
                businessPartnerGroupResponse.businessPartnerGroupVM = businessPartnerGroupVM;
                businessPartnerGroupResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerGroupResponse.IsSuccess = false;
                businessPartnerGroupResponse.Message = ex.Message;
            }

            return businessPartnerGroupResponse;
        }

        [HttpGet]
        public async Task<BusinessPartnerGroupResponse> GetAllBusinessPartnerGroupDetails()
        {
            BusinessPartnerGroupResponse businessPartnerGroupResponse = new BusinessPartnerGroupResponse();
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                businessPartnerGroupVM = await _BusinessPartnerServices.GetAllBusinessPartnerGroupDetails();
                businessPartnerGroupResponse.businessPartnerGroupVM = businessPartnerGroupVM;
                businessPartnerGroupResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerGroupResponse.IsSuccess = false;
                businessPartnerGroupResponse.Message = ex.Message;
            }

            return businessPartnerGroupResponse;
        }

        [HttpGet("{groupCode}")]
        public async Task<BusinessPartnerGroupResponse> GetBusinessPartnerGroupDetailsByGroupId(int groupCode)
        {
            BusinessPartnerGroupResponse businessPartnerGroupResponse = new BusinessPartnerGroupResponse();
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                businessPartnerGroupVM = await _BusinessPartnerServices.GetBusinessPartnerGroupDetailsByGroupId(groupCode);
                businessPartnerGroupResponse.businessPartnerGroupVM = businessPartnerGroupVM;
                businessPartnerGroupResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerGroupResponse.IsSuccess = false;
                businessPartnerGroupResponse.Message = ex.Message;
            }

            return businessPartnerGroupResponse;
        }

        [HttpGet("{bspTypeId}")]
        public async Task<BusinessPartnerGroupResponse> GetBusinessPartnerGroupDetailsByBSPTypeId(int bspTypeId)
        {
            BusinessPartnerGroupResponse businessPartnerGroupResponse = new BusinessPartnerGroupResponse();
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                businessPartnerGroupVM = await _BusinessPartnerServices.GetBusinessPartnerGroupDetailsByBspTypeId(bspTypeId);
                businessPartnerGroupResponse.businessPartnerGroupVM = businessPartnerGroupVM;
                businessPartnerGroupResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerGroupResponse.IsSuccess = false;
                businessPartnerGroupResponse.Message = ex.Message;
            }

            return businessPartnerGroupResponse;
        }

        [HttpPut]
        public async Task<BusinessPartnerResponse> UpdateBusinessPartnerCustomerStatus(int isActive,int businessPartnerId)
        {
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            IEnumerable<BusinessPartnerVM> businessPartnerVM;

            try
            {
                businessPartnerVM = new List<BusinessPartnerVM>
                {
                    await _BusinessPartnerServices.UpdateBusinessPartnerCustomerStatus(isActive,businessPartnerId)
                };
                businessPartnerResponse.businessPartnerVM = businessPartnerVM;
                businessPartnerResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = ex.Message;
            }

            return businessPartnerResponse;
        }

        [HttpGet("{mobileNo},{businessPartnerTypeId}")]
        public async Task<BusinessPartnerResponse> GetBusinessPartnerDetailsByMobileNumber(int mobileNo, int businessPartnerTypeId)
        {
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            IEnumerable<BusinessPartnerVM> businessPartnerVM;

            try
            {
                businessPartnerVM = new List<BusinessPartnerVM>
                {
                    await _BusinessPartnerServices.GetBusinessPartnerDetailsByMobileNumber(mobileNo,businessPartnerTypeId)
                };
                businessPartnerResponse.businessPartnerVM = businessPartnerVM;
                businessPartnerResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = ex.Message;
            }
            return businessPartnerResponse;
        }

        [HttpDelete("{groupCode}")]
        public async Task<BusinessPartnerGroupResponse> DeleteBusinessPartnerGroupDetails(string groupCode)
        {
            BusinessPartnerGroupResponse businessPartnerGroupResponse = new BusinessPartnerGroupResponse();
            IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM;

            try
            {
                businessPartnerGroupVM = new List<BusinessPartnerGroupVM>
                {
                    await _BusinessPartnerServices.DeleteBusinessPartnerGroupDetails(groupCode)
                };
                businessPartnerGroupResponse.businessPartnerGroupVM = businessPartnerGroupVM;
                businessPartnerGroupResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerGroupResponse.IsSuccess = false;
                businessPartnerGroupResponse.Message = ex.Message;
            }

            return businessPartnerGroupResponse;
        }
    }
}