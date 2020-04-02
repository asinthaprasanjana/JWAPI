using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using NotificationApi.Controllers;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Stock;
using OnimtaWebInventory.DTO.StockTransfer;
using OnimtaWebInventory.DTO.StockTransferItem;
using OnimtaWebInventory.DTO.StockTransferSummery;
using OnimtaWebInventory.Models;
using SignalRHub;

namespace OnimtaWebApi.Controllers
{

    [Route("api/[controller]/[action]")]
   // [Authorize]
    public class StockTransferController : Controller
    {
        private IStockTransferServices _StockTransferServices;
        private ILogger<StockTransferController> _logger;

        public StockTransferController(IStockTransferServices StockTranferServices, ILogger<StockTransferController> logger)
        {
            _StockTransferServices = StockTranferServices;
            _logger = logger;
        }

        [HttpGet("{companyId}")]
        public async Task<StockTransferSummeryResponse> GetStockTransferId(int companyId)
        {
            StockTransferSummeryResponse stockTransferResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
                stockTransferSummeryVM = await _StockTransferServices.GetStockTransferId(companyId);
                stockTransferResponse.IsSuccess = true;
                stockTransferResponse.stockTransferSummeryVM = stockTransferSummeryVM;
            
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferResponse.IsSuccess = false;
                stockTransferResponse.Message = exc.Message;
            }
            return stockTransferResponse;
        }

