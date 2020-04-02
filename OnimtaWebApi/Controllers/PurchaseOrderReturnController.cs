using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.PurchaseOrderBill;
using OnimtaWebInventory.DTO.PurchaseOrderReturn;
using OnimtaWebInventory.DTO.StockPurchaseOrderItem;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
   // [Authorize]
    public class PurchaseOrderReturnController : Controller
    {
        private ILogger<PurchaseOrderReturnController> _logger;
        private IPurchaseOrderReturnServices _purchaseOrderReturnServices;

        public PurchaseOrderReturnController(IPurchaseOrderReturnServices PurchaseOrderReturnServices, ILogger<PurchaseOrderReturnController> logger)
        {
            _purchaseOrderReturnServices = PurchaseOrderReturnServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<PurchaseOrderMasterResponse> AddPurchaseOrderReturnDetails([FromBody]PurchaseOrderMasterRequest purchaseOrderMasterRequest)
        {
            PurchaseOrderMasterResponse purchaseOrderMasterResponse  = new PurchaseOrderMasterResponse();
            try
            {

                    await _purchaseOrderReturnServices.AddPurchaseOrderReturnDetails(purchaseOrderMasterRequest.purchaseOrderMasterVM);

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

        [HttpGet("{companyId}")]
        public async Task<PurchaseOrderMasterResponse> GetAllPurchaseOrderReturnDetails(int companyId)
        {
            PurchaseOrderMasterResponse purchaseOrderMasterResponse = new PurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVm;
            try
            {
                purchaseOrderMasterVm = await _purchaseOrderReturnServices.GetAllPurchaseOrderReturnDetails(companyId);
                purchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVm;
                purchaseOrderMasterResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderMasterResponse.IsSuccess = false;
                purchaseOrderMasterResponse.Message = ex.Message;
            }
            return purchaseOrderMasterResponse;
        }

        [HttpGet("{purchaseOrderReturnId}")]
        public async Task<StockPurchaseOrderItemResponse> GetPurchaseOrderReturnDetailsById(int purchaseOrderReturnId)
        {
            StockPurchaseOrderItemResponse stockPurchaseOrderItemResponse = new StockPurchaseOrderItemResponse();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;

            try
            {

                purchaseOrderItemVM = await _purchaseOrderReturnServices.GetPurchaseOrderReturnItemDetailsById(purchaseOrderReturnId);

                stockPurchaseOrderItemResponse.purchaseOrderItem = purchaseOrderItemVM;
                stockPurchaseOrderItemResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderItemResponse.IsSuccess = false;
                stockPurchaseOrderItemResponse.Message = ex.Message;
            }
            return stockPurchaseOrderItemResponse;
        }

    }
}