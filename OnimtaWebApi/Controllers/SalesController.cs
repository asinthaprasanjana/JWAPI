using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.ApplicationUser;
using OnimtaWebInventory.DTO.Approval;
using OnimtaWebInventory.DTO.FunctionApprovalTypeResponse;
using OnimtaWebInventory.DTO.OwnApprovalDetail;
using OnimtaWebInventory.DTO.PurchaseDraftSummery;
using OnimtaWebInventory.DTO.SalesOrderFinal;
using OnimtaWebInventory.DTO.SalesSummary;
using OnimtaWebInventory.DTO.SalesView;
using OnimtaWebInventory.DTO.StockSalesOrderItem;
using OnimtaWebInventory.DTO.StockSalesOrderMaster;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class SalesController : Controller


    {
        private ISalesServices _SalesServices;
        private ILogger<SalesController> _logger;


        public SalesController(ISalesServices SalesServices, ILogger<SalesController> logger)
        {
            _SalesServices = SalesServices;
            _logger = logger;
        }

        
        [HttpGet("{companyId}")]
        public async Task<SalesSummaryResponse> GetsalesOrderId(int companyId)
        {
            SalesSummaryResponse salesSummaryResponse = new SalesSummaryResponse();
            try
            {

                salesSummaryResponse.salesSummaryVM = await _SalesServices.GetSalesSummeryDetails(companyId);
                    
                salesSummaryResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                salesSummaryResponse.IsSuccess = false;
                salesSummaryResponse.Message = exc.Message;
            }
            return salesSummaryResponse;
        }

        [HttpPost]
        public async Task<SalesSummaryResponse> AddSalesSummaryDetails([FromBody]SalesSummaryRequest salesSummaryRequest)
        {
            SalesSummaryResponse salesSummaryResponse = new SalesSummaryResponse();
            IEnumerable<SalesSummaryVM> newSalesOrderVm;
            try
            {
                newSalesOrderVm = new List<SalesSummaryVM>
                {
                    await _SalesServices.AddSalesSummeryDetails(salesSummaryRequest.salesSummaryVM)
                };
                salesSummaryResponse.salesSummaryVMs = newSalesOrderVm;
                salesSummaryResponse.IsSuccess = true;
                _logger.LogInformation(salesSummaryRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                salesSummaryResponse.IsSuccess = false;
                salesSummaryResponse.Message = ex.Message;
            }
            return salesSummaryResponse;
        }

        [HttpGet("{companyId},{userId}")]
        public async Task<SalesDraftSummaryResponse> GetSalesOrderDraftSummeryDetailsByUserId(int companyId, int userId)
        {
            SalesDraftSummaryResponse salesDraftSummaryResponse = new SalesDraftSummaryResponse();
            IEnumerable<SalesDraftSummaryVM> salesDraftSummaryVM;

            try
            {
                salesDraftSummaryVM = await _SalesServices.GetSalesOrderDraftSummaryDetailsByUserId(companyId, userId);
                salesDraftSummaryResponse.SalesDraftSummaryVM = salesDraftSummaryVM;
                salesDraftSummaryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                salesDraftSummaryResponse.IsSuccess = false;
                salesDraftSummaryResponse.Message = ex.Message;
            }
            return salesDraftSummaryResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<SalesDraftSummaryResponse> GetSalesOrderDraftSummeryDetailsByCompanyId(int companyId)
        {
            SalesDraftSummaryResponse salesDraftSummaryResponse = new SalesDraftSummaryResponse();
            IEnumerable<SalesDraftSummaryVM> salesDraftSummaryVM;

            try
            {
                salesDraftSummaryVM = await _SalesServices.GetSalesOrderDraftSummaryDetailsByCompanyId(companyId);
                salesDraftSummaryResponse.SalesDraftSummaryVM = salesDraftSummaryVM;
                salesDraftSummaryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                salesDraftSummaryResponse.IsSuccess = false;
                salesDraftSummaryResponse.Message = ex.Message;
            }
            return salesDraftSummaryResponse;
        }


        [HttpGet("{isApproved}")]
        public async Task<SalesDraftSummaryResponse> GetSalesOrderSummeryDetailsByCompanyId(int isApproved)
        {
            SalesDraftSummaryResponse salesSummaryResponse = new SalesDraftSummaryResponse();
            IEnumerable<SalesDraftSummaryVM> salesSummaryVM;

            try
            {
                salesSummaryVM = await _SalesServices.GetSalesOrderSummaryDetailsByCompanyId(isApproved);
                salesSummaryResponse.SalesDraftSummaryVM = salesSummaryVM;
                salesSummaryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                salesSummaryResponse.IsSuccess = false;
                salesSummaryResponse.Message = ex.Message;
            }
            return salesSummaryResponse;
        }


        [HttpPost]
        public async Task<StockSalesOrderItemResponse> AddSalesOrderItemDetails([FromBody] StockSalesOrderItemRequest stockSalesOrderItemRequest)
        {
            StockSalesOrderItemResponse stockSalesOrderItemResponse = new StockSalesOrderItemResponse();
            IEnumerable<SalesOrderItemVM> newsalesOrderItem;
            try
            {
                newsalesOrderItem = new List<SalesOrderItemVM>{
                    await _SalesServices.AddSalesOrderItemDetails(stockSalesOrderItemRequest.salesOrderItemVM)
                };
                stockSalesOrderItemResponse.salesOrderItemVM = newsalesOrderItem;
                stockSalesOrderItemResponse.IsSuccess = true;
                _logger.LogInformation(stockSalesOrderItemRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockSalesOrderItemResponse.IsSuccess = false;
                stockSalesOrderItemResponse.Message = exc.Message;
               // throw new Exception(exc.Message);
            }
            return stockSalesOrderItemResponse;
        }

        [HttpDelete("{salesOrderId}")]
        public async Task<StockSalesOrderItemResponse> DeleteSalesOrderItemDetailsBySalesOrderId(int salesOrderId)
        {

            StockSalesOrderItemResponse stockSalesOrderItemResponse = new StockSalesOrderItemResponse();
            IEnumerable<SalesOrderItemVM> salesOrderItemVm;
            try
            {
                salesOrderItemVm = new List<SalesOrderItemVM>
                  {
                     await _SalesServices.DeleteSalesOrderItemDetailsBySalesOrderId(salesOrderId)
                   };
                stockSalesOrderItemResponse.salesOrderItemVM = salesOrderItemVm;
                stockSalesOrderItemResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                stockSalesOrderItemResponse.IsSuccess = false;
                stockSalesOrderItemResponse.Message = ex.Message;
            }
            return stockSalesOrderItemResponse;
        }


        [HttpPut]
        public async Task<SalesOrderFinalResponse> UpdateSalesOrderById([FromBody]SalesOrderFinalRequest salesOrderFinalRequest)
        {
            SalesOrderFinalResponse salesOrderFinalResponse = new SalesOrderFinalResponse();
            IEnumerable<SalesOrderFinalVM> salesOrderFinalVm;

            try
            {
                salesOrderFinalVm = new List<SalesOrderFinalVM>
                {
                    await _SalesServices.UpdateSalesOrderById(salesOrderFinalRequest.salesOrderFinalVM)
                };
                salesOrderFinalResponse.purchaseOrderFinalVM = salesOrderFinalVm;
                salesOrderFinalResponse.IsSuccess = true;
                _logger.LogInformation(salesOrderFinalRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                salesOrderFinalResponse.IsSuccess = false;
                salesOrderFinalResponse.Message = ex.Message;
            }
            return salesOrderFinalResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<SalesViewResponse> GetSalesViewDetails(int companyId)
        {
            SalesViewResponse salesViewResponse = new SalesViewResponse();
            IEnumerable<SalesViewVM> salesViewVM;
            try
            {
                salesViewVM = await _SalesServices.GetSalesViewDetails(companyId);
                salesViewResponse.salesViewVM = salesViewVM;
                salesViewResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                salesViewResponse.IsSuccess = false;
                salesViewResponse.Message = exc.Message;
            }
            return salesViewResponse;
        }

        [HttpGet("{salesOrderId},{companyId},{isDraft}")]
        public async Task<StockSalesOrderMasterResponse> GetSalesOrderDetailsById(string salesOrderId, int companyId, bool isDraft)
        {
            StockSalesOrderMasterResponse stockSalesOrderMasterResponse = new StockSalesOrderMasterResponse();
            IEnumerable<SalesOrderMasterVM> salesOrderMasterVM;
            try
            {
                salesOrderMasterVM = new List<SalesOrderMasterVM>{
                    await _SalesServices.GetSalesOrderDetailsById( salesOrderId, companyId,isDraft)
                };
                stockSalesOrderMasterResponse.salesOrderMasterVM = salesOrderMasterVM;
                stockSalesOrderMasterResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockSalesOrderMasterResponse.IsSuccess = false;
                stockSalesOrderMasterResponse.Message = exc.Message;
            }
            return stockSalesOrderMasterResponse;
        }

        [HttpGet("{businessPartnerId},{companyId}")]
        public async Task<StockSalesOrderMasterResponse> GetSalesOrderDetailsByBusinessPartnerId(string businessPartnerId, int companyId)
        {
            StockSalesOrderMasterResponse stockSalesOrderMasterResponse = new StockSalesOrderMasterResponse();
            IEnumerable<SalesOrderMasterVM> salesOrderMasterVM;
            try
            {
                salesOrderMasterVM = await _SalesServices.GetSalesOrderDetailsByBusinessPartnerId(businessPartnerId, companyId);
                stockSalesOrderMasterResponse.salesOrderMasterVMs = salesOrderMasterVM;
                stockSalesOrderMasterResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockSalesOrderMasterResponse.IsSuccess = false;
                stockSalesOrderMasterResponse.Message = exc.Message;
            }
            return stockSalesOrderMasterResponse;
        }


        [HttpPost]
        public async Task<StockSalesOrderMasterResponse> GetSalesOrderDetailsBySaleOrderIds([FromBody] SalesOrderFinalRequest salesOrderFinalRequest)
        {
            StockSalesOrderMasterResponse stockSalesOrderMasterResponse = new StockSalesOrderMasterResponse();
            IEnumerable<SalesOrderMasterVM> salesOrderMasterVM;
            try
            {
                salesOrderMasterVM = await _SalesServices.GetSalesOrderDetailsBySaleOrderIds(salesOrderFinalRequest.salesOrderFinalVM.SaleNos);
                stockSalesOrderMasterResponse.salesOrderMasterVMs = salesOrderMasterVM;
                stockSalesOrderMasterResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockSalesOrderMasterResponse.IsSuccess = false;
                stockSalesOrderMasterResponse.Message = exc.Message;
            }
            return stockSalesOrderMasterResponse;
        }


        [HttpPost]
        public async Task<StockSalesOrderItemResponse> GetSalesOrderItemDetailsBySaleOrderIds([FromBody] SalesOrderFinalRequest salesOrderFinalRequest)
        {
            StockSalesOrderItemResponse stockSalesOrderItemResponse = new StockSalesOrderItemResponse();
            IEnumerable<SalesOrderItemVM>  salesOrderItemVMs;
            try
            {
                salesOrderItemVMs = await _SalesServices.GetSalesOrderItemDetailsBySaleOrderIds(salesOrderFinalRequest.salesOrderFinalVM.SaleNos);
                stockSalesOrderItemResponse.salesOrderItemVM = salesOrderItemVMs;
                stockSalesOrderItemResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                stockSalesOrderItemResponse.IsSuccess = false;
                stockSalesOrderItemResponse.Message = exc.Message;
            }
            return stockSalesOrderItemResponse;
        }


    }
}