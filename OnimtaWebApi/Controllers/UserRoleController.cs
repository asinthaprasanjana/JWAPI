using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.UserBranch;
using OnimtaWebInventory.DTO.UserRole;
using OnimtaWebInventory.DTO.UserRolePrivilegeSettings;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserRoleController : Controller
    {
        private IUserRoleServices _userRoleServices;
        private ILogger<UserRoleController> _logger;

        public UserRoleController(IUserRoleServices UserRoleServices, ILogger<UserRoleController> logger)
        {
            _userRoleServices = UserRoleServices;
            _logger = logger;
        }
        [HttpGet]
        public async Task<UserRoleResponse>GetUserRolesDetails()
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            IEnumerable<UserRoleVm> userRoleVm;
            try
            {
                userRoleVm = await _userRoleServices.GetUserRolesDetails();
                userRoleResponse.userRoles = userRoleVm;
                userRoleResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }
            return userRoleResponse;
        }


        [HttpGet]
        public async Task<UserRolePrivilegeSettingsResponse> getUserPrivilegeDetails()
        {
            UserRolePrivilegeSettingsResponse userRolePrivilegeSettingsResponse = new UserRolePrivilegeSettingsResponse();
            IEnumerable<UserRolePrivilegeSettingsVM> privilegeSettingsVMs;
            try
            {
                privilegeSettingsVMs = await _userRoleServices.getUserPrivilegeDetails();
                userRolePrivilegeSettingsResponse.userRolePrivilegeSettingsVM = privilegeSettingsVMs;
                userRolePrivilegeSettingsResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userRolePrivilegeSettingsResponse.IsSuccess = false;
                userRolePrivilegeSettingsResponse.Message = ex.Message;
            }
            return userRolePrivilegeSettingsResponse;
        }

        [HttpGet("{companyId},{privilegeIds}")]
        public async Task<UserRoleResponse> getUserRolesDetailsByPrivilegeId(int companyId,string privilegeIds)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            IEnumerable<UserRoleVM> userRoleVM;
            try
            {
                userRoleVM = await _userRoleServices.getUserRolesDetailsByPrivilegeId(companyId, privilegeIds);
                userRoleResponse.userRoleVM = userRoleVM;
                userRoleResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }
            return userRoleResponse;
        }

        [HttpPost]
        public async Task<UserRoleResponse> AddUserRolesDetails([FromBody]UserRoleRequest userRoleRequest)
        {

            UserRoleResponse userRoleResponse = new UserRoleResponse();
            IEnumerable<UserRoleVM> userRoleVm;
            try
            {
                userRoleVm = new List<UserRoleVM>
                {
                    await _userRoleServices.AddUserRolesDetails(userRoleRequest.userRoleVM)
                };
                userRoleResponse.IsSuccess = true;
                userRoleResponse.userRoleVM = userRoleVm;
                _logger.LogInformation(userRoleRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }
            return userRoleResponse;
        }
        [HttpPut]
        public async Task<UserRoleResponse> UpdateUserRolesDetailsByUserRoleId([FromBody]UserRoleRequest userRoleRequest)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            IEnumerable<UserRoleVM> userRoleVM;
            try
            {
                userRoleVM = new List<UserRoleVM>
                {
                    await _userRoleServices.UpdateUserRolesDetailsByUserRoleId(userRoleRequest.userRoleVM)
                };
                userRoleResponse.userRoleVM = userRoleVM;
                userRoleResponse.IsSuccess = true;
                _logger.LogInformation(userRoleRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }
            return userRoleResponse;
        }



        [HttpPut]
        public async Task<UserRoleResponse> UpdateUserRolePrivilegeSettings([FromBody]UserRolePrivilegeSettingsVM userRolePrivilegeSettingsVM)
        {
            int  status, privilegeId;
            string roleIds;

            privilegeId = userRolePrivilegeSettingsVM.PrivilegeId;
            status = userRolePrivilegeSettingsVM.Status;
            roleIds = userRolePrivilegeSettingsVM.RoleIds;
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            try
            {
                  await _userRoleServices.UpdateUserRolePrivilegeSettings(privilegeId,status,roleIds);

                userRoleResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }
            return userRoleResponse;
        }



        [HttpPut]
        public async Task<UserRoleResponse> UpdateUserRolesDetailsByUserId([FromBody]UserRoleRequest userRoleRequest)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            IEnumerable<UserRoleVM> userRoleVM;

            try
            {
                userRoleVM = new List<UserRoleVM>
                {
                    await _userRoleServices.UpdateUserRolesDetailsByUserId(userRoleRequest.userRoleVM)
                };
                userRoleResponse.userRoleVM = userRoleVM;
                userRoleResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }

            return userRoleResponse;
          }

        [HttpPut]
        public async Task<UserBranchResponse> UpdateUserBranchDetailsByUserId([FromBody]UserBranchRequest userBranchRequest)
        {
            UserBranchResponse userBranchResponse  = new UserBranchResponse();
            IEnumerable<UserBranchVm> userBranchVm;

            try
            {
                userBranchVm = await _userRoleServices.UpdateUserBranchDetailsByUserId(userBranchRequest.userBranchs);
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

        [HttpPut]
        public async Task<UserRoleResponse> UpdateApplicationUserPrivilegeDetailsByUserId(int userId, string privilegesId)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            IEnumerable<UserRoleVM> userRoleVM;

            try
            {
                userRoleVM = new List<UserRoleVM>
                {
                    await  _userRoleServices.UpdateApplicationUserPrivilegeDetailsByUserId(userId,privilegesId)
                };
                userRoleResponse.userRoleVM = userRoleVM;
                userRoleResponse.IsSuccess = true;
          
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }

            return userRoleResponse;
        }

        [HttpGet("{userId}")]
        public async Task<UserRoleResponse> GetUserPrivilegeDetailsByUserId(int userId)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            IEnumerable<UserRoleVM> userRoleVM;

            try
            {
                userRoleVM = await _userRoleServices.GetUserPrivilegeDetailsByUserId(userId);
                userRoleResponse.userRoleVM = userRoleVM;
                userRoleResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }
            return userRoleResponse;
        }

        [HttpGet("{userId},{businessProcessId}")]

        public async Task<UserBranchResponse> GetUserBranchDetailsByuserId(int userId, int businessProcessId)
        {
            UserBranchResponse userBranchResponse = new UserBranchResponse();
            IEnumerable<UserBranchVm> userBranchVm;

            try
            {
                userBranchVm = await _userRoleServices.GetUserBranchDetailsByuserId(userId,businessProcessId);
                userBranchResponse.userBranchVm = userBranchVm;
                userBranchResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userBranchResponse.IsSuccess = false;
                userBranchResponse.Message = ex.Message;
            }

            return userBranchResponse;
        }

        [HttpGet]
        public async Task<UserBranchResponse> GetModules()
        {
            UserBranchResponse userBranchResponse = new UserBranchResponse();
            IEnumerable<ModuleVM> Modules;

            try
            {
                Modules = await _userRoleServices.GetModules();
                userBranchResponse.Modules = Modules;
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
        public async Task<UserRoleResponse> AddUserRoleDetails([FromBody]UserRoleRequest userRoleRequest)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            UserRoleVm userRoleVm = new UserRoleVm();

            try
            {
                userRoleVm = await _userRoleServices.AddUserRoleDetails(userRoleRequest.userRole);
                userRoleResponse.userRole = userRoleVm;
                userRoleResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }

            return userRoleResponse;
        }

        [HttpPut]
        public async Task<UserRoleResponse> UpdateUserRoleDetails([FromBody]UserRoleRequest userRoleRequest)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            UserRoleVm userRoleVm = new UserRoleVm();

            try { 
            
                userRoleVm = await _userRoleServices.UpdateUserRoleDetails(userRoleRequest.userRole);
                userRoleResponse.userRole = userRoleVm;
                userRoleResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }

            return userRoleResponse;
        }


        [HttpDelete("{id}")]
        public async Task<UserRoleResponse> DeleteUserRoleDetails(int id)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            UserRoleVm userRoleVm = new UserRoleVm();

            try
            {
                userRoleVm = await _userRoleServices.DeleteUserRoleDetails(id);
                userRoleResponse.userRole = userRoleVm;
                userRoleResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }

            return userRoleResponse;
        }

        [HttpGet]
        public async Task<UserRoleResponse>GetAllUserRoleDetails()
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            IEnumerable<UserRoleVm> userRoleVm;

            try
            {
                userRoleVm = await _userRoleServices.GetAllUserRoleDetails();
                userRoleResponse.userRoles = userRoleVm;
                userRoleResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;
            }

            return userRoleResponse;
        }

        [HttpGet("{id}")]
        public async Task<UserRoleResponse> GetUserRoleDetail(int id)
        {
            UserRoleResponse userRoleResponse = new UserRoleResponse();
            UserRoleVm userRoleVm = new UserRoleVm();
            
            try
            {
                userRoleVm = await _userRoleServices.GetUserRoleDetail(id);
                userRoleResponse.userRole = userRoleVm;
                userRoleResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                userRoleResponse.IsSuccess = false;
                userRoleResponse.Message = ex.Message;

            }

            return userRoleResponse;
        }
    }
}