using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IApprovalRepository
    {
        Task<ApprovalVM> GetApprovalDetailsById(int id, int companyId);
        Task<ChangeApprovalVM> UpdateApprovalDetailsByFunctionId(int functionId, int companyId, int status);
        Task<FunctionApprovalTypeVm> GetFunctionApprovalDetailsByFunctionId(int functionId, int companyId);
        Task<IEnumerable<FunctionApprovalTypeVm>> GetAllFunctionApprovalDetails();
        Task<ApprovalVM> AddNewApproveByApprovalId(ApprovalVM approvalVM);
       // Task<ApprovalTaskVM> AddNewApprovalTaskDetails(ApprovalTaskVM approvalTaskVM);
        Task<ApprovalVM> AddNewApprovalDetails(ApprovalVM approvalVM);
        Task <IEnumerable <ApprovalEventVM>> GetOwnApprovalDetailByUserID (int userID, int companyId,int pageId);
        Task<ApplicationUserVM> GetUserDetailsByUserId(int userId);
        Task<ApprovalTypeOwnVM> GetApprovalOfficerDetailsByApprovalTypeId(int userId);
        Task<ApprovalTypeOwnVM> UpdateApprovalOfficerDetailsByApprovalTypeId(int approvalTypeId,string approvalOfficerIdList,int companyId);
        Task<ApplicationUserVM> GetApprovalOfficerByUserId(int userId);
        Task<IEnumerable<ApprovalEventVM>> GetAllApprovalEventsByUserId(int userId, int pageId);
        Task<ApprovalEventVM> AddNewApprovalEventDetails(ApprovalEventVM approvalEventVM);
        Task<ApprovalResponseVM> UpdateApprovalRejectOrAcceptByTaskId(ApprovalResponseVM approvalResponseVM);
        Task<ApprovalTaskVM> GetApprovalTaskCreatedUserIdbyTaskId(string approvalTaskId);
        Task<ApprovalVM> GetApprovalDetailsById(int id, int companyId, int pageId);
    }
}
