using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.PurchaseOrderBill;
using OnimtaWebInventory.DTO.StockPurchaseOrderItem;
using OnimtaWebInventory.DTO.PurchaseOrderSummery;
using OnimtaWebInventory.DTO.StockPurchaseOrderMaster;
using OnimtaWebInventory.Models;
using Microsoft.AspNetCore.Authorization;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PurchaseOrderRecieveController : Controller
    {
        private ILogger<PurchaseOrderRecieveController> _logger;
        private IPurchaseOrderRecieveServices _purchaseOrderRecieveServices;

        public PurchaseOrderRecieveController(IPurchaseOrderRecieveServices purchaseOrderRecieveServices, ILogger<PurchaseOrderRecieveController> logger)
        {
            _purchaseOrderRecieveServices = purchaseOrderRecieveServices;
            _logger = logger;
        }


        [HttpGet("{purchaseNo},{recieveTypeId},{isHistory}")]
        public async Task<StockPurchaseOrderItemResponse> GetPurchaseOrderRecievedDetails(string purchaseNo, int recieveTypeId, int isHistory)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            StockPurchaseOrderItemResponse stockPurchaseOrderItemResponse = new StockPurchaseOrderItemResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderRecieveServices.GetPurchaseOrderRecievedDetailsByPurchaseNo(purchaseNo,  recieveTypeId , isHistory)
                };
                stockPurchaseOrderItemResponse.purchaseOrderItem = purchaseOrderMasterVM.ElementAt(0).purchaseOrderItemVM;
                stockPurchaseOrderItemResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }
            return stockPurchaseOrderItemResponse;
        }

        [HttpPut("{purchaseNo},{recieveTypeId},{isBilled},{isRecieved},{userId}")]
        public async Task<StockPurchaseOrderMasterResponse> UpdateAllPurchaseOrderRecieveAndBill(string purchaseNo, int recieveTypeId, int isBilled, int isRecieved, int userId)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderRecieveServices.UpdateAllPurchaseOrderRecieve(purchaseNo,recieveTypeId, userId,isBilled,isRecieved)
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
        public async Task<PurchaseOrderMasterResponse> UpdatePartiallyPurchaseOrderRecieve([FromBody]PurchaseOrderMasterRequest purchaseOrderMasterRequest)
        {
            PurchaseOrderMasterResponse purchaseOrderMasterResponse = new PurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            int isBilling = 0;// purchaseOrderMasterRequest.purchaseOrderMasterVM.IsBilling;
            purchaseOrderMasterRequest.purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(0).RecieveTypeId = purchaseOrderMasterRequest.purchaseOrderMasterVM.RecieveTypeId;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderRecieveServices.UpdatePartiallyPurchaseOrderRecieve(purchaseOrderMasterRequest.purchaseOrderMasterVM,isBilling)
                };
                purchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                purchaseOrderMasterResponse.IsSuccess = true;
                _logger.LogInformation(purchaseOrderMasterRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderMasterResponse.IsSuccess = false;
                purchaseOrderMasterResponse.Message = ex.Message;
            }
            return purchaseOrderMasterResponse;
        }

        [HttpGet("{companyId},{isPendingBill},{pageId}")]
        public async Task<PurchaseOrderSummeryResponse> GetPurchaseOrderRecievedDetailsByCompanyId(int companyId, int isPendingBill, int pageId)
        {
            PurchaseOrderSummeryResponse purchaseOrderSummeryResponse = new PurchaseOrderSummeryResponse();
            IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM;

            try
            {
                purchaseOrderSummeryVM = await _purchaseOrderRecieveServices.GetPurchaseOrderRecievedDetailsByCompanyId(companyId, isPendingBill, pageId);

                purchaseOrderSummeryResponse.purchaseOrderSummeryVM = purchaseOrderSummeryVM;
                purchaseOrderSummeryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderSummeryResponse.IsSuccess = false;
                purchaseOrderSummeryResponse.Message = ex.Message;
            }
            return purchaseOrderSummeryResponse;
        }

        [HttpGet("{recievedId}")]
        public async Task<StockPurchaseOrderItemResponse> GetPurchaseOrderRecieveDetailsByDocumentNo(string recievedId)
        {
            StockPurchaseOrderItemResponse stockPurchaseOrderItemResponse = new StockPurchaseOrderItemResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderRecieveServices.GetPurchaseOrderRecieveDetailsByDocumentNo(recievedId)
                };
                stockPurchaseOrderItemResponse.purchaseOrderItem = purchaseOrderMasterVM.ElementAt(0).purchaseOrderItemVM;
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

        //[HttpGet("{companyId}")]
        //public async Task<PurchaseOrderMasterResponse> GetAllPurchaseOrderRecievedEventDetailsByCompanyId(int companyId)
        //{
        //    PurchaseOrderMasterResponse purchaseOrderMasterResponse = new PurchaseOrderMasterResponse();
        //    IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
        //    try
        //    {
        //        purchaseOrderMasterVM = await _purchaseOrderRecieveServices.GetAllPurchaseOrderRecievedEventDetailsByCompanyId(companyId);
        //        purchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
        //        purchaseOrderMasterResponse.IsSuccess = true;

        //    } catch(Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        purchaseOrderMasterResponse.IsSuccess = false;
        //        purchaseOrderMasterResponse.Message = ex.Message;
        //    }
        //    return purchaseOrderMasterResponse;
        //}
    }
}