using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface ICashierRepository
    {
        Task<AdvancePaymentVM> getTotalAdvacePaymentsByBusinessPartnerId(string businessPartnerId);
        Task<PurchaseOrderBilledEventsVM> addNewBillPayment(PurchaseOrderBilledEventsVM purchaseOrderBilledEventsVM,int isBalanceToAdvance,decimal balanceAmount,int isAdvancePayments,decimal advancePaymentAmount);
        Task<IEnumerable<PurchaseOrderBilledEventsVM>> getBillPaymentEventsByBusinessPartnerIdAndBillID(string BillId);
        Task<IEnumerable<PurchaseOrderBilledEventsVM>> getAllBillPaymentDetails();
        Task<IEnumerable<BillPaymentVM>> getBillPaymentDetailsById(int billId);

    }
}
