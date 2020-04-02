using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IEmailServices
    {
        Task<EmailVM> SendEmail(EmailVM emailVM);
        Task<ApplicationUserVM> SendRecoveryEmail(EmailVM emailVM,string username);
    }
}
