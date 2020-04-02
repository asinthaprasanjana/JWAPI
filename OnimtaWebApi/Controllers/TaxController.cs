using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Tax;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TaxController : Controller
    { 
        private ITaxServices _TaxServices;
        private ILogger<TaxController> _logger;
        public TaxController(ITaxServices TaxServices,   ILogger<TaxController> logger)
        {
            _TaxServices = TaxServices;
            _logger = logger;
            
        }
        [HttpGet("{taxNo},{companyId}")]
        public async Task<TaxResponse> GetTaxDetailsByTaxNumber(int taxNo, int companyId)
        {
            TaxResponse taxResponse  = new TaxResponse();
            IEnumerable<TaxVM> taxVM;

            try
            {
                taxVM = new List<TaxVM>{
                    await _TaxServices.GetTaxDetailsByTaxNumber(taxNo, companyId)
                };
                taxResponse.taxVM = taxVM;
                taxResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                taxResponse.IsSuccess = false;
                taxResponse.Message = exc.Message;
            }
            return taxResponse;
        }

        [HttpGet]
        public async Task<TaxResponse> GetTaxDetails()
        {
            TaxResponse taxResponse = new TaxResponse();
            IEnumerable<TaxVM> taxVm;

            try
            {
                taxVm = await _TaxServices.GetTaxDetails();
                
                taxResponse.taxVM = taxVm;
                taxResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                taxResponse.IsSuccess = false;
                taxResponse.Message = exc.Message;
            }
            return taxResponse;
        }

        [HttpPost]
        public async Task<TaxResponse> AddTaxDetails([FromBody]TaxRequest taxRequest)
        {
            TaxResponse taxResponse = new TaxResponse();
            IEnumerable<TaxVM> taxVm;

            try
            {
                taxVm = new List<TaxVM>{
                    await _TaxServices.AddTaxDetails(taxRequest.taxVM)
                };
                taxResponse.taxVM = taxVm;
                taxResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                taxResponse.IsSuccess = false;
                taxResponse.Message = exc.Message;
            }
            return taxResponse;
        }

        [HttpPut]
        public async Task<TaxResponse> UpdateTaxDetails([FromBody]TaxRequest taxRequest)
        {
            TaxResponse taxResponse = new TaxResponse();
            IEnumerable<TaxVM> taxVm;

            try
            {
                taxVm = new List<TaxVM>{
                    await _TaxServices.UpdateTaxDetails(taxRequest.taxVM)
                };
                taxResponse.taxVM = taxVm;
                taxResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                taxResponse.IsSuccess = false;
                taxResponse.Message = exc.Message;
            }
            return taxResponse;
        }

    }
}