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
using System.Linq;
using OnimtaWebInventory.DTO.StockPurchaseOrderItem;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class QuotationController : Controller
    {
        private IQuotationServices _quotationServices;
        private ILogger<QuotationController> _logger;

        public QuotationController(IQuotationServices QuotationServices, ILogger<QuotationController> logger)
        {
            _quotationServices = QuotationServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<StockPurchaseOrderMasterResponse> AddNewQuotationDetails([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _quotationServices.AddNewQuotationDetails(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
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

        [HttpPut]
        public async Task<StockPurchaseOrderMasterResponse> UpdateQuotationDetails([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _quotationServices.UpdateQuotationDetails(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
                };
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = true;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }

            return stockPurchaseOrderMasterResponse;
        }

        [HttpGet("{id}")]
        public async Task<StockPurchaseOrderMasterResponse> GetQuotationDetailsById(int id)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                 {
                      await _quotationServices.GetQuotationDetailsById(id)
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

        [HttpGet("{branchId}")]
        public async Task<StockPurchaseOrderMasterResponse> GetAllQuotationDetails(int branchId)
        {

            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = await _quotationServices.GetAllQuotationDetails(branchId);
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }
            return stockPurchaseOrderMasterResponse;
        }

        [HttpGet("{branchId}")]
        public async Task<StockPurchaseOrderMasterResponse> GetAllQuotationSummeryByBranchId(int branchId)
        {

            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = await _quotationServices.GetAllQuotationSummeryByBranchId(branchId);
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


        [HttpGet("{quotationId}")]
        public async Task<StockPurchaseOrderItemResponse> GetAllSalesQuotaionProductByQuotationId(int quotationId)
        {

            StockPurchaseOrderItemResponse stockPurchaseOrderItemResponse  = new StockPurchaseOrderItemResponse();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
          // PurchaseOrderMasterVM purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>();
            List<PurchaseOrderMasterVM> purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>();
            

            try
            {
                purchaseOrderItemVM = await _quotationServices.GetAllSalesQuotaionProductByQuotationId(quotationId);
               
                stockPurchaseOrderItemResponse.purchaseOrderItem = purchaseOrderItemVM;
                stockPurchaseOrderItemResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderItemResponse.IsSuccess = false;
                stockPurchaseOrderItemResponse.Message = ex.Message;
            }
            return stockPurchaseOrderItemResponse;
        }
    }
}