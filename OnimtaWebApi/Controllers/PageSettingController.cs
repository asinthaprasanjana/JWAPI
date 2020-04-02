using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.ApplicationPage;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PageSettingController : Controller
    {
        private IPageSettingServices _pageSettingServices;
        private ILogger<PageSettingController> _logger;

        public PageSettingController(IPageSettingServices PageSettingServices ,ILogger<PageSettingController>logger)
        {
            _pageSettingServices = PageSettingServices;
            _logger = logger;

        }
        [HttpPost]
        public async Task<ApplicationPageResponse> AddNewApplicationPagesAsync([FromBody]ApplicationPageRequest applicationPageRequest)
        {
            ApplicationPageResponse applicationPageResponse = new ApplicationPageResponse();
            IEnumerable<ApplicationPageVM> applicationPagevm;
            try
            {
                applicationPagevm = new List<ApplicationPageVM>{
                          await _pageSettingServices.AddNewApplicationPagesAsync(applicationPageRequest.applicationPageVM)
                    };
                applicationPageResponse.applicationPageVM = applicationPagevm;
                applicationPageResponse.IsSuccess = true;

                _logger.LogInformation(applicationPageRequest.ToString());
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                applicationPageResponse.IsSuccess = false;
                applicationPageResponse.Message = exc.Message;
            }
            return applicationPageResponse;
        }

        [HttpPut]
        public async Task<ApplicationPageResponse> UpdateSelectedPage([FromBody]ApplicationPageRequest applicationPageRequest)
        {
            ApplicationPageResponse applicationPageResponse = new ApplicationPageResponse();
            IEnumerable<ApplicationPageVM> applicationPagevm;
            try
            {
                applicationPagevm = new List<ApplicationPageVM>{
                          await _pageSettingServices.UpdateSelectedPage(applicationPageRequest.applicationPageVM)
                    };
                applicationPageResponse.applicationPageVM = applicationPagevm;
                applicationPageResponse.IsSuccess = true;

                _logger.LogInformation(applicationPageRequest.ToString());
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                applicationPageResponse.IsSuccess = false;
                applicationPageResponse.Message = exc.Message;
            }
            return applicationPageResponse;
        }
    }
}