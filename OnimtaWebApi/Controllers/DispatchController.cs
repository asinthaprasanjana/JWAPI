using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Dispatch;
using OnimtaWebInventory.DTO.PurchaseOrderItem;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DispatchController : Controller
    {
        private IDispatchServices _dispatchServices;
        private ILogger<DispatchController> _logger;

        public DispatchController(IDispatchServices DispatchServices,ILogger<DispatchController> logger)
        {
            _dispatchServices = DispatchServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<DispatchResponse> AddNewDispatchDetails([FromBody]DispatchRequest dispatchRequest)
       {
            DispatchResponse dispatchResponse = new DispatchResponse();
            IEnumerable<DispatchVM> dispatchVM;

            try
            {
                dispatchVM = new List<DispatchVM>{
                    await _dispatchServices.AddNewDispatchDetails(dispatchRequest.dispatchVM)
                  };
                dispatchResponse.dispatchVM = dispatchVM;
                dispatchResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dispatchResponse.IsSuccess = false;
                dispatchResponse.Message = ex.Message;
            }
            return dispatchResponse;

         }

        [HttpGet("{id}")]
        public async Task<DispatchResponse> GetDispatchDetailsById(int id)
        {
            DispatchResponse dispatchResponse = new DispatchResponse();
            IEnumerable<DispatchVM> dispatchVM;

            try
            {
                dispatchVM = new List<DispatchVM>
                {
                    await _dispatchServices.GetDispatchDetailsById(id)
                };
                dispatchResponse.dispatchVM = dispatchVM;
                dispatchResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dispatchResponse.IsSuccess = false;
                dispatchResponse.Message = ex.Message;
            }

            return dispatchResponse;
        }

        [HttpGet("{dispatchTypeId}")]
        public async Task<DispatchResponse> GetAllDispatchDetails(int dispatchTypeId)
        {
            DispatchResponse dispatchResponse = new DispatchResponse();
            IEnumerable<DispatchVM> dispatchVM;

            try
            {
                dispatchVM = await _dispatchServices.GetAllDispatchDetails(dispatchTypeId);
                dispatchResponse.dispatchVM = dispatchVM;
                dispatchResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dispatchResponse.IsSuccess = false;
                dispatchResponse.Message = ex.Message;
            }

            return dispatchResponse;
        }

        [HttpGet("{DocumentNumber}")]
        public async Task<PurchaseOrderItemResponse> GetGatePassItemsDetails(string DocumentNumber)
        {
            PurchaseOrderItemResponse purchaseOrderItemResponse = new PurchaseOrderItemResponse();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;

            try
            {
                purchaseOrderItemVM = await _dispatchServices.GetGatePassItemsDetails(DocumentNumber);
                purchaseOrderItemResponse.purchaseOrderItemVM = purchaseOrderItemVM;
                purchaseOrderItemResponse.IsSuccess = true;
                
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                purchaseOrderItemResponse.IsSuccess = false;
                purchaseOrderItemResponse.Message = ex.Message;
            }

            return purchaseOrderItemResponse;
        }
    }
}