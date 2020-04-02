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
using OnimtaWebInventory.DTO.StockPurchaseOrderMaster;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PurchaseOrderBillController : Controller
    {
        private ILogger<PurchaseOrderBillController> _logger;
        private IPurchaseOrderBillServices _purchaseOrderBillServices;

        public PurchaseOrderBillController(IPurchaseOrderBillServices PurchaseOrderBillServices, ILogger<PurchaseOrderBillController> logger)
        {
            _purchaseOrderBillServices = PurchaseOrderBillServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<StockPurchaseOrderMasterResponse> AddPurchaseOrderBillDetails([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest )
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderBillServices.AddPurchaseOrderBillDetails(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
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

        [HttpPut]
        public async Task<StockPurchaseOrderMasterResponse> UpdatePurchaseOrderBillDetails([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderBillServices.UpdatePurchaseOrderBillDetails(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
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



        [HttpPut]
        public async Task<StockPurchaseOrderMasterResponse> UpdatePartiallyPurchaseOrderBillDetails([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderBillServices.UpdatePartiallyPurchaseOrderBillDetails(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
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

        [HttpGet("{purchaseNo}")]
        public async Task<StockPurchaseOrderMasterResponse> GetPurchaseOrderBillDetailsByPurchaseNo(int purchaseNo)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _purchaseOrderBillServices.GetPurchaseOrderBillDetailsByPurchaseNo(purchaseNo)
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
        [HttpGet("{pageId}")]
        public async Task<StockPurchaseOrderMasterResponse> GetAllPurchaseOrderBillDetails(int pageId)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = await _purchaseOrderBillServices.GetAllPurchaseOrderBillDetails(pageId);
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

        [HttpGet("{companyId}")]
        public async Task<PurchaseOrderBillResponse> GetAllBillEventDetailsByCompanyId(int companyId)
        {
            PurchaseOrderBillResponse purchaseOrderBillResponse = new PurchaseOrderBillResponse();
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM;
            try
            {
                purchaseOrderBilledEventsVM = await _purchaseOrderBillServices.GetAllBillEventDetailsByCompanyId(companyId);
                purchaseOrderBillResponse.purchaseOrderBilledEventsVM = purchaseOrderBilledEventsVM;
                purchaseOrderBillResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderBillResponse.IsSuccess = false;
                purchaseOrderBillResponse.Message = ex.Message;
            }
            return purchaseOrderBillResponse;
        }

        [HttpGet("{businessPartnerId}")]
        public async Task<PurchaseOrderBillResponse> GetPurchaseOrderBilledDetailsByBusinessPartnerId(string businessPartnerId)
            {
            PurchaseOrderBillResponse purchaseOrderBillResponse = new PurchaseOrderBillResponse();
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM;
            try
            {
                purchaseOrderBilledEventsVM = await _purchaseOrderBillServices.GetPurchaseOrderBilledDetailsByBusinessPartnerId(businessPartnerId);
                purchaseOrderBillResponse.purchaseOrderBilledEventsVM = purchaseOrderBilledEventsVM;
                purchaseOrderBillResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderBillResponse.IsSuccess = false;
                purchaseOrderBillResponse.Message = ex.Message;
            }

            return purchaseOrderBillResponse;
        }
    }
}