using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.PurchaseOrderReport;
using OnimtaWebInventory.DTO.Report;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PurchaseOrderReportController : Controller
    {
        private IPurchaseOrderReportServices _purchaseOrderReportServices;
        private ILogger<PurchaseOrderReportController> _logger;

        public PurchaseOrderReportController(IPurchaseOrderReportServices PurchaseOrderReportServices, ILogger<PurchaseOrderReportController> logger) 
        {
            _purchaseOrderReportServices = PurchaseOrderReportServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<PurchaseOrderReportResponse> GetAllPurchaseOrderReportDetails()
        {
            PurchaseOrderReportResponse purchaseOrderReportResponse = new PurchaseOrderReportResponse();
            IEnumerable<PurchaseOrderReportVM> purchaseOrderReportVm;

            try
            {
                purchaseOrderReportVm = await _purchaseOrderReportServices.GetAllPurchaseOrderReportDetails();
                purchaseOrderReportResponse.purchaseOrderReportVm = purchaseOrderReportVm;
                purchaseOrderReportResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderReportResponse.IsSuccess = false;
                purchaseOrderReportResponse.Message = ex.Message;
            }
            return purchaseOrderReportResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<PurchaseOrderReportResponse> GetPurchaseOrderReportDetailsGroupByApprovalStatus(int companyId)
        {
            PurchaseOrderReportResponse purchaseOrderReportResponse = new PurchaseOrderReportResponse();
            IEnumerable<PurchaseOrderReportVM> purchaseOrderReportVM;
            try
            {
                purchaseOrderReportVM =await _purchaseOrderReportServices.GetPurchaseOrderReportDetailsGroupByApprovalStatus(companyId);
                purchaseOrderReportResponse.purchaseOrderReportVm = purchaseOrderReportVM;
                purchaseOrderReportResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderReportResponse.IsSuccess = false;
                purchaseOrderReportResponse.Message = ex.Message;
            }
            return purchaseOrderReportResponse;
        }

        [HttpGet]
        public async Task<PurchaseOrderReportResponse> GetTopReportDetailsOrderByBranchId(int isSalesOrder)
        {
            PurchaseOrderReportResponse purchaseOrderReportResponse = new PurchaseOrderReportResponse();
            IEnumerable<PurchaseOrderReportVM> purchaseOrderReportVM;
            try
            {
                purchaseOrderReportVM = await _purchaseOrderReportServices.GetTopReportDetailsOrderByBranchId(isSalesOrder);
                purchaseOrderReportResponse.purchaseOrderReportVm = purchaseOrderReportVM;
                purchaseOrderReportResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderReportResponse.IsSuccess = false;
                purchaseOrderReportResponse.Message = ex.Message;
            }
            return purchaseOrderReportResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<ReportResponse> GetNetTotalOfSalesNPurchase(int companyId)
        {
            ReportResponse ReportResponse = new ReportResponse();
            IEnumerable<ReportVM> ReportVm;
            try
            {
                ReportVm = await _purchaseOrderReportServices.GetNetTotalOfSalesNPurchase(companyId);
           

                ReportResponse.reportVM = ReportVm;
                ReportResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ReportResponse.IsSuccess = false;
                ReportResponse.Message = ex.Message;
            }
            return ReportResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<ReportResponse> GetTopSalesNPurchaseBranches(int companyId)
        {
            ReportResponse ReportResponse = new ReportResponse();
            IEnumerable<ReportVM> ReportVm;
            try
            {
                ReportVm = await _purchaseOrderReportServices.GetTopSalesNPurchaseBranches(companyId);


                ReportResponse.reportVM = ReportVm;
                ReportResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ReportResponse.IsSuccess = false;
                ReportResponse.Message = ex.Message;
            }
            return ReportResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<ReportResponse> GetTopSaleProducts(int companyId)
        {
            ReportResponse ReportResponse = new ReportResponse();
            IEnumerable<ReportVM> ReportVm;
            try
            {
                ReportVm = await _purchaseOrderReportServices.GetTopSaleProducts(companyId);


                ReportResponse.reportVM = ReportVm;
                ReportResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ReportResponse.IsSuccess = false;
                ReportResponse.Message = ex.Message;
            }
            return ReportResponse;
        }
    }
}