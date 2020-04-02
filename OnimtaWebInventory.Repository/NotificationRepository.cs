using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class NotificationRepository : DBContext ,INotificationRepository
    {
        public async Task<NotificationEventsVM> AddNotificationEvents(NotificationEventsVM notificationEventsVM)
        {
            NotificationEventsVM notificationEventsVm = new NotificationEventsVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.AddDynamicParams(notificationEventsVM);
                notificationEventsVm = await dbConnection.QuerySingleOrDefaultAsync<NotificationEventsVM>("ntm.AddNotificationEvents", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return notificationEventsVm;
        }

        public async Task<NotificationEventsVM> DeleteNotificationEventsDetailByUserId(int userId)
        {
            NotificationEventsVM notificationEventsVM = new NotificationEventsVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                notificationEventsVM = await dbConnection.QuerySingleOrDefaultAsync<NotificationEventsVM>("ntm.DeleteNotificationEventsDetailByUserId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return notificationEventsVM;
        }

        public async Task <IEnumerable<NotificationEventsVM>> GetNotificationEventDetailsByUserId(int userId)
        {
            IEnumerable<NotificationEventsVM> notificationEventsVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId",userId);
                notificationEventsVM = await dbConnection.QueryAsync<NotificationEventsVM>("ntm.GetNotificationEventDetailsByUserId", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return notificationEventsVM;
        }

      
        public async Task<NotificationSettingVM> GetNotificationSetting(int companyId)
        {
            NotificationSettingVM notificationSettingVM = new NotificationSettingVM();
            try
            {
                var dynamicParam = new DynamicParameters();
                dynamicParam.Add("@CompanyId", companyId);
                notificationSettingVM = await dbConnection.QuerySingleOrDefaultAsync<NotificationSettingVM>("wkb.GetNotificationSetting", dynamicParam, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return notificationSettingVM;
        }

        public async Task<NotificationTypeVM> GetNotificationUserIdsByNotificationTypeId(int notificationTypeId, string branchId,string transactionNo, int userId)
        {
            NotificationTypeVM notificationTypeVM  = new NotificationTypeVM() ;
             IEnumerable<  ApprovalOfficerVM> approvalOfficerVM;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@NotificationTypeId", notificationTypeId);
                dynamicParameterlist.Add("@BranchId", branchId);
                dynamicParameterlist.Add("@TransactionNo", transactionNo);
                dynamicParameterlist.Add("@UserId", userId);
                approvalOfficerVM = await dbConnection.QueryAsync<ApprovalOfficerVM>("ntm.GetNotificationUserIdsByNotificationTypeId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                notificationTypeVM.ApprovalOffcerVM = approvalOfficerVM.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return notificationTypeVM;       
         }

        public async Task<NotificationEventsVM> UpdateNotificationEventsDetailByUserId(int Id,int IsActive)
        {
            NotificationEventsVM notificationEventsVM = new NotificationEventsVM();
            try
            {   var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", Id);
                dynamicParameterlist.Add("@IsActive", IsActive);
                notificationEventsVM = await dbConnection.QuerySingleOrDefaultAsync<NotificationEventsVM>("ntm.UpdateNotificationEventsDetailByUserId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return notificationEventsVM;
        }

        public async Task<NotificationEventsVM> UpdateUserNotificationReadByUserId(int userId)
        {
            NotificationEventsVM notificationEventsVM = new NotificationEventsVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@UserId", userId);
                notificationEventsVM = await dbConnection.QuerySingleOrDefaultAsync<NotificationEventsVM>("ntm.UpdateUserNotificationReadByUserId", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return notificationEventsVM;
        }

        public async Task<NotificationTypeVM> updateNotificationTypeDetails(NotificationTypeVM notificationTypeVM)
        {
            NotificationTypeVM notificationTypeVm = new NotificationTypeVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@companyId", notificationTypeVM.CompanyId);
                dynamicParameterlist.Add("@roles", notificationTypeVM.RoleIds);
               // dynamicParameterlist.Add("@notificationTypeId", notificationTypeVM.NotificationTypeId);
                dynamicParameterlist.Add("@isActive", notificationTypeVM.IsActive);
                dynamicParameterlist.Add("@notificationType", notificationTypeVM.NotificationType);
                notificationTypeVm = await dbConnection.QuerySingleOrDefaultAsync<NotificationTypeVM>("ntm.updateNotificationTypeDetail", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return notificationTypeVm;
        }

        public async Task<IEnumerable<NotificationTypeVM>> getAllNotificationTypeDetails(int companyId)
        {
            IEnumerable<NotificationTypeVM> NotificationTypeVm;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@CompanyId", companyId);
                NotificationTypeVm = await dbConnection.QueryAsync<NotificationTypeVM>("ntm.getAllNotificationTypeDetail", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NotificationTypeVm;
        }
    }
}

   