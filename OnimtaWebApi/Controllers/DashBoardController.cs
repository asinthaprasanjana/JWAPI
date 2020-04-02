using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.DashBoard;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DashBoardController : Controller
    {
        public ILogger<DashBoardController> _logger;
        public IDashBoardServices _dashBoardServices;

        public DashBoardController(ILogger<DashBoardController> logger, IDashBoardServices DashBoardServices)
        {
            _dashBoardServices = DashBoardServices;
            _logger = logger;
        }

        [HttpGet("{TypeId}")]
        public async Task<DashBoardResponse> GetAllDashBoardDetails(int TypeId)
        {
            DashBoardResponse dashBoardResponse = new DashBoardResponse();
            IEnumerable<DashBoardVM> dashBoardVM;

            try
            {
                dashBoardVM = await _dashBoardServices.GetAllDashBoardDetails(TypeId);
                dashBoardResponse.dashBoardVM = dashBoardVM;
                dashBoardResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dashBoardResponse.IsSuccess = false;
                dashBoardResponse.Message = ex.Message;
            }
            return dashBoardResponse;
        }

        [HttpGet("{reportTypeId},{branchId},{fromDate},{toDate}")]
        public async Task<DashBoardResponse> GetReportDetails(int reportTypeId, int branchId, DateTime fromDate, DateTime toDate)
        {
            DashBoardResponse dashBoardResponse = new DashBoardResponse();
            IEnumerable<DashBoardVM> dashBoardVM;

            try
            {
                dashBoardVM = new List<DashBoardVM>{
                    await _dashBoardServices.GetReportDetails(reportTypeId, branchId, fromDate, toDate)
                };
                dashBoardResponse.dashBoardVM = dashBoardVM;
                dashBoardResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dashBoardResponse.IsSuccess = false;
                dashBoardResponse.Message = ex.Message;
            }

            return dashBoardResponse;
        }
    }
}


    