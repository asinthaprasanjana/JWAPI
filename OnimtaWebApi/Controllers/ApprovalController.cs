using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.ApplicationUser;
using OnimtaWebInventory.DTO.Approval;
using OnimtaWebInventory.DTO.ApprovalResponse;
using OnimtaWebInventory.DTO.FunctionApprovalTypeResponse;
using OnimtaWebInventory.DTO.OwnApprovalDetail;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
   // [Authorize]
    [Route("api/[controller]/[action]")]
    public class ApprovalController : Controller
    {
        private IApprovalServices _ApprovalServices;
        private ILogger<ApprovalController> _logger;

        public ApprovalController(IApprovalServices ApprovalServices, ILogger<ApprovalController> logger)
        {
            _ApprovalServices = ApprovalServices;
            _logger = logger;
        }


        [HttpGet("{id},{companyId}")]
        public async Task<ApprovalResponse> GetApprovalDetailsById(int id, int companyId, int pageId)
        {
            ApprovalResponse approvalResponse = new ApprovalResponse();
            IEnumerable<ApprovalVM> approvalVM;
            try
            {
                approvalVM = new List<ApprovalVM>{
                    await _ApprovalServices.GetApprovalDetailsById(id,companyId,pageId)
                };
                approvalResponse.approvalVM = approvalVM;
                approvalResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                approvalResponse.IsSuccess = false;
                approvalResponse.Message = exc.Message;
            }
            return approvalResponse;
        }

       
        [HttpGet("{UserID},{companyId},{pageId}")]
        public async Task<ApprovalEventResponse> GetOwnApprovalDetailsByUserID(int userID, int companyId, int pageId)
        {
            ApprovalEventResponse approvalEventResponse  = new ApprovalEventResponse();
            IEnumerable<ApprovalEventVM>  approvalEventVM;
            try
            {
                approvalEventVM = await _ApprovalServices.GetOwnApprovalDetailByUserID(userID, companyId,pageId);

                approvalEventResponse.approvalEventVM = approvalEventVM;
                approvalEventResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                approvalEventResponse.IsSuccess = false;
                approvalEventResponse.Message = exc.Message;
            }
            return approvalEventResponse;
        }

        [HttpGet("{functionId},{companyId}")]
        public async Task<FunctionApprovalTypeResponse> GetFunctionApprovalDetailsByFunctionId(int functionId, int companyId)
        {
            FunctionApprovalTypeResponse functionApprovalTypeResponse = new FunctionApprovalTypeResponse();
            IEnumerable<FunctionApprovalTypeVm> functionApprovalTypeVm;
            try
            {
                functionApprovalTypeVm = new List<FunctionApprovalTypeVm>{
                 //   await _ApprovalServices.GetFunctionApprovalDetailsByFunctionId(functionId,companyId)
                };
                functionApprovalTypeResponse.functionApprovalTypeVm = functionApprovalTypeVm;
                functionApprovalTypeResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                functionApprovalTypeResponse.IsSuccess = false;
                functionApprovalTypeResponse.Message = exc.Message;
            }
            return functionApprovalTypeResponse;
        }

        [HttpGet]
        public async Task<FunctionApprovalTypeResponse> GetAllFunctionApprovalDetails()
        {
            FunctionApprovalTypeResponse functionApprovalTypeResponse = new FunctionApprovalTypeResponse();
            IEnumerable<FunctionApprovalTypeVm> functionApprovalTypeVm;
            try
            {
                functionApprovalTypeVm = await _ApprovalServices.GetAllFunctionApprovalDetails();

                functionApprovalTypeResponse.functionApprovalTypeVm = functionApprovalTypeVm;
                functionApprovalTypeResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                functionApprovalTypeResponse.IsSuccess = false;
                functionApprovalTypeResponse.Message = exc.Message;
            }
            return functionApprovalTypeResponse;
        }

       

        [HttpPost]
        public async Task<ApprovalResponse> AddNewApprovalDetailsByApprovalId([FromBody]ApprovalRequest approvalRequest)
        {
            ApprovalResponse approvalResponse = new ApprovalResponse();
            IEnumerable<ApprovalVM> approvalVm;
            try
            {
                approvalVm = new List<ApprovalVM>{
                    await _ApprovalServices.AddNewApproveByApprovalId(approvalRequest.approvalVM)};
                approvalResponse.approvalVM = approvalVm;
                approvalResponse.IsSuccess = true;
                _logger.LogInformation(approvalRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                approvalResponse.IsSuccess = false;
                approvalResponse.Message = exc.Message;
            }
            return approvalResponse;
        }

        [HttpPut]
        public async Task<ApprovalResponse> UpdateApprovalDetailsByFunctionId([FromBody]ChangeApprovalVM changeApprovalVm)
        {
            ApprovalResponse approvalResponse = new ApprovalResponse();
            try
            {

                await _ApprovalServices.UpdateApprovalDetailsByFunctionId(changeApprovalVm.ApprovalTypeId, changeApprovalVm.CompanyId, changeApprovalVm.isActive);
                approvalResponse.IsSuccess = true;
             //   _logger.LogInformation(approvalRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                approvalResponse.IsSuccess = false;
                approvalResponse.Message = exc.Message;
            }
            return approvalResponse;
        }


        [HttpGet("{approvalId}")]
        public async Task<ApplicationUserResponse> GetApprovalTypeOwnDetailsByAprovalId(int approvalId)
        {
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            try
            {
                applicationUserResponse.applicationUserVM = await _ApprovalServices.GetApplicationUserDetailsByUserId(approvalId);
                applicationUserResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = exc.Message;
            }
            return applicationUserResponse;
        }

        [HttpPut]
        public async Task<ApplicationUserResponse> UpdateApprovalTypeOwnDetailsByAprovalId([FromBody]ApprovalTypeOwnUpdateVM approvalTypeOwnUpdateVM)
        {
            int approvalId = approvalTypeOwnUpdateVM.ApprovalTypeId;
            string approvalOfficerIdList = approvalTypeOwnUpdateVM.approvalOfficerIdList;
            int companyId = approvalTypeOwnUpdateVM.CompanyId;
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            try
            {
                await _ApprovalServices.UpdateApprovalOfficerDetailsByApprovalTypeId(approvalId, approvalOfficerIdList, companyId);
                applicationUserResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = exc.Message;
            }
            return applicationUserResponse;
        }

      
        [HttpGet("{userId},{pageId}")]
        public async Task<ApprovalEventResponse> GetAllApprovalEventsByUserId(int userId, int pageId)
        {
            ApprovalEventResponse newApprovalEventResponse = new ApprovalEventResponse();
            try
            {
                newApprovalEventResponse.approvalEventVM = await _ApprovalServices.GetAllApprovalEventsByUserId(userId,pageId);
                newApprovalEventResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                newApprovalEventResponse.IsSuccess = false;
                newApprovalEventResponse.Message = exc.Message;
            }
            return newApprovalEventResponse;
        }

        [HttpPost]
        public async Task<ApprovalEventResponse> AddNewApprovalEventDetails([FromBody]ApprovalEventRequest approvalEventRequest)
        {
            ApprovalEventResponse approvalEventResponse = new ApprovalEventResponse();
            IEnumerable<ApprovalEventVM> approvalEventVm;
            try
            {
                approvalEventVm = new List<ApprovalEventVM>
                {
                    await _ApprovalServices.AddNewApprovalEventDetails(approvalEventRequest.approvalEventVM)
                };
                approvalEventResponse.approvalEventVM = approvalEventVm;
                approvalEventResponse.IsSuccess = true;
                _logger.LogInformation(approvalEventRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                approvalEventResponse.IsSuccess = false;
                approvalEventResponse.Message = ex.Message;
            }
            return approvalEventResponse;
        }
        [HttpPut]
        public async Task<ApprovalResponseResponse> UpdateApprovalRejectOrAcceptByTaskId([FromBody]ApprovalResponseRequest approvalResponseRequest)
        {
            ApprovalResponseResponse approvalResponseResponse = new ApprovalResponseResponse();
            IEnumerable<ApprovalResponseVM> approvalResponseVM;

           
            try
            {
                approvalResponseVM = new List<ApprovalResponseVM>
                {
                    await _ApprovalServices.UpdateApprovalRejectOrAcceptByTaskId(approvalResponseRequest.approvalResponseVM)
                };
                approvalResponseResponse.approvalResponseVM = approvalResponseVM;
                approvalResponseResponse.IsSuccess = true;
                _logger.LogInformation(approvalResponseRequest.ToString());


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                approvalResponseResponse.IsSuccess = false;
                approvalResponseResponse.Message = ex.Message;
            }
            return approvalResponseResponse;
        }
    }
}