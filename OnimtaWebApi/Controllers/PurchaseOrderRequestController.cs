using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.PurchaseOrderRequest;
using OnimtaWebInventory.DTO.StockPurchaseOrderMaster;
using OnimtaWebInventory.Models;
using static OnimtaWebInventory.DTO.PurchaseOrderRequest.PurchaseOrderRequestRequest;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PurchaseOrderRequestController : Controller
    {
        private IPurchaseOrderRequestServices _purchaseOrderRequestServices;
        private ILogger<PurchaseOrderRequestController> _logger;

        public PurchaseOrderRequestController(IPurchaseOrderRequestServices PurchaseOrderRequestServices, ILogger<PurchaseOrderRequestController> logger)
        {
            _purchaseOrderRequestServices = PurchaseOrderRequestServices;
            _logger = logger;
        }
        [HttpPost]
        public async Task<StockPurchaseOrderMasterResponse> AddPurchaseOrderRequest([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderRequestServices.AddPurchaseOrderRequest(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
                };
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;
                _logger.LogInformation(stockPurchaseOrderMasterRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }
            return stockPurchaseOrderMasterResponse;
        }
        [HttpGet("{pageId}")]
        public async Task<PurchaseOrderRequestResponse> GetAllPurchaseOrderRequestDetails( int pageId)
        {
            PurchaseOrderRequestResponse purchaseOrderRequestResponse = new PurchaseOrderRequestResponse();
            IEnumerable<PurchaseOrderRequestVM> purchaseOrderRequestVM;

            try
            {
                purchaseOrderRequestVM = await _purchaseOrderRequestServices.GetAllPurchaseOrderRequestDetails(pageId);
                purchaseOrderRequestResponse.purchaseOrderRequestVM = purchaseOrderRequestVM;
                purchaseOrderRequestResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderRequestResponse.IsSuccess = false;
                purchaseOrderRequestResponse.Message = ex.Message;
            }
            return purchaseOrderRequestResponse;
        }

        [HttpGet("{purchaseNo}")]
        public async Task<PurchaseOrderRequestResponse> GetPurchaseOrderRequestDetails(int purchaseNo)
        {
            PurchaseOrderRequestResponse purchaseOrderRequestResponse = new PurchaseOrderRequestResponse();
            IEnumerable<PurchaseOrderRequestVM> purchaseOrderRequestVM;
            try
            {
                purchaseOrderRequestVM = new List<PurchaseOrderRequestVM>
                {
                    await _purchaseOrderRequestServices.GetPurchaseOrderRequestDetails(purchaseNo)
                };
                purchaseOrderRequestResponse.purchaseOrderRequestVM = purchaseOrderRequestVM;
                purchaseOrderRequestResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderRequestResponse.IsSuccess = false;
                purchaseOrderRequestResponse.Message = ex.Message;
            }
            return purchaseOrderRequestResponse;
        }

        //[HttpPost]
        //public async Task<PurchaseOrderRequestResponse> AddPurchaseOrderRequestItems([FromBody]PurchaseOrderRequestItemsRequest purchaseOrderRequestItemsRequest)
        //{
        //    PurchaseOrderRequestResponse purchaseOrderRequestResponse = new PurchaseOrderRequestResponse();
        //    IEnumerable<PurchaseOrderRequestItemsVM> purchaseOrderRequestItemsVm;

        //    try
        //    {
        //        purchaseOrderRequestItemsVm = new List<PurchaseOrderRequestItemsVM>
        //        {
        //            await _purchaseOrderRequestServices.AddPurchaseOrderRequestItems(purchaseOrderRequestItemsRequest.purchaseOrderRequestItemsVM)
        //        };
        //        purchaseOrderRequestResponse.purchaseOrderRequestItemsVM = purchaseOrderRequestItemsVm;
        //        purchaseOrderRequestResponse.IsSuccess = true;
        //        _logger.LogInformation(purchaseOrderRequestItemsRequest.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        purchaseOrderRequestResponse.IsSuccess = false;
        //        purchaseOrderRequestResponse.Message = ex.Message;
        //    }
        //    return purchaseOrderRequestResponse;
        //}
        [HttpGet]
        public async Task<PurchaseOrderRequestResponse> GetPurchaseOrderRequestItemsDetails()
        {
            PurchaseOrderRequestResponse purchaseOrderRequestResponse = new PurchaseOrderRequestResponse();
            IEnumerable<PurchaseOrderRequestSummaryVM> purchaseOrderRequestItemsVM;
            try
            {
                purchaseOrderRequestItemsVM = await _purchaseOrderRequestServices.GetPurchaseOrderRequestItemsDetails();
                purchaseOrderRequestResponse.purchaseOrderRequestSummaryVMs = purchaseOrderRequestItemsVM;
                purchaseOrderRequestResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderRequestResponse.IsSuccess = false;
                purchaseOrderRequestResponse.Message = ex.Message;
            }
            return purchaseOrderRequestResponse;
        }
    }
}