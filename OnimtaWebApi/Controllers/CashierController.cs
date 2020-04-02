using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.AdvancePayment;
using OnimtaWebInventory.DTO.BillPayment;
using OnimtaWebInventory.DTO.ChatBot;
using OnimtaWebInventory.DTO.PurchaseOrderBill;
using OnimtaWebInventory.DTO.PurchaseOrderBilledEvent;
using OnimtaWebInventory.DTO.PurchaseOrderBilledEvents;
using OnimtaWebInventory.DTO.PurchaseOrderBilledEventsFinal;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.Services;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class CashierController : Controller
    {
        private ICashierServices _cashierServices;
        private ILogger<CashierController> _logger;

        public CashierController(ICashierServices CashierServices, ILogger<CashierController> logger)
        {
            _cashierServices = CashierServices;
            _logger = logger;
        }

        [HttpGet("{BusinessPartnerId}")]
        public async Task<AdvancePaymentResponse> getTotalAdvacePaymentsByBusinessPartnerId(string BusinessPartnerId)
        {
            AdvancePaymentResponse advancePaymentResponse = new AdvancePaymentResponse();
            try
            {
                advancePaymentResponse.advancePaymentVm = await _cashierServices.getTotalAdvacePaymentsByBusinessPartnerId(BusinessPartnerId);
                advancePaymentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                advancePaymentResponse.IsSuccess = false;
                advancePaymentResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return advancePaymentResponse;

        }

        [HttpGet]
        public async Task<PurchaseOrderBilledEventsResponse> getAllBillPaymentDetails()
        {
            PurchaseOrderBilledEventsResponse purchaseOrderBilledEventsResponse = new PurchaseOrderBilledEventsResponse();
            try
            {

                purchaseOrderBilledEventsResponse.purchaseOrderBilledEventsVM = await _cashierServices.getAllBillPaymentDetails();
                purchaseOrderBilledEventsResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                purchaseOrderBilledEventsResponse.IsSuccess = false;
                purchaseOrderBilledEventsResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return purchaseOrderBilledEventsResponse;

        }

        [HttpGet("{billId}")]
        public async Task<BillPaymentResponse> getBillPaymentDetailsById(int billId)
        {
            BillPaymentResponse billPaymentResponse = new BillPaymentResponse();
            try
            {

                billPaymentResponse.billPaymentVM = await _cashierServices.getBillPaymentDetailsById(billId);
                billPaymentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                billPaymentResponse.IsSuccess = false;
                billPaymentResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return billPaymentResponse;

        }

        [HttpPost]
        public async Task<PurchaseOrderBillResponse> getBillPaymentEventsByBusinessPartnerIdAndBillID([FromBody] AllPurchaseOrderBilledEventsRequest purchaseOrderBilledEventsRequest)
        {
            PurchaseOrderBillResponse purchaseOrderBillResponse = new PurchaseOrderBillResponse();
            try
            {
                
                purchaseOrderBillResponse.purchaseOrderBilledEventsVM = await _cashierServices.getBillPaymentEventsByBusinessPartnerIdAndBillID(purchaseOrderBilledEventsRequest.BillIds);
                purchaseOrderBillResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                purchaseOrderBillResponse.IsSuccess = false;
                purchaseOrderBillResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return purchaseOrderBillResponse;

        }

        [HttpPost]
        public async Task<PurchaseOrderBilledEventsFinalResponse> AddNewBillPayment([FromBody] PurchaseOrderBilledEventsFinalRequest purchaseOrderBilledEventsFinalRequest)
        {
            PurchaseOrderBilledEventsFinalResponse purchaseOrderBilledEventsFinalResponse = new PurchaseOrderBilledEventsFinalResponse();
            try
            {

                purchaseOrderBilledEventsFinalResponse.purchaseOrderBilledEventsVM = await _cashierServices.addNewBillPayment(purchaseOrderBilledEventsFinalRequest.purchaseOrderBilledEventsFinalVM);
                purchaseOrderBilledEventsFinalResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                purchaseOrderBilledEventsFinalResponse.IsSuccess = false;
                purchaseOrderBilledEventsFinalResponse.Message = ex.Message;
                _logger.LogError(ex.Message);
            }
            return purchaseOrderBilledEventsFinalResponse;

        }
    }
}