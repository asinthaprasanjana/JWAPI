using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
  public  interface IPaymentRepository 
    {

        Task<PaymentVM> AddNewPaymentDetails(PaymentVM paymentVM);

        Task<PaymentVM> AddNewPaymentSummeryDetails(PaymentVM paymentVm);

        Task<IEnumerable<PaymentVM>> GetPymentDetailsByCompanyId(int pageId , int BusinessPartnerTypeId);
        Task<PaymentVM> GetPaymentDetailsByPaymentId(int id);

        Task<IEnumerable<PaymentItemVM>> GetPymentItemDetailsByDocumentNo(string documentNo);

        Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetBusinessPartnerPayableDetails(int pageId, int BusinessPartnerTypeId , int businessPartnerId);

        Task<IEnumerable<PaymentVM>> GetPaymentHistoryDetails(int pageId,  int businessPartnerId, int businessPartnerTypeId);
        Task<IEnumerable<PaymentItemVM>> GetPaymentHistoryDetailsByDocumentNo( string documentNo);
    }
}
