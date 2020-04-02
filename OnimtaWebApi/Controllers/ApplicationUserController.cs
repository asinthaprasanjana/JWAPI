using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.ApplicationPage;
using OnimtaWebInventory.DTO.ApplicationPageTree;
using OnimtaWebInventory.DTO.ApplicationUser;
using OnimtaWebInventory.DTO.ApplicationUserBranch;
using OnimtaWebInventory.DTO.UserBranch;
using OnimtaWebInventory.DTO.UserComment;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApplicationUserController : Controller
    {
        private IApplicationUserServices _ApplicationUserServices;
        private ILogger<ApplicationUserController> _logger;

        public ApplicationUserController(IApplicationUserServices ApplicationUserServices, ILogger<ApplicationUserController> logger)
        {

            _ApplicationUserServices = ApplicationUserServices;
            _logger = logger;

        }

        [HttpGet("{userName},{password}")]
        public async Task<ApplicationUserResponse> GetApplicationUserDetails(string userName, string password)
        {
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            IEnumerable<ApplicationUserVM> applicationUserVM;
            try
            {
                applicationUserVM = new List<ApplicationUserVM> {

                    await _ApplicationUserServices.GetApplicationUserDetails(userName,password)
                };
                applicationUserResponse.applicationUserVM = applicationUserVM;
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

        [HttpGet("{companyId}")]
        public async Task<ApplicationPageTreeResponse> GetApplicationPageDetails(int companyId)
        {
            ApplicationPageTreeResponse applicationPageTreeResponse = new ApplicationPageTreeResponse();
            IEnumerable<ApplicationPageTreeVm> applicationPageTreeVm;

            try
            {
                applicationPageTreeVm = await _ApplicationUserServices.GetApplicationPageDetails(companyId);
                applicationPageTreeResponse.ApplicationPageTreeVm = applicationPageTreeVm;
                applicationPageTreeResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                applicationPageTreeResponse.IsSuccess = false;
                applicationPageTreeResponse.Message = exc.Message;
            }
            return applicationPageTreeResponse;
        }

        [HttpGet("{userId},{companyId}")]
        public async Task <ApplicationPageResponse>GetApplicationPagesByUserId(int userId, int companyId)
        {
            ApplicationPageResponse applicationPage = new ApplicationPageResponse();
            IEnumerable<ApplicationPageVM> applicationPageVM;
            try
            {
                applicationPageVM = await _ApplicationUserServices.GetApplicationPagesByUserId(userId,companyId);
                applicationPage.applicationPageVM = applicationPageVM;
                applicationPage.IsSuccess = true;
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationPage.IsSuccess = false;
                applicationPage.Message = ex.Message;
            }
            return  applicationPage;

        }

        [HttpPost]
        public async Task<ApplicationPageResponse>AddNewApplicationPages([FromBody] ApplicationPageRequest applicationPageRequest)
        {
            ApplicationPageResponse applicationPageResponse = new ApplicationPageResponse();
            IEnumerable<ApplicationPageVM> applicationPageVm;
            try
            {
                applicationPageVm = new List<ApplicationPageVM>
                {
                     await _ApplicationUserServices.AddNewApplicationPages(applicationPageRequest.applicationPageVM)
                };
                applicationPageResponse.applicationPageVM = applicationPageVm;
                applicationPageResponse.IsSuccess = true;
                _logger.LogInformation(applicationPageRequest.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationPageResponse.IsSuccess = false;
                applicationPageResponse.Message = ex.Message;
            }
            return applicationPageResponse;
        }
        [HttpPost]
        public async Task<ApplicationUserResponse> AddNewApplicationUserDetails([FromBody]ApplicationUserRequest applicationUserRequest)
        {
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            IEnumerable<ApplicationUserVM> applicationUserVM;
            try
            {
                applicationUserVM = new List<ApplicationUserVM>
                {
                    await _ApplicationUserServices.AddNewApplicationUserDetails(applicationUserRequest.applicationUserVM)
                };
                applicationUserResponse.applicationUserVM = applicationUserVM;
                applicationUserResponse.IsSuccess = true;
                _logger.LogInformation(applicationUserRequest.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = ex.Message;
            }
            return applicationUserResponse;
        }
        [HttpPut]
        public async Task<ApplicationUserResponse> UpdateApplicationUserDetails([FromBody]ApplicationUserRequest applicationUserRequest)
        {
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            IEnumerable<ApplicationUserVM> applicationUserVm;

            try
            {
                applicationUserVm = new List<ApplicationUserVM>
                {
                    await _ApplicationUserServices.UpdateApplicationUserDetails(applicationUserRequest.applicationUserVM)
                };
                applicationUserResponse.applicationUserVM = applicationUserVm;
                applicationUserResponse.IsSuccess = true;
                _logger.LogInformation(applicationUserRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = ex.Message;
            }
            return applicationUserResponse;
        }
       
        [HttpGet("{companyId},{PageId}")]
        public async Task<ApplicationPageResponse> GetApplicationPageSummery(int companyId, int PageId)
        {
            IEnumerable<ApplicationPageVM> applicationPageVm;

            ApplicationPageResponse applicationPageResponse = new ApplicationPageResponse();
            try
            {
                applicationPageVm = await _ApplicationUserServices.GetApplicationPageSummery(companyId, PageId);
                applicationPageResponse.applicationPageVM= applicationPageVm;
                applicationPageResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                applicationPageResponse.IsSuccess = false;
                applicationPageResponse.Message = exc.Message;
            }

            return applicationPageResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<ApplicationUserResponse> GetAllApplicationUserDetails(int companyId)
        {
            IEnumerable<ApplicationUserVM> applicationUserVm;

            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            try
            {
                applicationUserVm = await _ApplicationUserServices.GetAllApplicationUserDetails(companyId);
                applicationUserResponse.applicationUserVM = applicationUserVm;
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

        [HttpGet("{userId}")]
        public async Task<ApplicationUserResponse> GetApplicationUserDetailsByUserId(int userId)
        {
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            IEnumerable<ApplicationUserVM> applicationUserVM;
            try
            {
                applicationUserVM = new List<ApplicationUserVM>
                {
                    await _ApplicationUserServices.GetApplicationUserDetailsByUserId(userId)
                };
                applicationUserResponse.applicationUserVM = applicationUserVM;
                applicationUserResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = ex.Message;
            }
            return applicationUserResponse;
        }

        [HttpGet("{userId}")]
        public async Task<ApplicationUserResponse> GetDetailedApplicationUserInfoByUserId(int userId)
        {
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            ApplicationUserVM applicationUserVM;
            try
            {
                applicationUserVM = await _ApplicationUserServices.GetDetailedApplicationUserInfoByUserId(userId);

                applicationUserResponse.applicationUserVm=applicationUserVM;
                applicationUserResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = ex.Message;
            }
            return applicationUserResponse;
        }

        [HttpPut]
        public async Task<ApplicationUserResponse> UserLogOut([FromBody] int userId)
        {
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            IEnumerable<ApplicationUserVM> applicationUserVM;

            try
            {
                applicationUserVM = new List<ApplicationUserVM>
                {
                    await _ApplicationUserServices.UserLogOut(userId)
                };
                applicationUserResponse.applicationUserVM = applicationUserVM;
                applicationUserResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = ex.Message;
            }
            return applicationUserResponse;
        }

        [HttpPost]
        public async Task<ApplicationUserBranchResponse> AddNewUserBranchDetails([FromBody]ApplicationUserBranchRequest applicationUserBranchRequest)
        {
            ApplicationUserBranchResponse applicationUserBranchResponse = new ApplicationUserBranchResponse();
            IEnumerable<ApplicationUserBranchVM> applicationUserBranchVM;

            try
            {
                applicationUserBranchVM = new List<ApplicationUserBranchVM>
                {
                    await  _ApplicationUserServices.AddNewUserBranchDetails(applicationUserBranchRequest.applicationUserBranchVM)
                };
                applicationUserBranchResponse.applicationUserBranchVM = applicationUserBranchVM;
                applicationUserBranchResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                applicationUserBranchResponse.IsSuccess = false;
                applicationUserBranchResponse.Message = ex.Message;
            }
            return applicationUserBranchResponse;
        }

        [HttpPut]
        public async Task<UserBranchResponse> UpdateUserBranchDetailsByBusinessProcessId([FromBody]UserBranchRequest userBranchRequest)
        {
            UserBranchResponse userBranchResponse = new UserBranchResponse();
            IEnumerable<UserBranchVm> userBranchVm;

            try
            {
                userBranchVm = new List<UserBranchVm>
                {
                    await _ApplicationUserServices.UpdateUserBranchDetailsByBusinessProcessId(userBranchRequest.userBranchVm)
                };
                userBranchResponse.userBranchVm = userBranchVm;
                userBranchResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userBranchResponse.IsSuccess = false;
                userBranchResponse.Message = ex.Message;
            }
            return userBranchResponse;
        }

        [HttpPost]
        public async Task<UserCommentResponse> AddUserCommentDetails([FromBody]UserCommentRequest userCommentRequest)
        {
            UserCommentResponse userCommentResponse = new UserCommentResponse();
            IEnumerable<UserCommentVM> userCommentVM;
            
            try
            {
                userCommentVM = new List<UserCommentVM>{
                    await _ApplicationUserServices.AddUserCommentDetails(userCommentRequest.userCommentVM)
                };
                userCommentResponse.userCommentVM = userCommentVM;
                userCommentResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userCommentResponse.IsSuccess = false;
                userCommentResponse.Message = ex.Message;
            }
            return userCommentResponse;
        }

        [HttpGet]
        public async Task<UserCommentResponse> GetUserCommmentDetails( )
        {
            UserCommentResponse userCommentResponse = new UserCommentResponse();
            IEnumerable<UserCommentVM> userCommentVM;

            try
            {
                userCommentVM = await _ApplicationUserServices.GetUserCommmentDetails();
                userCommentResponse.userCommentVM = userCommentVM;
                userCommentResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userCommentResponse.IsSuccess = false;
                userCommentResponse.Message = ex.Message;
            }
            return userCommentResponse;
        }
    }
}