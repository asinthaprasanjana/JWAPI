using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IInvoiceRepository
    {
        Task<PurchaseOrderMasterVM> AddNewInvoiceDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> UpdateInvoiceDetails(PurchaseOrderMasterVM purchaseOrderMasterVM);
        Task<PurchaseOrderMasterVM> GetInvoiceDetailsById(int id);
        Task<IEnumerable<PurchaseOrderMasterVM>> GetAllInvoiceDetails(int branchId);
    }
}
