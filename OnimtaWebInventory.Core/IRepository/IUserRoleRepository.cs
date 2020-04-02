using DBConnect;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IUserRoleRepository : IDBContext
    {
        Task<IEnumerable<UserRoleVm>>GetUserRolesDetails();
        Task<UserRoleVM> AddUserRolesDetails(UserRoleVM userRoleVM);
        Task<UserRoleVM> UpdateUserRolesDetailsByUserRoleId(UserRoleVM userRoleVM);
        Task<ApplicationPageVM> GetPageDetailsByPageId( int pageId);
        Task<UserRoleVM> UpdateUserRolesDetailsByUserId(UserRoleVM userRoleVM);
        Task< IEnumerable<UserBranchVm>>UpdateUserBranchDetailsByUserId(IEnumerable<UserBranchVm> userBranchVm);

        Task<IEnumerable<UserBranchVm>> DeleteUserBranchDetailsByUserId(UserBranchVm userBranchVm);

        Task<UserRoleVM> UpdateApplicationUserPrivilegeDetailsByUserId(int userId ,string privilegesId);

        Task<IEnumerable<ApplicationPrivilegeVM>> GetPrivilegesByPageId(int pageId);
        Task<IEnumerable<UserRoleVM>> getUserRolesDetailsByPrivilegeId(int companyId, string privilegeId);
        Task<int> UpdateUserRolePrivilegeSettings(int privilegeId, int status,string roleIds);
        Task<IEnumerable<UserRolePrivilegeSettingsVM>> getUserPrivilegeDetails();
        Task<IEnumerable<UserRoleVM>> GetUserPrivilegeDetailsByUserId( int userId);
        // Task<UserRolePrivilegeSettingsVM> UpdateUserRolePrivilegeSettings(string privilegeId, int status, string roleIds);
        Task<IEnumerable<UserBranchVm>> GetUserBranchDetailsByuserId(int userId,int businessProcessId);


        Task<IEnumerable<ModuleVM>> GetModules();

        // --------------JEWELLERY -------------------//
        Task<UserRoleVm> AddUserRoleDetails(UserRoleVm userRole);
        Task<UserRoleVm> UpdateUserRoleDetails(UserRoleVm userRole);
        Task<UserRoleVm> DeleteUserRoleDetails(int id);
        Task<IEnumerable<UserRoleVm>> GetAllUserRoleDetails();
        Task<UserRoleVm> GetUserRoleDetail(int id);
        Task<IEnumerable<UserBranchVm>> UpdateUserBranchDetailsByUserId(UserBranchVm userBranchVm);


    }
}
