using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface ISalesInvoiceServices
    {
        Task<SalesInvoiceMasterVM> AddNewSalesInvoiceDetails(SalesInvoiceMasterVM salesInvoiceMasterVM);
        Task<IEnumerable<SalesInvoiceSummaryVM>> GetAllInvoiceDetailsByCompanyId(int companyId);
        Task<SalesInvoiceMasterVM> GetAllInvoiceDetailsByInvoiceNo(int InvoiceNo);
    }
}
