using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Report;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ReportController : Controller
    {
        private IReportServices _ReportServices;
        private ILogger<ReportController> _logger;

        public ReportController(IReportServices ReportServices,   ILogger<ReportController> logger)
        {
            _ReportServices = ReportServices;
            _logger = logger;
            //_mapper = mapper;
        }

        [HttpGet("{reportId},{companyId}")]
        public async Task<ReportResponse> GetReportDetailsByReportID(int reportId ,int companyId)
        {

            ReportResponse reportResponse = new ReportResponse();
            IEnumerable<ReportVM> reportVM;
            try
            {
                reportVM = new List<ReportVM>
                {
                    await _ReportServices.GetReportDetailsByReportID(reportId,companyId)
                };
                reportResponse.reportVM = reportVM;
                reportResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message );
                reportResponse.IsSuccess = false;
                reportResponse.Message = exc.Message;
            }
            return reportResponse;
        }
    }
}