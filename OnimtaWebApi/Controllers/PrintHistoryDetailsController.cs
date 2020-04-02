using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.PrintHistoryDetails;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PrintHistoryDetailsController : Controller
    {
        private IPrintHistoryDetailsServices _printHistoryDetailsServices;
        private ILogger<PrintHistoryDetailsController> _logger;

        public PrintHistoryDetailsController(IPrintHistoryDetailsServices PrintHistoryDetailsServices, ILogger<PrintHistoryDetailsController> logger)
        {
            _printHistoryDetailsServices = PrintHistoryDetailsServices;
            _logger = logger;
        }

        [HttpGet("{pageId}")]
        public async Task<PrintHistoryDetailsResponse> GetAllPrintHistoryDetails(int pageId)
        {
            PrintHistoryDetailsResponse printHistoryDetailsResponse = new PrintHistoryDetailsResponse();
            IEnumerable<PrintHistoryDetailsVM> printHistoryDetailsVM;

            try
            {
                printHistoryDetailsVM = await _printHistoryDetailsServices.GetAllPrintHistoryDetails(pageId);
                printHistoryDetailsResponse.printHistoryDetailsVM = printHistoryDetailsVM;
                printHistoryDetailsResponse.IsSuccess = true;
              


            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                printHistoryDetailsResponse.IsSuccess = false;
                printHistoryDetailsResponse.Message = ex.Message;
            }

            return printHistoryDetailsResponse;
        }
    }
}