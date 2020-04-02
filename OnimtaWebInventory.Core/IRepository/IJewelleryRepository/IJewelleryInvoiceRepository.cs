using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http;

namespace OnimtaWebInventory.Core.IRepository.IJewelleryRepository
{
    public interface IJewelleryInvoiceRepository
    {
        Task<InvoiceVM> AddJewelleryInvoice(InvoiceVM Invoice);
        Task<IEnumerable<InvoiceVM>> GetAllInvoices(FilterVM filter);
        Task<InvoiceVM> GetInvoiceById(int Id);
        Task<IEnumerable<InvoiceVM>> GetAllAdvanceDetails(FilterVM filter);
        Task<InvoiceVM> GetAdvanceDetailsById(int id);

        Task<InvoiceVM> AddJewelleryAdvance(InvoiceVM Advance);
        Task<IEnumerable<InvoiceVM>> SearchAdvanceDetails(string Keyword);
        Task<IEnumerable<InvoiceVM>> SearchInvoiceDetails(string Keyword,int PageId);

        Task<RewardsVM> AddJewelleryReward(RewardsVM  rewardsVM);

        Task<InvoiceVM> UpdateInvoice(InvoiceVM invoiceVM);
        Task<InvoiceVM> UpdateInvoiceUploadInfo(Boolean state, int invoiceId);

        Task<IEnumerable<InvoiceVM>> JewelleryDailySummary(InvoiceVM invoiceVM);
        Task<IEnumerable<InvoiceVM>> GetJewelleryInvoiceUploaded();

        Task<IEnumerable<InvoiceVM>> GetInvoiceDetailsByDateRange(DateTime From,DateTime To);
        Task<IEnumerable<InvoiceVM>> GetAdvanceDetailsByDateRange(DateTime From, DateTime To);

        Task<InvoiceVM> InvoiceCancellation(InvoiceVM invoiceVM);

        Task<InvoiceVM> InvoiceReturn(InvoiceVM invoiceVM);
        Task<IEnumerable<InvoiceVM>> GetAllInvoiceReturns(FilterVM filter);
        Task <InvoiceVM> GetInvoiceReturnsById(int returnId);

        Task<IEnumerable<InvoiceVM>> SearchJewelleryInvoiceReturnDetails(string keyWord);

        Task<PettyCashVM> AddJewelleryPettyCash(PettyCashVM cash);
        Task<PettyCashVM> UpdateJewelleryPettyCash(PettyCashVM cash);
        Task<InvoiceVM> DeleteJewelleryPettyCash(int id);
        Task<IEnumerable<InvoiceVM>> GetAllJewelleryPettyCashDetails(); 
        Task<IEnumerable<PettyCashVM>> GetJewelleryPettyCashDetailsByDate(PettyCashVM cash);

        Task<RefundVM> AddRefund(RefundVM refund);
        Task<RefundVM> CancelRefund(RefundVM refund);
        Task<IEnumerable<RefundVM>> GetRefundsByReturnId(int id);

    }
}
