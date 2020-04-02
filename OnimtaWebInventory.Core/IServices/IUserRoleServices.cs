using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices 
{
    public interface IUserRoleServices
    {
        Task<IEnumerable<UserRoleVm>>GetUserRolesDetails();
        Task<IEnumerable<UserRoleVM>> getUserRolesDetailsByPrivilegeId(int companyId, string privilegeId);
        Task<IEnumerable<UserRoleVM>> GetUserPrivilegeDetailsByUserId(int userId);
        Task<IEnumerable<UserBranchVm>> GetUserBranchDetailsByuserId(int userId, int businessProcessId);
        Task<IEnumerable<UserRolePrivilegeSettingsVM>> getUserPrivilegeDetails();

        Task<UserRoleVM> AddUserRolesDetails(UserRoleVM userRoleVM);

        Task<UserRoleVM> UpdateUserRolesDetailsByUserRoleId(UserRoleVM userRoleVM);
        Task<UserRoleVM> UpdateUserRolesDetailsByUserId(UserRoleVM userRoleVM);
        Task<IEnumerable<UserBranchVm>> UpdateUserBranchDetailsByUserId(IEnumerable<UserBranchVm> userBranchVms);
        Task<int> UpdateUserRolePrivilegeSettings(int privilegeId, int status,string roleIds);
        Task<UserRoleVM> UpdateApplicationUserPrivilegeDetailsByUserId(int userId, string privilegesId);

        //  Task<UserRolePrivilegeSettingsVM> UpdateUserRolePrivilegeSettings(string privilegeId, int status, string roleIds);


        Task<IEnumerable<ModuleVM>> GetModules();

       // --------------JEWELLERY -------------------//
        Task<UserRoleVm> AddUserRoleDetails(UserRoleVm userRole);
        Task<UserRoleVm> UpdateUserRoleDetails(UserRoleVm userRole);
        Task<UserRoleVm> DeleteUserRoleDetails(int id);
        Task<IEnumerable<UserRoleVm>> GetAllUserRoleDetails();
        Task<UserRoleVm> GetUserRoleDetail(int id);


    }
}
