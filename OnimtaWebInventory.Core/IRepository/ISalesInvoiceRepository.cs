using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface ISalesInvoiceRepository
    {
        Task<SalesInvoiceMasterVM> AddNewSalesInvoiceSummaryDetails(SalesInvoiceMasterVM salesInvoiceMasterVM);
        Task<SalesOrderItemVM> AddNewSalesInvoiceItemDetails(SalesOrderItemVM salesOrderItemVM, string invoiceNo,int companyId);
        Task<SalesInvoiceMasterVM> AddNewProformaInvoiceSummaryDetails(SalesInvoiceMasterVM salesInvoiceMasterVM);
        Task<SalesOrderItemVM> AddNewProformaInvoiceItemDetails(SalesOrderItemVM salesOrderItemVM, string invoiceNo, int companyId);
        Task<IEnumerable<SalesInvoiceSummaryVM>> GetAllInvoiceDetailsByCompanyId(int companyId);
        Task<SalesInvoiceMasterVM> GetAllInvoiceSummaryDetailsByInvoiceNo(int InvoiceNo);
        Task<IEnumerable<SalesOrderItemVM>> GetAllInvoicedItemDetailsByInvoiceNo(int InvoiceNo);
    }
}
