using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Requisition;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
   // [Authorize]
    public class RequisitionController : Controller
    {
        private IRequisitionServices _requisitionServices;
        private ILogger<RequisitionController> _logger;

        public RequisitionController(IRequisitionServices RequisitionServices, ILogger<RequisitionController> logger)
        {
            _requisitionServices = RequisitionServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<RequisitionResponse> AddRequisitionDetails([FromBody]RequisitionRequest requisitionRequest)
        {
            RequisitionResponse requisitionResponse = new RequisitionResponse();
            IEnumerable<RequisitionVM> requisitionVM;

            try
            {
                requisitionVM = new List<RequisitionVM>
                {
                    await _requisitionServices.AddRequisitionDetails(requisitionRequest.requisitionVM)
                };
                requisitionResponse.requisitionVM = requisitionVM;
                requisitionResponse.IsSuccess = true;
                _logger.LogInformation(requisitionRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                requisitionResponse.IsSuccess = false;
                requisitionResponse.Message = ex.Message;
            }
            return requisitionResponse;
        }
    }
}