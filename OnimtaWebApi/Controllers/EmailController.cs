using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.Core.IServices;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.DTO.ApplicationUser;
using Microsoft.AspNetCore.Authorization;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class EmailController : Controller
    {

        private IEmailServices _EmailServices;
        private ILogger<EmailController> _logger;

        public EmailController(IEmailServices EmailServices, ILogger<EmailController> logger)
        {
            _EmailServices = EmailServices;
            _logger = logger;
        }


        [HttpPost]
        public async Task<string >SendEmail ()
        {
            EmailVM emailVm = new EmailVM();

            try
            {
                await _EmailServices.SendEmail(emailVm);

                //    var builder = new StringBuilder();

                //  //  using (var reader = File.OpenText("template.html"))
                // //   {
                //   //     builder.Append(reader.ReadToEnd());
                //  //  }

                //    builder.Replace("{{foo-value}}", "PO#4327");
                //    builder.Replace("{{supplier}}", "Uniliver Sri Lanka");
                //    builder.Replace("{{date}}", "01--3-2019");
                //    builder.Replace("{{Total}}", "55,000 LKR");



                //    SmtpClient client = new SmtpClient();
                //    client.UseDefaultCredentials = false;
                //    MailMessage mail = new MailMessage();
                //    client.Host = "smtp.gmail.com";
                //    client.Port = 587;
                //    client.Credentials = new NetworkCredential("ruchikamadubashitha@gmail.com", "sanathjayasuriya123");
                //    client.EnableSsl = true;
                //    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                //    //string path = @"F:\print\a.pdf";
                //    //mail.Attachments.Add(new Attachment(path));

                //    mail.From = new MailAddress("ruchikamadubashitha@gmail.com", "Onimta Inventory");
                //    mail.To.Add(new MailAddress("plazeracc@gmail.com"));
                //    mail.Subject = "New Purchase Order has been created";
                //    mail.IsBodyHtml = true;
                //    mail.Body = builder.ToString();

                //    client.Send(mail);
            }
            catch
            {

            }

            return "aa";

        }

        [HttpGet("{Username}")]
        public async Task<ApplicationUserResponse> SendRecoveryEmail(string Username)
        {
            EmailVM emailVm = new EmailVM();
            ApplicationUserResponse applicationUserResponse = new ApplicationUserResponse();
            try
            {
                applicationUserResponse.applicationUserVm= await _EmailServices.SendRecoveryEmail(emailVm, Username);
                applicationUserResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                applicationUserResponse.IsSuccess = false;
                applicationUserResponse.Message = ex.Message;
            }

            return applicationUserResponse;

        }

    }
}