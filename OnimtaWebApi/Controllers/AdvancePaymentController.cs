using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.AdvancePayment;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    public class AdvancePaymentController : Controller
    {
        private IAdvancePaymentServices _advancePaymentServices;
        private ILogger<AdvancePaymentController> _logger;

        public AdvancePaymentController(IAdvancePaymentServices AdvancePaymentServices,ILogger<AdvancePaymentController> logger)
        {
            _advancePaymentServices = AdvancePaymentServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<AdvancePaymentResponse> Test( IFormFile formFile)
        {
            AdvancePaymentResponse advancePaymentResponse = new AdvancePaymentResponse();
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
            try
            {
                var a = formFile;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                advancePaymentResponse.IsSuccess = false;
                advancePaymentResponse.Message = ex.Message;
            }
            return advancePaymentResponse;
        }

        [HttpPost]
        public async Task<AdvancePaymentResponse> AddNewAdvancePayment([FromBody]AdvancePaymentRequest advancePaymentRequest)
        {
            AdvancePaymentResponse advancePaymentResponse = new AdvancePaymentResponse();
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
            try
            {
                advancePaymentVM = new List<AdvancePaymentVM>
                {
                    await _advancePaymentServices.AddNewAdvancePayment(advancePaymentRequest.advancePaymentVM)
                };
                advancePaymentResponse.advancePaymentVM = advancePaymentVM;
                advancePaymentResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                advancePaymentResponse.IsSuccess = false;
                advancePaymentResponse.Message = ex.Message;
            }
            return advancePaymentResponse;
        }

        [HttpGet("{AdvancePaymentId}")]
        public async Task<AdvancePaymentResponse> GetAdvancePaymentDetailsById(string AdvancePaymentId)
        {
            AdvancePaymentResponse advancePaymentResponse = new AdvancePaymentResponse();
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
            try
            {
                advancePaymentVM = new List<AdvancePaymentVM>
                {
                    await _advancePaymentServices.GetAdvancePaymentDetailsById(AdvancePaymentId)
                };
                advancePaymentResponse.advancePaymentVM = advancePaymentVM;
                advancePaymentResponse.IsSuccess = true;
                    
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                advancePaymentResponse.IsSuccess = false;
                advancePaymentResponse.Message = ex.Message;
            }
            return advancePaymentResponse;
        }

        [HttpGet("{BusinessPartnerId}")]
        public async Task<AdvancePaymentResponse> GetAdvancePaymentDetailsByBspId(string BusinessPartnerId)
        {
            AdvancePaymentResponse advancePaymentResponse = new AdvancePaymentResponse();
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
            try
            {
                advancePaymentVM = new List<AdvancePaymentVM>
                {
                    await _advancePaymentServices.GetAdvancePaymentDetailsByBspId(BusinessPartnerId)
                };
                advancePaymentResponse.advancePaymentVM = advancePaymentVM;
                advancePaymentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                advancePaymentResponse.IsSuccess = false;
                advancePaymentResponse.Message = ex.Message;
            }
            return advancePaymentResponse;
        }

        [HttpGet("{BusinessPartnerId}")]
        public async Task<AdvancePaymentResponse> GetAllAdvancePaymentDetailsByBspId(string BusinessPartnerId)
        {
            AdvancePaymentResponse advancePaymentResponse = new AdvancePaymentResponse();
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
            try
            {
                advancePaymentVM =
                    await _advancePaymentServices.GetAllAdvancePaymentDetailsByBspId(BusinessPartnerId);
                advancePaymentResponse.advancePaymentVM = advancePaymentVM;
                advancePaymentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                advancePaymentResponse.IsSuccess = false;
                advancePaymentResponse.Message = ex.Message;

            }
            return advancePaymentResponse;
        }

        [HttpGet]
        public async Task<AdvancePaymentResponse>GetAllAdvancePaymentDetails()
        {
            AdvancePaymentResponse advancePaymentResponse = new AdvancePaymentResponse();
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
            try
            {
                advancePaymentVM = await _advancePaymentServices.GetAllAdvancePaymentDetails();
                advancePaymentResponse.advancePaymentVM = advancePaymentVM;
                advancePaymentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                advancePaymentResponse.IsSuccess = false;
                advancePaymentResponse.Message = ex.Message;
            }
            return advancePaymentResponse;
        }
    }
}