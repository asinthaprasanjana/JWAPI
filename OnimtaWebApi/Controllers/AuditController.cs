using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Audit;
using OnimtaWebInventory.DTO.AuditTypeDetails;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuditController : Controller
    {
        private IAuditServices _auditServices;
        private ILogger<AuditController> _logger;

        public AuditController(IAuditServices AuditServices, ILogger<AuditController> logger)
        {
            _logger = logger;
            _auditServices = AuditServices;
        }

        [HttpGet("{pageId}")]
        public async Task<AuditResponse> GetAllAuditDetails(int pageId)
        {
            AuditResponse auditResponse = new AuditResponse();
            IEnumerable<AuditVM> auditVM;

            try
            {
                auditVM = await _auditServices.GetAllAuditDetails(pageId);
                auditResponse.auditVM = auditVM;
                auditResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                auditResponse.IsSuccess = false;
                auditResponse.Message = ex.Message;
            }

            return auditResponse;
        }

        [HttpGet("{referenceNo1}")]
        public async Task<AuditResponse> GetAuditDetailsById( string referenceNo1)
        {
            AuditResponse auditResponse = new AuditResponse();
            IEnumerable<AuditVM> auditVM;

            try
            {
                auditVM = await _auditServices.GetAuditDetailsById(referenceNo1);
                auditResponse.auditVM = auditVM;
                auditResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                auditResponse.IsSuccess = false;
                auditResponse.Message = ex.Message;
            }

            return auditResponse;
        }

        [HttpGet]
        public async Task<AuditTypeDetailsResponse> GetAllAuditTypeDetails()
        {
            AuditTypeDetailsResponse auditTypeDetailsResponse = new AuditTypeDetailsResponse();
            IEnumerable<AuditTypeDetailsVM> auditTypeDetailsVM;

            try
            {
                auditTypeDetailsVM = await _auditServices.GetAllAuditTypeDetails();
                auditTypeDetailsResponse.auditTypeDetailsVM = auditTypeDetailsVM;
                auditTypeDetailsResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                auditTypeDetailsResponse.IsSuccess = false;
                auditTypeDetailsResponse.Message = ex.Message;
            }

            return auditTypeDetailsResponse;
        }

        [HttpGet("{userId},{auditTypeId},{auditName}")]
        public async Task<AuditResponse> SearchAuditTypeDetails(int userId, int auditTypeId, string auditName)
        {
            AuditResponse auditResponse = new AuditResponse();
            IEnumerable<AuditVM> auditVM;

            try
            {
                auditVM = await _auditServices.SearchAuditTypeDetails(userId, auditTypeId, auditName);
                auditResponse.auditVM = auditVM;
                auditResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                auditResponse.IsSuccess = false;
                auditResponse.Message = ex.Message;
            }

            return auditResponse;
        }
    }
}