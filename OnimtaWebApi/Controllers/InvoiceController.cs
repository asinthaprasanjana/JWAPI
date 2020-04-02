using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.StockPurchaseOrderMaster;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class InvoiceController : Controller
    {
        private IInvoiceServices _invoiceServices;
        private ILogger<InvoiceController> _logger;

        public InvoiceController(IInvoiceServices InvoiceServices, ILogger<InvoiceController> logger)
        {
            _invoiceServices = InvoiceServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<StockPurchaseOrderMasterResponse>AddNewInvoiceDetails([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _invoiceServices.AddNewInvoiceDetails(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
                };
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }
            return stockPurchaseOrderMasterResponse;
        }

        [HttpPut]
        public async Task<StockPurchaseOrderMasterResponse> UpdateInvoiceDetails([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _invoiceServices.UpdateInvoiceDetails(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
                };
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }
            return stockPurchaseOrderMasterResponse;
        }

        [HttpGet]
        public async Task<StockPurchaseOrderMasterResponse> GetInvoiceDetailsById(int id)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>{
                    await _invoiceServices.GetInvoiceDetailsById(id)
                };
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }
            return stockPurchaseOrderMasterResponse;
        }

        [HttpGet]
        public async Task<StockPurchaseOrderMasterResponse> GetAllInvoiceDetails(int branchId)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = await _invoiceServices.GetAllInvoiceDetails(branchId);
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }
            return stockPurchaseOrderMasterResponse;
        }
    }
}