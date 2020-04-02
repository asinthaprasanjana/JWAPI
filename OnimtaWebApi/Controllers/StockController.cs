using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using NotificationApi.Controllers;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Stock;
using OnimtaWebInventory.DTO.StockTransactionType;
using OnimtaWebInventory.DTO.StockTransfer;
using OnimtaWebInventory.Models;
using SignalRHub;

namespace OnimtaWebApi.Controllers
{
 
    [Route("api/[controller]/[action]")]
    public class StockController : Controller
    {
        private IStockServices _stockServices ;
        private ILogger<StockController> _logger;

        public StockController(IStockServices stockServices, ILogger<StockController> logger  )
        {
            _stockServices = stockServices;
            _logger = logger;
        }
        [HttpGet("{stockId},{companyId}")]
        public async Task<StockResponse> GetStockDetailsById(int stockId, int companyId)
        {
            StockResponse stockResponse = new StockResponse();
            IEnumerable<StockVM> stockVM;
            try
            {
                stockVM = new List<StockVM> {
                   await _stockServices.GetStockDetailsById(stockId,companyId)
            };
                stockResponse.stockVM = stockVM;
                stockResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockResponse.IsSuccess = false;
                stockResponse.Message = exc.Message;
            }
            return stockResponse;
        }
        [HttpGet("{companyId}")]
        public async Task<IEnumerable<StockResponse>> GetStockTransactionDetails(int companyId)
        {
            //StockResponse stockResponse = new StockResponse();
            StockTransferSummeryResponse stockTransferSummeryResponse = new StockTransferSummeryResponse();
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            try
            {
              stockTransferSummeryVM = await _stockServices.GetStockTransactionDetails(companyId);
                stockTransferSummeryResponse.stockTransferSummeryVM = stockTransferSummeryVM;
                stockTransferSummeryResponse.IsSuccess = true;
                return null;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockTransferSummeryResponse.IsSuccess = true;
                stockTransferSummeryResponse.Message = exc.Message;
            }
            return null;
        }
        [HttpGet("{businessPartnerId}") ]
        public async Task <IEnumerable<StockResponse>>GetSupplierItems(int businessPartnerId)
        {
            StockResponse stockResponse =new StockResponse();
            IEnumerable<StockVM> stockVM;
            try
            {
                stockVM = await _stockServices.GetSupplierItem(businessPartnerId);
                stockResponse.stockVM = stockVM;
                stockResponse.IsSuccess = true;
                return null;
            }

            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                stockResponse.IsSuccess = false;
                stockResponse.Message = ex.Message;
            }
            return null;
        }
        [HttpGet("{supplierId},{companyId},{itemName}")]
        public async Task<StockResponse> GetItemsBySupplierId(int supplierId, int companyId, string itemName)
        {
            StockResponse stockResponse = new StockResponse();
            IEnumerable<StockVM> stockVM;
            try
            {
                stockVM = await _stockServices.GetItemsBySupplierId(supplierId, companyId,itemName);
                stockResponse.IsSuccess = true;
                stockResponse.stockVM = stockVM;
                return stockResponse;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockResponse.IsSuccess = true;
                stockResponse.Message = exc.Message;
            }
        
            return null;
        }

        [HttpGet("{transactionTypeId}")]
        public async Task<StockTransactionTypeResponse> GetIdByStockTransactionTypeId(int transactionTypeId)
        {
            StockTransactionTypeResponse stockTransactionTypeResponse = new StockTransactionTypeResponse();
            IEnumerable<StockTransactionTypeVm> stockTransactionTypeVm;

            try
            {
                stockTransactionTypeVm = new List<StockTransactionTypeVm>
                {
                 //   await _stockServices.GetIdByStockTransactionTypeId(transactionTypeId)
                };
                stockTransactionTypeResponse.stockTransactionTypeVm = stockTransactionTypeVm;
                stockTransactionTypeResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                stockTransactionTypeResponse.IsSuccess = false;
                stockTransactionTypeResponse.Message = ex.Message;
            }
            return stockTransactionTypeResponse;
        }



    }
}
