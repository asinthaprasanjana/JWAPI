using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.SalesInvoiceSummary;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
   
    [Route("api/[controller]/[action]")]
    public class SalesInvoiceController : Controller
    {
        private ISalesInvoiceServices _salesInvoiceServices;
        private ILogger<SalesInvoiceController> _logger;

        public SalesInvoiceController(ISalesInvoiceServices salesInvoiceServices,ILogger<SalesInvoiceController> logger)
        {
            _salesInvoiceServices = salesInvoiceServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<SalesInvoiceMasterResponse>AddNewSalesInvoiceDetails([FromBody] SalesInvoiceMasterRequest salesInvoiceMasterRequest)
        {
            SalesInvoiceMasterResponse salesInvoiceMasterResponse = new SalesInvoiceMasterResponse();
            SalesInvoiceMasterVM salesInvoiceMasterVM = new SalesInvoiceMasterVM();

            try
            {
                salesInvoiceMasterVM = await _salesInvoiceServices.AddNewSalesInvoiceDetails(salesInvoiceMasterRequest.salesInvoiceMasterVm);
                salesInvoiceMasterResponse.salesInvoiceMasterVM = salesInvoiceMasterVM;
                salesInvoiceMasterResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                salesInvoiceMasterResponse.IsSuccess = false;
                salesInvoiceMasterResponse.Message = ex.Message;
            }
            return salesInvoiceMasterResponse;
        }

        [HttpGet("{CompanyId}")]
        public async Task<SalesInvoiceSummaryResponse> GetAllInvoiceDetailsByCompanyId(int CompanyId)
        {
            IEnumerable<SalesInvoiceSummaryVM> salesInvoiceSummaryVM;
            SalesInvoiceSummaryResponse salesInvoiceSummaryResponse = new SalesInvoiceSummaryResponse();


            try
            {
                salesInvoiceSummaryVM = await _salesInvoiceServices.GetAllInvoiceDetailsByCompanyId(CompanyId);
                salesInvoiceSummaryResponse.IsSuccess = true;
                salesInvoiceSummaryResponse.salesInvoiceSummaryVM = salesInvoiceSummaryVM;
            }
            catch(Exception ex)
            {
                salesInvoiceSummaryResponse.IsSuccess = false;
                salesInvoiceSummaryResponse.Message = ex.Message;
            }

            return salesInvoiceSummaryResponse;
        }

        [HttpGet("{InvoiceNo}")]
        public async Task<SalesInvoiceMasterResponse> GetAllInvoiceDetailsByInvoiceNo(int InvoiceNo)
        {
                  SalesInvoiceMasterVM salesInvoiceMasterVM = new SalesInvoiceMasterVM();
                  SalesInvoiceMasterResponse salesInvoiceMasterResponse = new SalesInvoiceMasterResponse();


            try
            {
                salesInvoiceMasterVM = await _salesInvoiceServices.GetAllInvoiceDetailsByInvoiceNo(InvoiceNo);
                salesInvoiceMasterResponse.IsSuccess = true;
                salesInvoiceMasterResponse.salesInvoiceMasterVM = salesInvoiceMasterVM;
            }
            catch (Exception ex)
            {
                salesInvoiceMasterResponse.IsSuccess = false;
                salesInvoiceMasterResponse.Message = ex.Message;
            }

            return salesInvoiceMasterResponse;
        }

}
}