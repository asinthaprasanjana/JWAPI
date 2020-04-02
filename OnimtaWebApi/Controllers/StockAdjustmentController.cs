using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.StockAdjusment;
using OnimtaWebInventory.DTO.StockAdjustmentSummery;
using OnimtaWebInventory.DTO.StockAdjustmentDetails;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StockAdjustmentController : Controller
    {
        private IStockAdjusmentServices _stockAdjusmentServices;
        private ILogger<StockAdjustmentController> _logger;

        public StockAdjustmentController(IStockAdjusmentServices StockAdjusmentServices, ILogger<StockAdjustmentController> logger)
        {
            _stockAdjusmentServices = StockAdjusmentServices;
            _logger = logger;
           
        }
        [HttpGet("{companyId}")]
        public async Task<StockAdjustmentSummeryResponse> GetStockAdjusmentSummeryByCompanyId(int companyId)
        {
            IEnumerable<StockAdjustmentSummeryVM> stockAdjustmentSummeryVM;
  
            StockAdjustmentSummeryResponse stockAdjustmentResponse = new StockAdjustmentSummeryResponse();
            try
            {
                 stockAdjustmentSummeryVM = await _stockAdjusmentServices.GetStockAdjusmentSummeryByCompanyId(companyId);
                stockAdjustmentResponse.stockAdjustmentSummeryVM = stockAdjustmentSummeryVM;
                stockAdjustmentResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockAdjustmentResponse.IsSuccess = false;
                stockAdjustmentResponse.Message = exc.Message;
            }

            return stockAdjustmentResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<StockAdjustmentSummeryResponse> GetStockAdjusmenId(int companyId)
        {
            StockAdjustmentSummeryResponse stockAdjusmentResponse = new StockAdjustmentSummeryResponse();
          IEnumerable< StockAdjustmentSummeryVM> stockAdjustmentSummeryVM;
            try
            {
                 stockAdjustmentSummeryVM = new List<StockAdjustmentSummeryVM> {
                   await _stockAdjusmentServices.GetStockAdjusmentId(companyId)
                };
                stockAdjusmentResponse.stockAdjustmentSummeryVM = stockAdjustmentSummeryVM;
                stockAdjusmentResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message );
                stockAdjusmentResponse.IsSuccess = false;
                stockAdjusmentResponse.Message = exc.Message;
            }

            return stockAdjusmentResponse;
        }


     
        [HttpPost]
        public async Task<StockAdjustmentDetailsResponse> AddstockAdjusmentDetails([FromBody]StockAdjustmentDetailsRequest stockAdjustmentDetailsRequest)
        {
            StockAdjustmentDetailsResponse StockAdjustmentDetailsResponse = new StockAdjustmentDetailsResponse();
           IEnumerable<StockAdjustmentDetailVM> StockAdjustmentDetailVm;
            try
            {
                StockAdjustmentDetailVm =  new List<StockAdjustmentDetailVM>{
                    await _stockAdjusmentServices.AddstockAdjusmentDetails(stockAdjustmentDetailsRequest.StockAdjustmentDetailVM) };
                StockAdjustmentDetailsResponse.StockAdjustmentDetailVM = StockAdjustmentDetailVm;
                StockAdjustmentDetailsResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                StockAdjustmentDetailsResponse.IsSuccess = false;
                StockAdjustmentDetailsResponse.Message = exc.Message;
            }
            return StockAdjustmentDetailsResponse;
        }

        [HttpGet("{BranchId},{ProductId}")]
        public async Task<StockAdjustmentDetailsResponse> GetProductStockCountByBranchId(int BranchId, int ProductId)
        {
            int availableStock;
            StockAdjustmentDetailsResponse stockAdjustmentDetailsResponse = new StockAdjustmentDetailsResponse();
            try
            {
                stockAdjustmentDetailsResponse.StockAdjustmentDetailVM =  await _stockAdjusmentServices.GetProductStockCountByBranchId(BranchId,ProductId);
                stockAdjustmentDetailsResponse.IsSuccess = true;
               // stockAdjustmentDetailsResponse.AvailableStock = availableStock;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockAdjustmentDetailsResponse.IsSuccess = false;
                stockAdjustmentDetailsResponse.Message = exc.Message;
            }
            return stockAdjustmentDetailsResponse;
        }


        [HttpGet("{StockAdjusmentId}")]
        public async Task<StockAdjustmentSummeryResponse> GetStockAdjusmentDetailsByAdjusmentId(string StockAdjusmentId)
        {
            StockAdjustmentSummeryResponse stockAdjustmentDetailsResponse = new StockAdjustmentSummeryResponse();
           IEnumerable< StockAdjustmentSummeryVM>  stockAdjustmentSummeryVM ;
            try
            {
                stockAdjustmentSummeryVM = new List<StockAdjustmentSummeryVM>
                {
                  await _stockAdjusmentServices.GetStockAdjusmentDetailsByAdjusmentId(StockAdjusmentId)
               };
                stockAdjustmentDetailsResponse.stockAdjustmentSummeryVM = stockAdjustmentSummeryVM;
                stockAdjustmentDetailsResponse.IsSuccess = true;
            }

            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockAdjustmentDetailsResponse.IsSuccess = false;
                stockAdjustmentDetailsResponse.Message = exc.Message;
            }

            return stockAdjustmentDetailsResponse;
        }

        [HttpGet("{BranchId}")]
        public async Task<StockAdjustmentSummeryResponse> GetStockAdjusmentSummeryByBranchId(int BranchId)
        {
            IEnumerable<StockAdjustmentSummeryVM> stockAdjustmentSummeryVM;

            StockAdjustmentSummeryResponse stockAdjustmentResponse = new StockAdjustmentSummeryResponse();
            try
            {
                stockAdjustmentSummeryVM = await _stockAdjusmentServices.GetStockAdjusmentSummeryByBranchId(BranchId);
                stockAdjustmentResponse.stockAdjustmentSummeryVM = stockAdjustmentSummeryVM;
                stockAdjustmentResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockAdjustmentResponse.IsSuccess = false;
                stockAdjustmentResponse.Message = exc.Message;
            }

            return stockAdjustmentResponse;
        }
    }
}
