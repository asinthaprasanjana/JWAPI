using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services
{
    public class EmailServices : IEmailServices
    {

        private readonly IUnitOfWork _unitOfWork;


        public EmailServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmailVM> SendEmail(EmailVM emailVM)
        {
            int userLogInEmailTemplateTypeId = 1;
            EmailVM emailVm = new EmailVM();
            try
            {
                var builder = new StringBuilder();

                if (emailVM.TemplateTypeId == userLogInEmailTemplateTypeId)
                {
                    using (var reader = File.OpenText("UserLogInEmail.html"))
                    {
                        String strHostName = string.Empty;

                        strHostName = Dns.GetHostName();
                        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                        IPAddress[] addr = ipEntry.AddressList;

                        string ipAddress = addr[1].ToString();
                        builder.Append(reader.ReadToEnd());
                        builder.Replace("{{machineName}}", strHostName);
                        builder.Replace("{{ip}}", ipAddress);
                        builder.Replace("{{date}}", emailVM.Reference3);

                    }
                }
                //builder.Replace("{{RefNo}}", "PO#4327");
                //builder.Replace("{{supplier}}", "Uniliver Sri Lanka");
                //builder.Replace("{{DateTime}}", "01-3-2019 7.44AM");
                //builder.Replace("{{ProductName}}", "Happy cow cheese");
                //builder.Replace("{{ItemCost}}", "Rs.350.00");
                //builder.Replace("{{Quantity}}", "10");
                //builder.Replace("{{TotalCost}}", "Rs.3500.00");
                //builder.Replace("{{Tax}}", "10%");
                //builder.Replace("{{Discount}}", "-");


                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                MailMessage mail = new MailMessage();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.Credentials = new NetworkCredential("ruchikamadubashitha@gmail.com", "sanathjayasuriya123");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                //string path = @"F:\print\a.pdf";
                //mail.Attachments.Add(new Attachment(path));

                mail.From = new MailAddress("ruchikamadubashitha@gmail.com", "Onimta Inventory");
                mail.To.Add(new MailAddress("ruchikamperera@outlook.com"));
                mail.Subject = emailVM.Subject;
                mail.IsBodyHtml = true;
                mail.Body = builder.ToString();

                client.Send(mail);
            }
            catch (Exception ex)
            {

            }
            return emailVM;
        }

        public async Task<ApplicationUserVM> SendRecoveryEmail(EmailVM emailVM,string userName)
        {
            int userLogInEmailTemplateTypeId = 1;
            emailVM.TemplateTypeId = 1;
            string password = "";
            string email = "";
            EmailVM emailVm = new EmailVM();
            ApplicationUserVM applicationUserVM = new ApplicationUserVM();
            try
            {

                using (_unitOfWork)
                {


                    try
                    {
                        _unitOfWork.BeginTransaction();
                applicationUserVM = await  _unitOfWork.ApplicationUserRepository.GetApplicationUserPassByUserName(userName);

                        _unitOfWork.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        _unitOfWork.RollbackTransaction();
                        throw new Exception(ex.Message);

                    }
                }
                password = applicationUserVM.currentPassword;
                email = applicationUserVM.Email;
                var builder = new StringBuilder();

                if (emailVM.TemplateTypeId == userLogInEmailTemplateTypeId)
                {
                    using (var reader = File.OpenText("PasswordRecoveryMail.html"))
                    {
                        builder.Append(reader.ReadToEnd());
                    }
                }
                builder.Replace("{{userName}}", userName);
                builder.Replace("{{password}}", password);

                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                MailMessage mail = new MailMessage();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.Credentials = new NetworkCredential("ruchikamadubashitha@gmail.com", "sanathjayasuriya123");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                //string path = @"F:\print\a.pdf";
                //mail.Attachments.Add(new Attachment(path));

                mail.From = new MailAddress("ruchikamadubashitha@gmail.com", "Onimta Inventory");
                mail.To.Add(new MailAddress(email)); 
                mail.Subject = "Profile Security Service - Onimta Inventory";
                mail.IsBodyHtml = true;
                mail.Body = builder.ToString();

                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return applicationUserVM;
        }
    }
}
