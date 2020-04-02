using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.PurchaseOrderInteligence;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class PurchaseOrderInteligenceController : Controller
    {
        private IPurchaseOrderInteligenceServices _purchaseOrderInteligenceServices;
        private ILogger<PurchaseOrderInteligenceController> _logger;

        public PurchaseOrderInteligenceController(IPurchaseOrderInteligenceServices PurchaseOrderInteligenceServices,ILogger<PurchaseOrderInteligenceController>logger)
        {
            _logger = logger;
            _purchaseOrderInteligenceServices = PurchaseOrderInteligenceServices;
        }

        [HttpGet]
        public async Task<PurchaseAndSalesSummaryResponse> GetPurchaseorderAndSalesOrderSummaryDeails(int companyId)
        {
            PurchaseAndSalesSummaryResponse purchaseAndSalesSummaryResponse = new PurchaseAndSalesSummaryResponse();
            IEnumerable<PurchaseAndSalesSummaryVM> purchaseAndSalesSummaryVM;

            try
            {
                purchaseAndSalesSummaryVM = new List<PurchaseAndSalesSummaryVM>
                {
                    await  _purchaseOrderInteligenceServices.GetPurchaseorderAndSalesOrderSummaryDeails(companyId)

                };
                purchaseAndSalesSummaryResponse.purchaseAndSalesSummaryVM = purchaseAndSalesSummaryVM;
                purchaseAndSalesSummaryResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseAndSalesSummaryResponse.IsSuccess = false;
                purchaseAndSalesSummaryResponse.Message = ex.Message;
            }
            return purchaseAndSalesSummaryResponse;
        }
    }
}