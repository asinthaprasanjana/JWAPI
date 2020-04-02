using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IAdvancePaymentRepository
    {

        Task<AdvancePaymentVM> AddNewAdvancePayment(AdvancePaymentVM advancePaymentVM);
        Task<AdvancePaymentVM> GetAdvancePaymentDetailsById(string AdvancePaymentId);
        Task<AdvancePaymentVM> GetAdvancePaymentDetailsByBspId(string BusinessPartnerId);
        Task<IEnumerable<AdvancePaymentVM>> GetAllAdvancePaymentDetailsByBspId(string BusinessPartnerId);
        Task<IEnumerable<AdvancePaymentVM>> GetAllAdvancePaymentDetails();

    }
}
