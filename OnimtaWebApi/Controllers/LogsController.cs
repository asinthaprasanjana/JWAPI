using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Logs;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LogsController : Controller
    {
        private ILogger<LogsController> _logger;
        private ILogsServices _logsServices;

        public LogsController(ILogsServices LogsServices, ILogger<LogsController> logger)
        {
            _logger = logger;
            _logsServices = LogsServices;
        }


        [HttpGet("{pageId}")]
        public async Task<LogsResponse> GetAllLogDetailsByPageId(int pageId)
        {
            LogsResponse logsResponse = new LogsResponse();
            IEnumerable<LogsVM> logsVM;

            try
            {
                logsVM = await _logsServices.GetAllLogDetailsByPageId(pageId);
                logsResponse.logsVM = logsVM;
                logsResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                logsResponse.IsSuccess = false;
                logsResponse.Message = ex.Message;
            }

            return logsResponse;
        }

        [HttpGet("{level}")]
        public async Task<LogsResponse> GetLogsDetailsByLevel(string level)
        {
            LogsResponse logsResponse = new LogsResponse();
            IEnumerable<LogsVM> logsVM;

            try
            {
                logsVM = await _logsServices.GetLogsDetailsByLevel(level);
                logsResponse.logsVM = logsVM;
                logsResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                logsResponse.IsSuccess = false;
                logsResponse.Message = ex.Message;
            }

            return logsResponse;
        }
    }
}