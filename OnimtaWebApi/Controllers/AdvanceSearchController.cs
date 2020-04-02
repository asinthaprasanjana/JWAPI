using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.AdavanceSearch;
using OnimtaWebInventory.DTO.BusinessPartner;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.Services;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AdvanceSearchController : Controller
    {
        private IAdvanceSearchServices _advanceSearchServices;
        private ILogger<AdvanceSearchController> _logger;

        public AdvanceSearchController(IAdvanceSearchServices AdvanceSearchServices , ILogger<AdvanceSearchController> logger)
        {
            _advanceSearchServices = AdvanceSearchServices;
            _logger = logger;
        }

        [HttpPut]
        public async Task<BusinessPartnerResponse> GetBusinessPartnerDetails([FromBody]BusinessPartnerRequest businessPartnerRequest)
        {
            BusinessPartnerResponse businessPartnerResponse = new BusinessPartnerResponse();
            IEnumerable<BusinessPartnerVM> businessPartnerVm;

            try
            {
                businessPartnerVm = await _advanceSearchServices.GetBusinessPartnerDetails(businessPartnerRequest.businessPartnerVM);
                businessPartnerResponse.businessPartnerVM = businessPartnerVm;
                businessPartnerResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                businessPartnerResponse.IsSuccess = false;
                businessPartnerResponse.Message = ex.Message;
            }
            return businessPartnerResponse;
        }

        [HttpGet]
        public async Task<AdvanceSearchResponse> GetAdvanceSearchDetails(int advanceSearchType)
        {
            AdvanceSearchResponse advanceSearchResponse = new AdvanceSearchResponse();
            IEnumerable<AdvanceSearchVM> advanceSearchVM;

            try
            {
                advanceSearchVM = await _advanceSearchServices.GetAdvanceSearchDetails(advanceSearchType);
                advanceSearchResponse.advanceSearchVM = advanceSearchVM;
                advanceSearchResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                advanceSearchResponse.IsSuccess = false;
                advanceSearchResponse.Message = ex.Message;
            }

            return advanceSearchResponse;
        }
    }
}