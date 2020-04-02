using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
   public  interface IApprovalServices
    {
        
        Task<FunctionApprovalTypeVm> GetFunctionApprovalDetailsByFunctionId(int approvalTypeId, int notificationtypeId, string referenceNo, int userId, int companyId);



        Task<ChangeApprovalVM> UpdateApprovalDetailsByFunctionId(int functionId, int companyId, int status);
        Task<IEnumerable<FunctionApprovalTypeVm>> GetAllFunctionApprovalDetails();
        Task<ApprovalVM> GetApprovalDetailsById(int id, int companyId, int pageId);
        Task<ApprovalVM> AddNewApprovalDetails(ApprovalVM approvalVM);
        Task<IEnumerable<ApprovalEventVM>> GetOwnApprovalDetailByUserID (int userID, int companyId, int pageId);
        Task<ApprovalVM> AddNewApproveByApprovalId(ApprovalVM approvalVM);
        Task<IEnumerable<ApplicationUserVM>> GetApplicationUserDetailsByUserId(int approvalId);
        Task<ApprovalTypeOwnVM> UpdateApprovalOfficerDetailsByApprovalTypeId(int approvalTypeId, string approvalOfficerIdList, int companyId);
        Task<IEnumerable<ApprovalEventVM>> GetAllApprovalEventsByUserId(int userId, int pageId);
        Task<ApprovalEventVM> AddNewApprovalEventDetails(ApprovalEventVM approvalEventVM);
        Task<ApprovalResponseVM> UpdateApprovalRejectOrAcceptByTaskId(ApprovalResponseVM approvalResponseVM);
    }
}

 