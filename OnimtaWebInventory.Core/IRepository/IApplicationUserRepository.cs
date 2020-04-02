using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUserVM> GetApplicationUserDetails(string userName, string password);
        Task<ApplicationUserVM> AddNewApplicationUserDetails(ApplicationUserVM applicationUserVM);
        Task<ApplicationUserVM> UserLogOut(int userId);
        Task<ApplicationUserVM> UpdateApplicationUserDetails(ApplicationUserVM applicationUserVM);
        Task<IEnumerable<ApplicationUserVM>> GetAllApplicationUserDetails(int companyId);

        Task<IEnumerable<ApplicationPageTreeVm>> GetApplicationPageDetails(int companyId);

        Task<IEnumerable<ApplicationPageVM>> GetApplicationPagesByUserId(int userId,int companyId);
        Task<IEnumerable<ApplicationPageVM>> GetApplicationPageSummery(int companyId,int PageId);
        Task<ApplicationPageVM> AddNewApplicationPages(ApplicationPageVM applicationPageVM);

        Task<ApprovalOfficerVM> GetApplicationUserDetailsByUserId(int userId);
        Task<ApplicationUserVM> GetDetailedApplicationUserInfoByUserId(int userId);

        Task<ApplicationUserVM> GetApplicationUserPassByUserName(string userName);
        Task< IEnumerable< ApplicationPageVM>> GetApplicationPageDetailsByUserRoleId(int userRoleId);
        Task<ApplicationUserBranchVM> AddNewUserBranchDetails(ApplicationUserBranchVM applicationUserBranchVM);
        Task<UserBranchVm> UpdateUserBranchDetailsByBusinessProcessId(UserBranchVm userBranchVm);
        Task<UserCommentVM> AddUserCommentDetails(UserCommentVM userCommentVM);
        Task<IEnumerable<UserCommentVM>> GetUserCommmentDetails();
    }
    
}
