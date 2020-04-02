using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Payment;
using OnimtaWebInventory.DTO.PurchaseOrderBill;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PaymentController : Controller
    {
        private IPaymentServices _paymentServices;
        private ILogger<PaymentController> _logger;

        public PaymentController(IPaymentServices PaymentServices, ILogger<PaymentController> logger)
        {
            _paymentServices = PaymentServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<PaymentResponse> AddNewPaymentDetails([FromBody]PaymentRequest paymentRequest)
        {
            PaymentResponse paymentResponse = new PaymentResponse();
            IEnumerable<PaymentVM> paymentVM;
            try
            {
                paymentVM = new List<PaymentVM>
                {
                    await  _paymentServices.AddNewPaymentDetails(paymentRequest.paymentVM)
                };
                paymentResponse.paymentVM = paymentVM;
                paymentResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentResponse.IsSuccess = false;
                paymentResponse.Message = ex.Message;
            }
            return paymentResponse;
        }

        [HttpGet("{id}")]
        public async Task<PaymentResponse> GetPaymentDetailsByPaymentId(int id)
        {
            PaymentResponse paymentResponse = new PaymentResponse();
            IEnumerable<PaymentVM> paymentVM;
            try
            {
                paymentVM = new List<PaymentVM>
                {
                    await _paymentServices.GetPaymentDetailsByPaymentId(id)
                };
                paymentResponse.paymentVM = paymentVM;
                paymentResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentResponse.IsSuccess = false;
                paymentResponse.Message = ex.Message;
            }
            return paymentResponse;
        }

        [HttpGet("{pageId},{businessPartnerTypeId}")]
        public async Task<PaymentResponse> GetPymentDetailsByCompanyId(int pageId , int businessPartnerTypeId)
        {
            PaymentResponse paymentResponse = new PaymentResponse();
            IEnumerable<PaymentVM> paymentVM;
            try
            {
                paymentVM = await _paymentServices.GetPymentDetailsByCompanyId(pageId, businessPartnerTypeId);
                paymentResponse.paymentVM = paymentVM;
                paymentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentResponse.IsSuccess = false;
                paymentResponse.Message = ex.Message;
            }
            return paymentResponse;
        }


        [HttpGet("{pageId},{businessPartnerTypeId},{businessPartnerId}")]
        public async Task<PurchaseOrderBillResponse> GetBusinessPartnerPayableDetails(int pageId, int businessPartnerTypeId , int businessPartnerId)
        {
            PurchaseOrderBillResponse paymentResponse = new PurchaseOrderBillResponse();
            IEnumerable<PurchaseOrderBilledEventsVM> paymentVM;
            try
            {
                paymentVM = await _paymentServices.GetBusinessPartnerPayableDetails(pageId, businessPartnerTypeId,businessPartnerId);
                paymentResponse.purchaseOrderBilledEventsVM = paymentVM;
                paymentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentResponse.IsSuccess = false;
                paymentResponse.Message = ex.Message;
            }
            return paymentResponse;
        }

        [HttpGet("{pageId},{businessPartnerId},{businessPartnerTypeId}")]
        public async Task<PaymentResponse>GetPaymentHistoryDetails(int pageId,  int businessPartnerId,int businessPartnerTypeId)
        {
            PaymentResponse paymentResponse = new PaymentResponse();
            IEnumerable<PaymentVM> paymentVM;

            try
            {
                paymentVM = await _paymentServices.GetPaymentHistoryDetails(pageId,  businessPartnerId,businessPartnerTypeId);

                paymentResponse.paymentVM = paymentVM;
                paymentResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentResponse.IsSuccess = false;
                paymentResponse.Message = ex.Message;
            }

            return paymentResponse;
        }

        [HttpGet("{pageId},{documentNo}")]
        public async Task<PaymentResponse> GetPaymentHistoryItemsDetailsByDocumentNo(int pageId, string documentNo)
        {
            PaymentResponse paymentResponse = new PaymentResponse();
            IEnumerable<PaymentVM> paymentVM;

            try
            {
                paymentVM = await _paymentServices.GetPaymentHistoryItemsDetailsByDocumentNo(pageId, documentNo);


                paymentResponse.paymentVM = paymentVM;
                paymentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                paymentResponse.IsSuccess = false;
                paymentResponse.Message = ex.Message;
            }

            return paymentResponse;
        }
    }
}