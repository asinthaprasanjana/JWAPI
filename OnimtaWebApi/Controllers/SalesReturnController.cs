using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.SalesReturn;
using OnimtaWebInventory.DTO.StockPurchaseOrderMaster;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class SalesReturnController : Controller
    {
        private ISalesReturnServices _salesReturnServices;
        private ILogger<ISalesReturnServices> _logger;

        public SalesReturnController(ISalesReturnServices SalesReturnServices, ILogger<ISalesReturnServices> logger)
        {
            _salesReturnServices = SalesReturnServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<SalesReturnResponse> AddNewSalesReturnDetails([FromBody]SalesReturnRequest salesReturnRequest)
        {
            SalesReturnResponse salesReturnResponse = new SalesReturnResponse();
            IEnumerable<SalesReturnVM> salesReturnVm;
            try
            {
                salesReturnVm = new List<SalesReturnVM>
                {
                    await _salesReturnServices.AddNewSalesReturnDetails(salesReturnRequest.salesOrderMasterVM)
                };
                salesReturnResponse.salesReturnVM = salesReturnVm;
                salesReturnResponse.IsSuccess = true;
                _logger.LogInformation(salesReturnRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                salesReturnResponse.IsSuccess = false;
                salesReturnResponse.Message = ex.Message;
            }
            return salesReturnResponse;
        }

        [HttpPut]
        public async Task<SalesReturnResponse> UpdateSalesReturnDetails([FromBody]SalesReturnRequest salesReturnRequest)
        {
            SalesReturnResponse salesReturnResponse = new SalesReturnResponse();
            IEnumerable<SalesReturnVM> salesReturnVm;
            try
            {
                //salesReturnVm = new List<SalesReturnVM>
                //{
                //    await _salesReturnServices.UpdateSalesReturnDetails(salesReturnRequest.salesReturnMasterVM)
                //};
                //salesReturnResponse.salesReturnVM = salesReturnVm;
                //salesReturnResponse.IsSuccess = true;
                //_logger.LogInformation(salesReturnRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                salesReturnResponse.IsSuccess = false;
                salesReturnResponse.Message = ex.Message;
            }
            return salesReturnResponse;
        }

        [HttpGet("{orderId}")]
        public async Task<SalesReturnResponse> GetAllSalesDetails(int orderId)
        {
            SalesReturnResponse salesReturnResponse = new SalesReturnResponse();
            IEnumerable<SalesReturnVM> salesReturnVM;

            try
            {
                salesReturnVM = await _salesReturnServices.GetAllSalesDetails(orderId);
                salesReturnResponse.salesReturnVM = salesReturnVM;
                salesReturnResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                salesReturnResponse.IsSuccess = false;
                salesReturnResponse.Message = ex.Message;
            }
            return salesReturnResponse;
        }

        [HttpGet("{orderId}")]
        public async Task<SalesReturnResponse> GetSalesDetailsById(int orderId)
        {
            SalesReturnResponse salesReturnResponse = new SalesReturnResponse();
            IEnumerable<SalesReturnVM> salesReturnVM;

            try
            {
                salesReturnVM = new List<SalesReturnVM>
                {
                  await _salesReturnServices.GetSalesDetailsById(orderId)
                };
                salesReturnResponse.salesReturnVM = salesReturnVM;
                salesReturnResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                salesReturnResponse.IsSuccess = false;
                salesReturnResponse.Message = ex.Message;
            }
            return salesReturnResponse;
        }
        [HttpPost]
        public async Task<StockPurchaseOrderMasterResponse> AddSalesReturnDetails([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _salesReturnServices.AddSalesReturnDetails(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
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
        public async Task<StockPurchaseOrderMasterResponse> UpdateSalesReturn([FromBody]StockPurchaseOrderMasterRequest stockPurchaseOrderMasterRequest)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>
                {
                    await _salesReturnServices.UpdateSalesReturn(stockPurchaseOrderMasterRequest.purchaseOrderMasterVM)
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

        [HttpGet("{id}")]
        public async Task<StockPurchaseOrderMasterResponse> GetSalesReturnDetailsById(int id)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = new List<PurchaseOrderMasterVM>{
                    await _salesReturnServices.GetSalesReturnDetailsById(id)
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
        [HttpGet("{branchId}")]
        public async Task<StockPurchaseOrderMasterResponse> GetAllSalesReturnDetails(int branchId)
        {
            StockPurchaseOrderMasterResponse stockPurchaseOrderMasterResponse = new StockPurchaseOrderMasterResponse();
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            try
            {
                purchaseOrderMasterVM = await _salesReturnServices.GetAllSalesReturnDetails(branchId);
                stockPurchaseOrderMasterResponse.purchaseOrderMasterVM = purchaseOrderMasterVM;
                stockPurchaseOrderMasterResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                stockPurchaseOrderMasterResponse.IsSuccess = false;
                stockPurchaseOrderMasterResponse.Message = ex.Message;
            }
            return stockPurchaseOrderMasterResponse;
                
        }
    }
}