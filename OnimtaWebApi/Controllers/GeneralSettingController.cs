using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.GeneralSetting;
using OnimtaWebInventory.DTO.PaymentMethod;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class GeneralSettingController : Controller
    {
        private IGeneralSettingServices _GeneralSettingServices;
        private ILogger<GeneralSettingController> _logger;

        public GeneralSettingController(IGeneralSettingServices GeneralSettingServices, ILogger<GeneralSettingController> logger)
        {
            _GeneralSettingServices = GeneralSettingServices;
            _logger = logger;

        }

        [HttpPost]
        public async Task<PaymentMethodResponse> AddNewPaymentDetails([FromBody]PaymentMethodRequest paymentMethodRequest)
        {
            PaymentMethodResponse paymentMethodResponse = new PaymentMethodResponse();
            IEnumerable<PaymentMethodVM> paymentMethodVM;
            try
            {
                paymentMethodVM = new List<PaymentMethodVM>
                {
                    await _GeneralSettingServices.AddNewPaymentDetails(paymentMethodRequest.paymentMethodVM)
                };
                paymentMethodResponse.paymentMethodVM = paymentMethodVM;
                paymentMethodResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentMethodResponse.IsSuccess = false;
                paymentMethodResponse.Message = ex.Message;
            }
            return paymentMethodResponse;
        }

        [HttpPut]
        public async Task<PaymentMethodResponse> UpdatePaymentDetails([FromBody]PaymentMethodRequest paymentMethodRequest)
        {
            PaymentMethodResponse paymentMethodResponse = new PaymentMethodResponse();
            IEnumerable<PaymentMethodVM> paymentMethodVM;
            try
            {
                paymentMethodVM = new List<PaymentMethodVM>
                {
                    await _GeneralSettingServices.UpdatePaymentDetails(paymentMethodRequest.paymentMethodVM)
                };
                paymentMethodResponse.paymentMethodVM = paymentMethodVM;
                paymentMethodResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentMethodResponse.IsSuccess = false;
                paymentMethodResponse.Message = ex.Message;
            }
            return paymentMethodResponse;
        }

        [HttpGet]
        public async Task<PaymentMethodResponse> GetAllPaymentDetails()
        {
            PaymentMethodResponse paymentMethodResponse = new PaymentMethodResponse();
            IEnumerable<PaymentMethodVM> paymentMethodVM;

            try
            {
                paymentMethodVM = await _GeneralSettingServices.GetAllPaymentDetails();
                paymentMethodResponse.paymentMethodVM = paymentMethodVM;
                paymentMethodResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentMethodResponse.IsSuccess = false;
                paymentMethodResponse.Message = ex.Message;
            }
            return paymentMethodResponse;
        }
    }
}