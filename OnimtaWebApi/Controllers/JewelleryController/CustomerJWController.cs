using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.DTO.Jewellery.JewelleryProduct;
using OnimtaWebInventory.Models.Jewellery;

namespace OnimtaWebApi.Controllers.JewelleryController
{
    [Route("api/[controller]/[action]")]
    public class CustomerJWController : Controller
    {
        private ICustomerJWServices _customerJWServices;
        private ILogger<CustomerJWController> _logger;

        public CustomerJWController(ICustomerJWServices CustomerJWServices,ILogger<CustomerJWController> logger)
        {
            _logger = logger;
            _customerJWServices = CustomerJWServices;
        }

        [HttpPost]
        public async Task<JewelleryProductResponse> AddJewelleryCustomerDetails([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<CustomerJw> customerJw;

            try
            {
                customerJw = new List<CustomerJw>
                {
                    await _customerJWServices.AddJewelleryCustomerDetails(jewelleryProductRequest.customer)
                };
                jewelleryProductResponse.customer = customerJw.ElementAt(0);
                jewelleryProductResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpPut]
        public async Task<JewelleryProductResponse> UpdateJewelleryCustomerDetails([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<CustomerJw> CustomerJw;

            try
            {
                CustomerJw = new List<CustomerJw>
                {
                    await _customerJWServices.UpdateJewelleryCustomerDetails(jewelleryProductRequest.customer)
                };
                jewelleryProductResponse.customer = CustomerJw.ElementAt(0);
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpDelete("{id}")]
        public async Task<JewelleryProductResponse> DeleteJewelleryCustomerDetails(int id)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<CustomerJw> CustomerJw;

            try
            {
                CustomerJw = new List<CustomerJw>
                {
                    await _customerJWServices.DeleteJewelleryCustomerDetails(id)
                };
                jewelleryProductResponse.customer = CustomerJw.ElementAt(0);
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }


        [HttpPost]
        public async Task<JewelleryProductResponse> GetJewelleryCustomerDetails([FromBody]FilterVM filter)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<CustomerJw> CustomerJw;

            try
            {
                CustomerJw = await _customerJWServices.GetJewelleryCustomerDetails(filter);
                jewelleryProductResponse.customers = CustomerJw;
                jewelleryProductResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }


        [HttpPost]
        public async Task<JewelleryProductResponse> AddSalesManDetails([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            try
            {
                   
                jewelleryProductResponse.customer = await _customerJWServices.AddSalesManDetails(jewelleryProductRequest.customer);
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpPut]
        public async Task<JewelleryProductResponse> UpdateSalesManDetails([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<CustomerJw> CustomerJw;

            try
            {
                CustomerJw = new List<CustomerJw>
                {
                    await _customerJWServices.UpdateSalesManDetails(jewelleryProductRequest.customer)
                };
                jewelleryProductResponse.customer = CustomerJw.ElementAt(0);
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpDelete("{id}")]
        public async Task<JewelleryProductResponse> DeleteSalesManDetails(int id)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<CustomerJw> CustomerJw;

            try
            {
                CustomerJw = new List<CustomerJw>
                {
                    await _customerJWServices.DeleteSalesManDetails(id)
                };
                jewelleryProductResponse.customer = CustomerJw.ElementAt(0);
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }


        [HttpPost]
        public async Task<JewelleryProductResponse> GetSalesManDetails([FromBody]FilterVM filter)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<CustomerJw> CustomerJw;

            try
            {
                CustomerJw = await _customerJWServices.GetSalesManDetails(filter);
                jewelleryProductResponse.customers = CustomerJw;
                jewelleryProductResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

    }
}