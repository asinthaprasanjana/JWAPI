using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Cancellation;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.DTO.StockPurchaseOrderMaster;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CancellationController : Controller
    {
        private ICancellationServices _cancellationServices;
        private ILogger<CancellationController> _logger;

        public CancellationController(ICancellationServices CancellationServices,ILogger<CancellationController>logger)
        {
            _cancellationServices = CancellationServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<CancellationResponse> AddNewCancellationDetails([FromBody]CancellationRequest cancellationRequest)
        {
            CancellationResponse cancellationResponse = new CancellationResponse();
            IEnumerable<CancellationVM> cancellationVM;

            try
            {
                cancellationVM = new List<CancellationVM>
                {
                    await _cancellationServices.AddNewCancellationDetails(cancellationRequest.cancellationVM)
                };
                cancellationResponse.cancellationVM = cancellationVM;
                cancellationResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                cancellationResponse.IsSuccess = false;
                cancellationResponse.Message = ex.Message;
            }
            return cancellationResponse;
        }

        [HttpGet("{cancellationTypeId}")]
        public async Task<StockPurchaseOrderMasterResponse> GetCancellationData(int cancellationTypeId)
        {
            StockPurchaseOrderMasterResponse purchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {


                purchaseOrderMasterVM = await _cancellationServices.GetCancellationData(cancellationTypeId);
                purchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                purchaseOrderMasterResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderMasterResponse.IsSuccess = false;
                purchaseOrderMasterResponse.Message = ex.Message;
            }
            return purchaseOrderMasterResponse;
        }


        [HttpGet("{cancellationTypeId},{id}")]
        public async Task<StockPurchaseOrderMasterResponse> GetCancellationSummaryData(int cancellationTypeId, string id)
        {
            StockPurchaseOrderMasterResponse purchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            //PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;


            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _cancellationServices.GetCancellationSummaryData(cancellationTypeId,id)
                };
                //purchaseOrderMasterVM = await _cancellationServices.GetCancellationSummaryData(typeId,id);
                purchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                purchaseOrderMasterResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderMasterResponse.IsSuccess = false;
                purchaseOrderMasterResponse.Message = ex.Message;
            }
            return purchaseOrderMasterResponse;
        }

        [HttpPut("{cancellationTypeId},{referenceNo},{notificationTypeId},{reason},{userId}")]
        public async Task<StockPurchaseOrderMasterResponse> updateCancellationData(int cancellationTypeId, string referenceNo,int notificationTypeId,string reason, int userId)
        {
            StockPurchaseOrderMasterResponse purchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            int isCancelled = 1;
            
            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _cancellationServices.updateCancellationData(cancellationTypeId,referenceNo,notificationTypeId,reason,isCancelled,userId)
                };
                purchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                purchaseOrderMasterResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderMasterResponse.IsSuccess = false;
                purchaseOrderMasterResponse.Message = ex.Message;
            }
            return purchaseOrderMasterResponse;
        }
    }
}