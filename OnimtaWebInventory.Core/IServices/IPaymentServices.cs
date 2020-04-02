using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IPaymentServices
    {
        Task<PaymentVM> AddNewPaymentDetails( IEnumerable< PaymentVM> paymentVM);
        Task<IEnumerable<PaymentVM>> GetPymentDetailsByCompanyId(int pageId,int businessPartnerTypeId);
        Task<PaymentVM> GetPaymentDetailsByPaymentId(int id);

        Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetBusinessPartnerPayableDetails(int pageId, int BusinessPartnerTypeId, int businessPartnerId);
        Task<IEnumerable<PaymentVM>> GetPaymentHistoryDetails(int pageId, int businessPartnerId, int businessPartnerTypeId);

        Task<IEnumerable<PaymentVM>> GetPaymentHistoryItemsDetailsByDocumentNo(int pageId, string documentNo);


        

    }
}
