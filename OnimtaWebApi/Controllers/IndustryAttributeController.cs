using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.IndustryAttribute;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class IndustryAttributeController : Controller
    {
        private IIndustryAttributeServices _industryAttributeServices;
        private ILogger<IndustryAttributeController> _logger;

        public IndustryAttributeController(IIndustryAttributeServices IndustryAttributeServices, ILogger<IndustryAttributeController> logger)
        {
            _industryAttributeServices = IndustryAttributeServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IndustryAttributeResponse> AddIndustryAttributeDetails([FromBody]IndustryAttributeRequest industryAttributeRequest)
        {
            IndustryAttributeResponse industryAttributeResponse = new IndustryAttributeResponse();
            IEnumerable<IndustryVM> industryVM;

            try
            {
                industryVM = new List<IndustryVM>{
                    await _industryAttributeServices.AddIndustryAttributeDetails(industryAttributeRequest.industryVM)
                };
                industryAttributeResponse.industryVM = industryVM;
                industryAttributeResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                industryAttributeResponse.IsSuccess = false;
                industryAttributeResponse.Message = ex.Message;
            }

            return industryAttributeResponse;
        }

        [HttpPut]
        public async Task<IndustryAttributeResponse> UpdateIndustryAttributeDetails([FromBody]IndustryAttributeRequest industryAttributeRequest)
        {
            IndustryAttributeResponse industryAttributeResponse = new IndustryAttributeResponse();
            IEnumerable<IndustryVM> industryVM;

            try
            {
                industryVM = new List<IndustryVM>{
                    await _industryAttributeServices.UpdateIndustryAttributeDetails(industryAttributeRequest.industryVM)
                };
                industryAttributeResponse.industryVM = industryVM;
                industryAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                industryAttributeResponse.IsSuccess = false;
                industryAttributeResponse.Message = ex.Message;
            }

            return industryAttributeResponse;
        }


        [HttpGet]
        public async Task<IndustryAttributeResponse> GetAllIndustryAttributeDetails()
        {
            IndustryAttributeResponse industryAttributeResponse = new IndustryAttributeResponse();
            IEnumerable<IndustryVM> industryVM;

            try
            {
                industryVM = await _industryAttributeServices.GetAllIndustryAttributeDetails();
                industryAttributeResponse.industryVM = industryVM;
                industryAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                industryAttributeResponse.IsSuccess = false;
                industryAttributeResponse.Message = ex.Message;
            }

            return industryAttributeResponse;
        }

        [HttpGet]
        public async Task<IndustryAttributeResponse> GetIndustryName()
        {
            IndustryAttributeResponse industryAttributeResponse = new IndustryAttributeResponse();
            IEnumerable<IndustryNameVM> industryNameVM;

            try
            {
                industryNameVM = await _industryAttributeServices.GetIndustryName();
                industryAttributeResponse.industryNameVM =industryNameVM ;
                industryAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                industryAttributeResponse.IsSuccess = false;
                industryAttributeResponse.Message = ex.Message;
            }

            return industryAttributeResponse;
        }
    }
}