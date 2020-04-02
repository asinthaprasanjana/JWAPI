using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub;

namespace NotificationApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UserManagementController : Controller
    {
        private IHubContext<NotifyHub, ITypedHubClient> _hubContext;
        public UserManagementController(IHubContext<NotifyHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;

        }

        [HttpPost]
        [DisableCors]
        public async Task<string> Post([FromBody]MessageVM msg)
        {
            string returnMessage = string.Empty;
            try
            {
              
                for(int i= 0;i<2;i++)
                {
                    await _hubContext.Clients.All.UserLogInControl(msg);
                }
                returnMessage = "Success";
            }
            catch (Exception e)
            {
                returnMessage = e.ToString();
            }
            return returnMessage;
        }
    }
}