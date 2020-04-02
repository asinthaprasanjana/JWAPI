using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.AdvanceSetting;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AdvanceSettingController : Controller
    {
        private ILogger<AdvanceSettingController> _logger;
        private IAdvanceSettingServices _advanceSettingServices;

        public AdvanceSettingController(IAdvanceSettingServices AdvanceSettingServices, ILogger<AdvanceSettingController> logger)
        {
            _advanceSettingServices = AdvanceSettingServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<AdvanceSettingResponse> AddAdvaneSettingDetails([FromBody]AdvanceSettingRequest advanceSettingRequest)
        {
            AdvanceSettingResponse advanceSettingResponse = new AdvanceSettingResponse();
            IEnumerable<AdvanceSettingVM> advanceSettingVM;

            try
            {
                advanceSettingVM = new List<AdvanceSettingVM>{
                    await _advanceSettingServices.AddAdvaneSettingDetails(advanceSettingRequest.advanceSettingVM)
                    };
                advanceSettingResponse.advanceSettingVM = advanceSettingVM;
                advanceSettingResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                advanceSettingResponse.IsSuccess = false;
                advanceSettingResponse.Message = ex.Message;
            }

            return advanceSettingResponse;
        }

        [HttpPut]
        public async Task<AdvanceSettingResponse> UpdateAdvaneSettingDetails([FromBody]AdvanceSettingRequest advanceSettingRequest)
        {
            AdvanceSettingResponse advanceSettingResponse = new AdvanceSettingResponse();
            IEnumerable<AdvanceSettingVM> advanceSettingVM;

            try
            {
                advanceSettingVM = new List<AdvanceSettingVM>{
                    await _advanceSettingServices.UpdateAdvaneSettingDetails(advanceSettingRequest.advanceSettingVM)
                    };
                advanceSettingResponse.advanceSettingVM = advanceSettingVM;
                advanceSettingResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                advanceSettingResponse.IsSuccess = false;
                advanceSettingResponse.Message = ex.Message;
            }

            return advanceSettingResponse;
        }

        [HttpGet]
        public async Task<AdvanceSettingResponse> GetAllAdvaneSettingDetails()
        {
            AdvanceSettingResponse advanceSettingResponse = new AdvanceSettingResponse();
            IEnumerable<AdvanceSettingVM> advanceSettingVM;

            try
            {
                advanceSettingVM = await _advanceSettingServices.GetAllAdvaneSettingDetails();
                advanceSettingResponse.advanceSettingVM = advanceSettingVM;
                advanceSettingResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                advanceSettingResponse.IsSuccess = false;
                advanceSettingResponse.Message = ex.Message;
            }

            return advanceSettingResponse;
        }
    }
}