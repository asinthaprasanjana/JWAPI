using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.NewFolder;
using OnimtaWebInventory.DTO.NewPurchaseOrder;
using OnimtaWebInventory.DTO.PurchaseOrderSummery;
using OnimtaWebInventory.DTO.PurchaseDraftSummery;
using OnimtaWebInventory.DTO.StockPurchaseOrder;
using OnimtaWebInventory.DTO.StockPurchaseOrderItem;
using OnimtaWebInventory.DTO.StockPurchaseOrderMaster;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.DTO.PurchaseOrderFinal;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace OnimtaWebApi.Controllers
{
   
    //[Authorize]
    [Route("api/[controller]/[action]")]
    public class StockPurchaseOrderController : Controller
    {
        private IPurchaseOrderServices _purchaseOrderServices;
        private ILogger<StockController> _logger;
        public StockPurchaseOrderController(IPurchaseOrderServices PurchaseOrderServices, ILogger<StockController> logger)
        {
            _purchaseOrderServices = PurchaseOrderServices;
            _logger = logger;
        }


        [HttpGet("{pageId},{searchTypeId}")]
        public async Task<StockPurchaseOrderResponse> GetPurchaseOrderSummeryDetails( int pageId,int searchTypeId)
        {
        //    int companyId = 0;
            StockPurchaseOrderResponse stockPurchaseOrderResponse = new StockPurchaseOrderResponse();
            IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM;
            try
            {
                purchaseOrderSummeryVM = await _purchaseOrderServices.GetPurchaseOrderSummeryDetails(searchTypeId, pageId);
                stockPurchaseOrderResponse.purchaseOrderSummeryVM = purchaseOrderSummeryVM;
                stockPurchaseOrderResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockPurchaseOrderResponse.IsSuccess = false;
                stockPurchaseOrderResponse.Message = exc.Message;
             
            }
            return stockPurchaseOrderResponse;
        }


        [HttpGet("{companyId}")]
        public async Task<StockPurchaseOrderResponse> GetStockPurchaseOrderId(int companyId)
        {
            StockPurchaseOrderResponse stockPurchaseOrderResponse = new StockPurchaseOrderResponse();
            IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM;
            try
            {

                purchaseOrderSummeryVM = new List<PurchaseOrderSummeryVM>
                {
                    await _purchaseOrderServices.GetStockPurchaseOrderId(companyId)
                };
                stockPurchaseOrderResponse.purchaseOrderSummeryVM = purchaseOrderSummeryVM;
                stockPurchaseOrderResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockPurchaseOrderResponse.IsSuccess = false;
                stockPurchaseOrderResponse.Message = exc.Message;
            }
            return stockPurchaseOrderResponse;
        }

        [HttpGet("{userId}")]
        public async Task<StockPurchaseOrderResponse> GetPurchaseOrderDraftDetailsByUserId(int userId)
        {
            StockPurchaseOrderResponse stockPurchaseOrderResponse = new StockPurchaseOrderResponse();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                purchaseOrderItemVM = await _purchaseOrderServices.GetPurchaseOrderDraftDetailsByUserId(userId);
                stockPurchaseOrderResponse.purchaseOrderItem = purchaseOrderItemVM;
                stockPurchaseOrderResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderResponse.IsSuccess = false;
                stockPurchaseOrderResponse.Message = ex.Message;
            }
            return stockPurchaseOrderResponse;
        }
        [HttpPost]
        public async Task<StockPurchaseOrderSummeryResponse> AddPurschaseOrderSummeryDetails([FromBody]NewPurchaseOrderRequest newPurchaseOrderRequest)
        {
            StockPurchaseOrderSummeryResponse stockPurchaseOrderSummeryResponse = new StockPurchaseOrderSummeryResponse();
           IEnumerable< NewPurchaseOrderVM> newPurchaseOrderVm ;
            try
            {
                newPurchaseOrderVm = new List<NewPurchaseOrderVM>{
                   await _purchaseOrderServices.AddPurschaseOrderSummeryDetails(newPurchaseOrderRequest.newPurchaseOrderVM) };
                stockPurchaseOrderSummeryResponse.IsSuccess = true;
                stockPurchaseOrderSummeryResponse.newPurchaseOrderVM = newPurchaseOrderVm;
                _logger.LogInformation(newPurchaseOrderRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockPurchaseOrderSummeryResponse.IsSuccess = false;
                stockPurchaseOrderSummeryResponse.Message = exc.Message;
            }
            return stockPurchaseOrderSummeryResponse;
        }

        [HttpPost]
        public async Task<StockPurchaseOrderItemResponse> AddPurschaseOrderItemDetails([FromBody] StockPurchaseOrderItemRequest stockPurchaseOrderItemRequest)
        {
            StockPurchaseOrderItemResponse stockPurchaseOrderItemResponse = new StockPurchaseOrderItemResponse();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItem;
            try
            {
                purchaseOrderItem = new List<PurchaseOrderItemVM>{
                    await _purchaseOrderServices.AddPurschaseOrderItemDetails(stockPurchaseOrderItemRequest.purchaseOrderItemVM)
                };
                stockPurchaseOrderItemResponse.purchaseOrderItem = purchaseOrderItem;
                stockPurchaseOrderItemResponse.IsSuccess = true;
                _logger.LogInformation(stockPurchaseOrderItemRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockPurchaseOrderItemResponse.IsSuccess = false;
                stockPurchaseOrderItemResponse.Message = exc.Message;
            }
            return stockPurchaseOrderItemResponse;
        }

        [HttpGet("{purchaseorderId},{companyId},{isDraft}")]
        public async Task<StockPurchaseOrderMasterResponse> GetPurchaseOrderDetailsById( string purchaseorderId, int companyId,bool isDraft)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>{
                    await _purchaseOrderServices.GetPurchaseOrderDetailsById( purchaseorderId, companyId,isDraft)
                };
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM= purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = exc.Message;
            }
            return stockPurchaseOrderMasterResponse;
        }
        [HttpGet("{userId},{companyId}")]
        public async Task<PurchaseDraftSummeryResponse> GetPurchaseOrderDraftSummeryDetailsByUserId(int companyId, int userId)
        {
            PurchaseDraftSummeryResponse purchaseDraftSummeryResponse = new PurchaseDraftSummeryResponse();
            IEnumerable<PurchaseDraftSummeryVM> purchaseDraftSummeryVM;

            try
            {
                purchaseDraftSummeryVM = await _purchaseOrderServices.GetPurchaseOrderDraftSummeryDetailsByUserId(companyId, userId);
                purchaseDraftSummeryResponse.PurchaseDraftSummeryVM = purchaseDraftSummeryVM;
                purchaseDraftSummeryResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseDraftSummeryResponse.IsSuccess = false;
                purchaseDraftSummeryResponse.Message = ex.Message;
            }
            return purchaseDraftSummeryResponse;
        }


        [HttpPut]
        public async Task<NewPurchaseOrderResponse> UpdatePurchaseOrderSummeryDetailsById([FromBody]NewPurchaseOrderRequest newPurchaseOrderRequest)
        {
            NewPurchaseOrderResponse newPurchaseOrderResponse = new NewPurchaseOrderResponse();
            IEnumerable<NewPurchaseOrderVM> newPurchaseOrderVm;
            try
            {
                newPurchaseOrderVm = new List<NewPurchaseOrderVM>
                {
                    await _purchaseOrderServices.UpdatePurchaseOrderSummeryDetailsById(newPurchaseOrderRequest.newPurchaseOrderVM)
                };
                newPurchaseOrderResponse.newPurchaseOrderVM = newPurchaseOrderVm;
                newPurchaseOrderResponse.IsSuccess = true;
                _logger.LogInformation(newPurchaseOrderRequest.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newPurchaseOrderResponse;
        }


        [HttpPut]
        public async Task<StockPurchaseOrderItemResponse> UpdatePurchaseOrderItemDetailsByPurchaseOrderId([FromBody]StockPurchaseOrderItemRequest stockPurchaseOrderItemRequest)
        {
            StockPurchaseOrderItemResponse stockPurchaseOrderItemResponse = new StockPurchaseOrderItemResponse();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVm;

            try
            {
                purchaseOrderItemVm = new List<PurchaseOrderItemVM>
                  {
                     await _purchaseOrderServices.UpdatePurchaseOrderItemDetailsByPurchaseOrderId(stockPurchaseOrderItemRequest.purchaseOrderItemVM)
                   };
                stockPurchaseOrderItemResponse.purchaseOrderItem = purchaseOrderItemVm;
                stockPurchaseOrderItemResponse.IsSuccess = true;
                _logger.LogInformation(stockPurchaseOrderItemRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderItemResponse.IsSuccess = false;
                stockPurchaseOrderItemResponse.Message = ex.Message;
            }
            return stockPurchaseOrderItemResponse;
        }
        [HttpPut]
        public async Task<PurchaseOrderFinalResponse> UpdatePurchaseOrderById([FromBody]PurchaseOrderFinalRequest purchaseOrderFinalRequest)
        {
            PurchaseOrderFinalResponse purchaseOrderFinalResponse = new PurchaseOrderFinalResponse();
            IEnumerable<PurchaseOrderFinalVM> purchaseOrderFinalVm;

            try
            {
                purchaseOrderFinalVm = new List<PurchaseOrderFinalVM>
                {
                    await _purchaseOrderServices.UpdatePurchaseOrderById(purchaseOrderFinalRequest.purchaseOrderFinalVM)
                };
                purchaseOrderFinalResponse.purchaseOrderFinalVM = purchaseOrderFinalVm;
                purchaseOrderFinalResponse.IsSuccess = true;
                _logger.LogInformation(purchaseOrderFinalRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderFinalResponse.IsSuccess = false;
                purchaseOrderFinalResponse.Message = ex.Message;
            }
            return purchaseOrderFinalResponse;
        }

        [HttpDelete("{purchaseOrderId}")]
        public async Task<StockPurchaseOrderItemResponse> DeletePurchaseOrderItemDetailsByPurchaseOrderId(int purchaseOrderId)
        {

            StockPurchaseOrderItemResponse stockPurchaseOrderItemResponse = new StockPurchaseOrderItemResponse();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVm;
            try
            {
                purchaseOrderItemVm = new List<PurchaseOrderItemVM>
                  {
                     await _purchaseOrderServices.DeletePurchaseOrderItemDetailsByPurchaseOrderId(purchaseOrderId)
                   };
                stockPurchaseOrderItemResponse.purchaseOrderItem = purchaseOrderItemVm;
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

        [HttpPut]
        public async Task<NewPurchaseOrderResponse> UpdateAllPurchaseOrderRecieved(int purchaseOrderId, int userId)
        {
            NewPurchaseOrderResponse newPurchaseOrderResponse = new NewPurchaseOrderResponse();
            IEnumerable<NewPurchaseOrderVM> newPurchaseOrderVM;
            try
            {
                newPurchaseOrderVM = new List<NewPurchaseOrderVM>
                {
                    await _purchaseOrderServices.UpdateAllPurchaseOrderRecieved(purchaseOrderId,userId)
                };
                newPurchaseOrderResponse.newPurchaseOrderVM = newPurchaseOrderVM;
                newPurchaseOrderResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                newPurchaseOrderResponse.IsSuccess = false;
                newPurchaseOrderResponse.Message = ex.Message;
            }
            return newPurchaseOrderResponse;
        }
        [HttpGet("{purchaseorderId}")]
        public async Task<StockPurchaseOrderItemResponse> GetPurchaseOrderItemDraftDetailsById(string purchaseorderId)
        {
            StockPurchaseOrderItemResponse stockPurchaseOrderItemResponse = new StockPurchaseOrderItemResponse();
           IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            try
            {
                purchaseOrderItemVM = await _purchaseOrderServices.GetPurchaseOrderItemDraftDetailsById(purchaseorderId);
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

        [HttpPut]
        public async Task<StockPurchaseOrderMasterResponse> UpdatePurchaseOrderStatusByPurchaseNo([FromBody] StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest) {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                int userId = stockPurchaseOrderMasterRequest.purchaseOrderMasterVM.UserId;
                string purchaseNo = stockPurchaseOrderMasterRequest.purchaseOrderMasterVM.PurchaseNo;
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>{
                    await _purchaseOrderServices.UpdatePurchaseOrderStatusByPurchaseNo(purchaseNo,userId)
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
    }
}