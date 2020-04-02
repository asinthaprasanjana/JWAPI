using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Notification;
using OnimtaWebInventory.DTO.NotificationSetting;
using OnimtaWebInventory.DTO.NotificationType;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class NotificationController : Controller
    {
        private INotificationServices _NotificationServices;
        private ILogger<NotificationController> _logger;

        public NotificationController(INotificationServices NotificationServices, ILogger<NotificationController> logger)
        {
            _NotificationServices = NotificationServices;
            _logger = logger;

        }

        [HttpGet("{userId}")]
        public async Task<NotificationEventsResponse> GetNotificationEventDetailsByUserId(int userId)
        {
            NotificationEventsResponse notificationEventsResponse = new NotificationEventsResponse();
            IEnumerable<NotificationEventsVM> notificationEventsVM;

            try
            {
                notificationEventsVM = await _NotificationServices.GetNotificationEventDetailsByUserId(userId);
                notificationEventsResponse.notificationEventsVM = notificationEventsVM;
                notificationEventsResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                notificationEventsResponse.IsSuccess = false;
                notificationEventsResponse.Message = exc.Message;

            }
            return notificationEventsResponse;
        }
        [HttpGet("{companyId}")]
        public async Task<NotificationSettingResponse> GetNotificationSetting(int companyId)
        {
            NotificationSettingResponse notificationSettingResponse = new NotificationSettingResponse();
            IEnumerable<NotificationSettingVM> notificationSettingVm;
            try
            {
                notificationSettingVm = new List<NotificationSettingVM>()
                {
                    await _NotificationServices.GetNotificationSetting(companyId)
                };
                notificationSettingResponse.notificationSettingVM = notificationSettingVm;
                notificationSettingResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                notificationSettingResponse.IsSuccess = false;
                notificationSettingResponse.Message = ex.Message;
            }
            return notificationSettingResponse;
        }
        [HttpPost]
        public async Task<NotificationEventsResponse> AddNotificationEvents([FromBody]NotificationEventsRequest notificationEventsRequest)
        {
            NotificationEventsResponse notificationEventsResponse = new NotificationEventsResponse();
            IEnumerable<NotificationEventsVM> notificationEventsVM;

            try
            {
                notificationEventsVM = new List<NotificationEventsVM>
                {
                    await _NotificationServices.AddNotificationEvents(notificationEventsRequest.notificationEventsVM)
                };
                notificationEventsResponse.notificationEventsVM = notificationEventsVM;
                notificationEventsResponse.IsSuccess = true;
                _logger.LogInformation(notificationEventsRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                notificationEventsResponse.IsSuccess = false;
                notificationEventsResponse.Message = ex.Message;
            }
            return notificationEventsResponse;
        }

        [HttpPut]
        public async Task<NotificationEventsResponse> UpdateNotificationEventsDetailByUserId(int Id, int IsActive)
        {
            NotificationEventsResponse notificationEventsResponse = new NotificationEventsResponse();
            IEnumerable<NotificationEventsVM> notificationEventsVM;

            try
            {
                notificationEventsVM = new List<NotificationEventsVM>
                {
                    await _NotificationServices.UpdateNotificationEventsDetailByUserId(Id,IsActive)
                };
                notificationEventsResponse.notificationEventsVM = notificationEventsVM;
                notificationEventsResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                notificationEventsResponse.IsSuccess = false;
                notificationEventsResponse.Message = ex.Message;
            }
            return notificationEventsResponse;
        }

        [HttpDelete]
        public async Task<NotificationEventsResponse> DeleteNotificationEventsDetailByUserId(int userId)
        {
            NotificationEventsResponse notificationEventsResponse = new NotificationEventsResponse();
            IEnumerable<NotificationEventsVM> notificationEventsVM;
            try
            {
                notificationEventsVM = new List<NotificationEventsVM>
                {
                    await _NotificationServices.DeleteNotificationEventsDetailByUserId(userId)
                };
                notificationEventsResponse.notificationEventsVM = notificationEventsVM;
                notificationEventsResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                notificationEventsResponse.IsSuccess = false;
                notificationEventsResponse.Message = ex.Message;
            }
            return notificationEventsResponse;
        }
        [HttpPut]
        public async Task<NotificationEventsResponse> UpdateUserNotificationReadByUserId([FromBody] int userId)
        {
            NotificationEventsResponse notificationEventsResponse = new NotificationEventsResponse();
            IEnumerable<NotificationEventsVM> notificationEventsVM;

            try
            {
                notificationEventsVM = new List<NotificationEventsVM>
                {
                    await _NotificationServices.UpdateUserNotificationReadByUserId(userId)
                };
                notificationEventsResponse.notificationEventsVM = notificationEventsVM;
                notificationEventsResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                notificationEventsResponse.IsSuccess = false;
                notificationEventsResponse.Message = ex.Message;
            }
            return notificationEventsResponse;
        }

        [HttpPut]
        public async Task<NotificationTypeResponse> updateNotificationTypeDetails([FromBody]NotificationTypeRequest notificationTypeRequest)
        {
            NotificationTypeResponse notificationTypeResponse = new NotificationTypeResponse();
            NotificationTypeVM NotificationTypeVm =new  NotificationTypeVM();

            try
            {
                NotificationTypeVm = await _NotificationServices.updateNotificationTypeDetails(notificationTypeRequest.NotificationTypeVM);
                notificationTypeResponse.NotificationTypeVM = NotificationTypeVm;
                notificationTypeResponse.IsSuccess = true;
               // _logger.LogInformation(notificationEventsRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                notificationTypeResponse.IsSuccess = false;
                notificationTypeResponse.Message = ex.Message;
            }
            return notificationTypeResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<NotificationTypeResponse> getAllNotificationTypeDetails(int companyId)
        {
            NotificationTypeResponse notificationTypeResponse = new NotificationTypeResponse();
            IEnumerable<NotificationTypeVM> NotificationTypeVm;

            try
            {
                NotificationTypeVm = await _NotificationServices.getAllNotificationTypeDetails(companyId);
                notificationTypeResponse.NotificationTypeVMs = NotificationTypeVm;
                notificationTypeResponse.IsSuccess = true;
                // _logger.LogInformation(notificationEventsRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                notificationTypeResponse.IsSuccess = false;
                notificationTypeResponse.Message = ex.Message;
            }
            return notificationTypeResponse;
        }
    }


}