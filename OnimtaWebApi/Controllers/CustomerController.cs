using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Customer;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.Services;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
   // [Authorize]
    public class CustomerController : Controller
    {
        private ICustomerServices _CustomerServices;
        private ILogger<CustomerController> _logger;

        public CustomerController(ICustomerServices CustomerServices, ILogger<CustomerController> logger)
        {
            _CustomerServices = CustomerServices;
            _logger = logger;
            //_mapper = mapper;
        }

        [HttpGet("{id},{companyId}")]
        public async Task<CustomerResponse> GetCustomerDetailsById(int id, int companyId)
        {
            CustomerResponse customerResponse = new CustomerResponse();
           IEnumerable< CustomerVM> customerVM;
            try
            {
                customerVM = new List<CustomerVM>() {
                  await _CustomerServices.GetCustomerDetailsById(id,companyId)
                };

                customerResponse.customerVm = customerVM;
                customerResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message );
                customerResponse.IsSuccess = false;
                customerResponse.Message = exc.Message;
            }
            return customerResponse;
        }

        //Add New Customer
        [HttpPost]
        public async Task<CustomerResponse> AddNewCustomerDetails([FromBody]CustomerRequest customerRequest)
        {
            CustomerResponse customerResponse = new CustomerResponse();
            IEnumerable<CustomerVM> customervM;
            try
            {
                customervM = new List<CustomerVM>{
                    await _CustomerServices.AddNewCustomerDetails(customerRequest.customerVm) }; 
                
                customerResponse.customerVm = customervM;
                customerResponse.IsSuccess = true;
                _logger.LogInformation(customerRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                customerResponse.IsSuccess = false;
                customerResponse.Message = exc.Message;
            }
            return customerResponse;
        }
        //Update  Customer NIC
        [HttpPut]
        public async Task<CustomerResponse> UpdateCustomerDetailsById([FromBody]CustomerRequest customerRequest)
        {
            CustomerResponse customerResponse = new CustomerResponse();
           IEnumerable< CustomerVM >customerVm;
            try
            {
                customerVm = new List<CustomerVM>{
                    await _CustomerServices.UpdateCustomerDetailsById(customerRequest.customerVm)
                };
                customerResponse.customerVm = customerVm;
                customerResponse.IsSuccess = true;
                _logger.LogInformation(customerRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                customerResponse.IsSuccess = false;
                customerResponse.Message = exc.Message;
            }
            return customerResponse;
        }

        //Delete Customer NIC
        [HttpDelete("{id}")]
        public async Task<CustomerResponse> DeleteCustomerDetailsByNic(int id)
        {
            CustomerResponse customerResponse = new CustomerResponse();
          IEnumerable<CustomerVM> customerVM ;
            try
            {
                customerVM = new List<CustomerVM>{
                    await _CustomerServices.DeleteCustomerDetailsById(id) };
                 customerResponse.customerVm = customerVM;
                customerResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                customerResponse.IsSuccess = false;
                customerResponse.Message = exc.Message;
            }
            return customerResponse;
        }

    }
}