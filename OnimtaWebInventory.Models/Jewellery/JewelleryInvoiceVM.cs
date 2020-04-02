using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models.Jewellery
{
    public class InvoiceVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public decimal Advance { get; set; }
        public decimal Cash { get; set; }
        public decimal Cheque { get; set; }
        public decimal CreditCard { get; set; }
        public decimal Gold { get; set; }
        public decimal Voucher { get; set; }
        public RewardsVM VoucherObj { get; set; }
        public decimal BalanceDue { get; set; }
        public decimal Balance { get; set; }
        public IEnumerable<InvoiceProductVM> Products { get; set; }
        public IEnumerable<CreditVM> Payments { get; set; }
        public IEnumerable<InvoiceVM> Advances { get; set; }
        public IEnumerable<InvoiceVM> SetOffs { get; set; }
        public decimal SetOff { get; set; }
        public decimal ApplyAmount { get; set; }
        public InvoiceVM AdvanceObj { get; set; }
        public int AdvanceId { get; set; } //to get the Advance Id From Advance log table
        public decimal Rate { get; set; }
        public int ReceiptNumber { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime CreatedDateTimeUTC { get; set; }
        public string DocumentNumber { get; set; }
        public string BatchCode { get; set; }
        public string CancellationBatchCode { get; set; }
        public string PayMethod { get; set; }
        public decimal Amount { get; set; }
        public int TotalCount { get; set; }
        public Boolean InvoiceUploaded { get; set; }
        public Boolean isCancelled { get; set; }
        public string Reference { get; set; }
        public string  Remark { get; set; }
        public int ReturnId { get; set; }
        public int Customer { get; set; }
        public int Salesman { get; set; }
        public CustomerJw CustomerObj { get; set; }
        public CustomerJw SalesmanObj { get; set; }

        public string TransNo { get; set; }
    }

    public class InvoiceProductVM
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
      //  public int AdvanceId { get; set; }
        public JewelleryProductVM ProductObj { get; set; }
        public int ProductId { get; set; }
        public string Standard { get; set; }
        public decimal ItemWeight { get; set; }
        public decimal DiamondWeight { get; set; }
        public decimal StoneWeight { get; set; }
        public decimal Amount { get; set; }
        public Boolean isReturned { get; set; }
    }

    public class CreditVM
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string PayMethod { get; set; }
        public decimal Amount { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string ChequeNumber { get; set; }
        public string DocumentNumber { get; set; }

    }

    public class PettyCashVM
    {
        public int Id { get; set; }
        public string type { get; set; }
        public string DocumentNumber { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDateTime  { get; set; }
        public string Date  { get; set; }
    }

    public class RewardsVM
    {
        public int Id { get; set; }
        public string PosId { get; set; }
        public string ReceiptDateTime { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalReward { get; set; }
        public string UserId { get; set; }
        public IEnumerable<RewardTransactionVM> RewardTransactions { get; set; }
        public string RefReceipt { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
    }

    public class RewardTransactionVM
    {
        public int Id { get; set; }
        public int RewardRef { get; set; }
        public string RewardName { get; set; }
        public decimal RewardValue { get; set; }
        public string SerialNumber { get; set; }
    }

    public class FilterVM
    {
        public int pageId { get; set; }
        public string keyword { get; set; }
        public Nullable<DateTime> from { get; set; }
        public Nullable<DateTime> to { get; set; }
        public string sortActive { get; set; }
        public string sortDirection { get; set; }
        public int limit { get; set; }
        public string FilterActive { get; set; }
        public int FilterValue { get; set; }
    }

    public class RefundVM
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; }
        public string ReturnDocumentNumber { get; set; }
        public int ReturnId { get; set; }
        public string Remarks { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime CancelledDateTime { get; set; }
        public int CreatedUser {get;set;}
        public int CancelledUser {get;set; }

    }
}
