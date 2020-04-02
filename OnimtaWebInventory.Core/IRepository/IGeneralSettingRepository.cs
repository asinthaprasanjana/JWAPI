using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
   public  interface IGeneralSettingRepository
    {
        Task<PaymentMethodVM> AddNewPaymentDetails(PaymentMethodVM paymentMethodVM);
        Task<PaymentMethodVM> UpdatePaymentDetails(PaymentMethodVM paymentMethodVM);
        Task<IEnumerable<PaymentMethodVM>> GetAllPaymentDetails();
    }
}
