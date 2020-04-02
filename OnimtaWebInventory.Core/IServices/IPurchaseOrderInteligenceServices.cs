using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IPurchaseOrderInteligenceServices
    {
        Task<PurchaseAndSalesSummaryVM> GetPurchaseorderAndSalesOrderSummaryDeails(int companyId);

    }
}
