using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface ICashierServices
    {
        Task<AdvancePaymentVM> getTotalAdvacePaymentsByBusinessPartnerId(string businessPartnerId);
        Task<PurchaseOrderBilledEventsVM> addNewBillPayment(PurchaseOrderBilledEventsFinalVM purchaseOrderBilledEventsVMs);
        Task<IEnumerable<PurchaseOrderBilledEventsVM>> getBillPaymentEventsByBusinessPartnerIdAndBillID(string BillIds);
        Task<IEnumerable<PurchaseOrderBilledEventsVM>> getAllBillPaymentDetails();
        Task<IEnumerable<BillPaymentVM>> getBillPaymentDetailsById(int billId);
    }
}