        [HttpPost]
        public async Task<StockTransferSummeryResponse> AddStockTransferSummeryDetailsDraft([FromBody]StockTransferSummeryRequest stockTransferSummeryRequest)
        {
            StockTransferSummeryResponse stockTransferResponse = new StockTransferSummeryResponse();
           IEnumerable< StockTransferSummeryVM> stockTransferSummeryVm ;
            try
            {
                stockTransferSummeryVm = new List<StockTransferSummeryVM>{
                    await _StockTransferServices.AddStockTransferSummeryDetailsDraft(stockTransferSummeryRequest.stockTransferSummeryVM) };
                stockTransferResponse.stockTransferSummeryVM = stockTransferSummeryVm;
                stockTransferResponse.IsSuccess = true;
                _logger.LogInformation(stockTransferSummeryRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferResponse.IsSuccess = false;
                stockTransferResponse.Message = exc.Message;
            }
            return stockTransferResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<StockTransferSummeryResponse> GetStockTransferSummaryDetails(int companyId)
        {
            StockTransferSummeryResponse stockTranserSummeryResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVm;
            try
            {
                stockTransferSummeryVm = await _StockTransferServices.GetStockTransferSummaryDetails(companyId);
                stockTranserSummeryResponse.stockTransferSummeryVM = stockTransferSummeryVm;
                stockTranserSummeryResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTranserSummeryResponse.IsSuccess = false;
                stockTranserSummeryResponse.Message = exc.Message;
            }
            return stockTranserSummeryResponse;
        }

        [HttpGet("{transferId},{companyId}")]
        public async Task<StockTransferSummeryResponse> GetStockTransferDetailsById( int transferId, int companyId)
        {
            StockTransferSummeryResponse stockTransferResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
                stockTransferSummeryVM = new List<StockTransferSummeryVM>
                {
                    await _StockTransferServices.GetStockTransferDetailsById(transferId,companyId)
                };
                stockTransferResponse.stockTransferSummeryVM = stockTransferSummeryVM;
                stockTransferResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferResponse.IsSuccess = false;
                stockTransferResponse.Message = exc.Message;
            }
            return stockTransferResponse;
        }

        [HttpPost]
        public async Task<StockTransferItemResponse> AddStockTransferItemDraft([FromBody]StockTransferItemRequest stockTransferItemRequest)
        {
            StockTransferItemResponse stockTransferItemResponse = new StockTransferItemResponse();
           IEnumerable<StockTransferItemVM> stockTransferItemVm;
            try
            {
                stockTransferItemVm = new List<StockTransferItemVM>{
                    await _StockTransferServices.AddStockTransferItemDraft(stockTransferItemRequest.stockTransferItemVM)
                };
               
                stockTransferItemResponse.stockTransferItemVm = stockTransferItemVm;
                stockTransferItemResponse.IsSuccess = true;
                _logger.LogInformation(stockTransferItemRequest .ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferItemResponse.IsSuccess = false;
                stockTransferItemResponse.Message = exc.Message;
            }
            return stockTransferItemResponse;
        }

        [HttpDelete("{id}")]
        public async Task<StockTransferItemResponse> DeleteStockTransferItemById(int Id)
        {
            StockTransferItemResponse stockTransferItemResponse = new StockTransferItemResponse();
            IEnumerable<StockTransferItemVM> stockTransferItemVm;
            try
            {
                stockTransferItemVm = new List<StockTransferItemVM>{
                    await _StockTransferServices.DeleteStockTransferItemById(Id)
                };

                stockTransferItemResponse.stockTransferItemVm = stockTransferItemVm;
                stockTransferItemResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferItemResponse.IsSuccess = false;
                stockTransferItemResponse.Message = exc.Message;
            }
            return stockTransferItemResponse;
        }

        [HttpPut("{transferId}")]
        public async Task<StockTransferSummeryResponse> updateStockTransferDetails(int transferId)
        {
            StockTransferSummeryResponse stockTransferResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVm;
            try
            {
                stockTransferSummeryVm = new List<StockTransferSummeryVM>{
                    await _StockTransferServices.updateStockTransferDetails(transferId) };
                stockTransferResponse.stockTransferSummeryVM = stockTransferSummeryVm;
                stockTransferResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferResponse.IsSuccess = false;
                stockTransferResponse.Message = exc.Message;
            }
            return stockTransferResponse;
        }

        //[HttpPut("{transferId},{transferIdDraft}")]
        //public async Task<StockTransferItemResponse> updateStockTransferItem(int transferId, int transferIdDraft)
        //{
        //    StockTransferItemResponse StockTransferItemResponse = new StockTransferItemResponse();
        //    IEnumerable<StockTransferItemVM> StockTransferItemVM;
        //    try
        //    {
        //        StockTransferItemVM = await _StockTransferServices.updateStockTransferItem(transferId,transferIdDraft);
        //        StockTransferItemResponse.stockTransferItemVm = StockTransferItemVM;
        //        StockTransferItemResponse.IsSuccess = true;
        //    }
        //    catch (Exception exc)
        //    {
        //        _logger.LogError(exc.Message);
        //        StockTransferItemResponse.IsSuccess = false;
        //        StockTransferItemResponse.Message = exc.Message;
        //    }
        //    return StockTransferItemResponse;
        //}

        [HttpGet]
        public async Task<StockTransferSummeryResponse> GetAllTransferSummeryDraft()
        {
            StockTransferSummeryResponse stockTranserSummeryResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVm;
            try
            {
                stockTransferSummeryVm = await _StockTransferServices.GetAllTransferSummeryDraft();
                stockTranserSummeryResponse.stockTransferSummeryVM = stockTransferSummeryVm;
                stockTranserSummeryResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTranserSummeryResponse.IsSuccess = false;
                stockTranserSummeryResponse.Message = exc.Message;
            }
            return stockTranserSummeryResponse;
        }

        [HttpGet("{TransferId}")]
        public async Task<StockTransferItemResponse> GetAllTransferItemDraftByTransferId(string TransferId)
        {
            StockTransferItemResponse stockTransferItemResponse = new StockTransferItemResponse();
            IEnumerable<StockTransferItemVM> StockTransferItemVM;
            try
            {
                StockTransferItemVM = await _StockTransferServices.GetStockTransferItemDraftByTransferId(TransferId);
                stockTransferItemResponse.stockTransferItemVm = StockTransferItemVM;
                stockTransferItemResponse.IsSuccess=true;
            }
            catch(Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferItemResponse.IsSuccess = false;
                stockTransferItemResponse.Message = exc.Message;
            }

            return stockTransferItemResponse;
        }

        [HttpGet("{branchId}")]
        public async Task<StockTransferSummeryResponse> GetStockTranferSummeryDetailsByDestinationId(int BranchId)
        {
            StockTransferSummeryResponse stockTranserSummeryResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVm;
            try
            {
                stockTransferSummeryVm = await _StockTransferServices.GetStockTranferSummeryDetailsByDestinationId(BranchId);
                stockTranserSummeryResponse.stockTransferSummeryVM = stockTransferSummeryVm;
                stockTranserSummeryResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTranserSummeryResponse.IsSuccess = false;
                stockTranserSummeryResponse.Message = exc.Message;
            }
            return stockTranserSummeryResponse;
        }

        [HttpGet("{TransferId}")]
        public async Task<StockTransferItemResponse> GetAllTransferItemByTransferId(string TransferId)
        {
            StockTransferItemResponse stockTransferItemResponse = new StockTransferItemResponse();
            IEnumerable<StockTransferItemVM> StockTransferItemVM;
            try
            {
                StockTransferItemVM = await _StockTransferServices.GetStockTransferItemByTransferId(TransferId);
                stockTransferItemResponse.stockTransferItemVm = StockTransferItemVM;
                stockTransferItemResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferItemResponse.IsSuccess = false;
                stockTransferItemResponse.Message = exc.Message;
            }

            return stockTransferItemResponse;
        }

        [HttpPut]
        public async Task<StockTransferSummeryResponse> UpdateStockTransferSummeryDetailsByTransferId([FromBody]StockTransferSummeryRequest stockTransferSummeryRequest)
        {
            StockTransferSummeryResponse stockTransferResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVm;
            try
            {
                stockTransferSummeryVm = new List<StockTransferSummeryVM>{
                    await _StockTransferServices.UpdateStockTransferSummeryDetailsByTransferId(stockTransferSummeryRequest.stockTransferSummeryVM) };
                stockTransferResponse.stockTransferSummeryVM = stockTransferSummeryVm;
                stockTransferResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferResponse.IsSuccess = false;
                stockTransferResponse.Message = exc.Message;
            }
            return stockTransferResponse;
        }

        [HttpGet("{branchId}")]
        public async Task<StockTransferSummeryResponse> GetStockTranferSummeryDetailsBySourceId(int BranchId)
        {
            StockTransferSummeryResponse stockTranserSummeryResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVm;
            try
            {
                stockTransferSummeryVm = await _StockTransferServices.GetStockTranferSummeryDetailsBySourceId(BranchId);
                stockTranserSummeryResponse.stockTransferSummeryVM = stockTransferSummeryVm;
                stockTranserSummeryResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTranserSummeryResponse.IsSuccess = false;
                stockTranserSummeryResponse.Message = exc.Message;
            }
            return stockTranserSummeryResponse;
        }


        [HttpGet("{pageNumber},{rows}")]
        public async Task<StockTransferSummeryResponse> GetAllStockTransferSummary(int pageNumber,int rows)
        {
            StockTransferSummeryResponse stockTranserSummeryResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVm;
            try
            {
                stockTransferSummeryVm = await _StockTransferServices.GetStockTranferSummeryDetails(pageNumber,rows);
                stockTranserSummeryResponse.stockTransferSummeryVM = stockTransferSummeryVm;
                stockTranserSummeryResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTranserSummeryResponse.IsSuccess = false;
                stockTranserSummeryResponse.Message = exc.Message;
            }
            return stockTranserSummeryResponse;
        }
    }
    } 






